using Fengchao.Gallery.Core;
using Fengchao.Gallery.Core.Linq;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using StockShare.Core.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StockShare.SystemServices
{
    /// <inheritdoc/>
    public class TokenService : ITokenService
    {
        private const string _jwtAlgorithm = SecurityAlgorithms.HmacSha256;
        private readonly JwtIssuerOptions _jwtBearerOptions;
        private readonly ConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _redisDb;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenService"/> class.
        /// </summary>
        /// <param name="jwtBearerOptionsMonitor"></param>
        /// <param name="connectionMultiplexer"></param>
        public TokenService(
            IOptionsMonitor<JwtIssuerOptions> jwtBearerOptionsMonitor,
            ConnectionMultiplexer connectionMultiplexer)
        {
            _jwtBearerOptions = jwtBearerOptionsMonitor.CurrentValue;
            _connectionMultiplexer = connectionMultiplexer;
            _redisDb = connectionMultiplexer.GetDatabase();
        }

        /// <inheritdoc/>
        public string GenerateAccessToken(IEnumerable<Claim>? claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtBearerOptions.Secret));
            var now = DateTime.Now;

            var jwtToken = new JwtSecurityToken(
                issuer: _jwtBearerOptions.Issuer,
                audience: _jwtBearerOptions.Audience,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_jwtBearerOptions.TokenExpirationInMinutes),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        /// <inheritdoc/>
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        /// <inheritdoc/>
        public async Task CacheRefreshTokenAsync(
            string userId, string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(userId)
                || string.IsNullOrWhiteSpace(refreshToken))
            {
                throw new ArgumentException("Both user id and refresh token should not be null, empty, " +
                    "or consists only of white-space characters.");
            }

            await _redisDb.StringSetAsync(
                BuildRefreshTokenCacheKey(userId, refreshToken),
                refreshToken,
                TimeSpan.FromMinutes(_jwtBearerOptions.RefreshTokenExpirationInMinutes));
        }

        /// <inheritdoc/>
        public async Task RevokeRefreshTokenAsync(string userId, string refreshToken)
        {
            var cacheKey = BuildRefreshTokenCacheKey(userId, refreshToken);
            await _redisDb.KeyDeleteAsync(cacheKey);
        }

        /// <inheritdoc/>
        public ClaimsPrincipal? ParsePrincipalFromAccessToken(string? accessToken)
        {
            return ParsePrincipalFromAccessToken(accessToken, validateLifeTime: false);
        }

        /// <inheritdoc/>
        public async Task BlockAccessTokenAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("Access token should not be null, empty, or consists only of " +
                    "white-space characters.");
            }

            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            var expiry = ((long)jwtToken.Payload.Exp!).ToLocalDateTime() - DateTime.Now;

            await _redisDb.StringSetAsync(
                BuildBlockedTokenCacheKey(accessToken),
                string.Empty,
                expiry);
        }

        /// <inheritdoc/>
        public bool IsAccessTokenBlocked(string? accessToken)
        {
            return _redisDb.KeyExists(BuildBlockedTokenCacheKey(accessToken!));
        }

        /// <inheritdoc/>
        public async Task RevokeAllRefreshTokensAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("Invalid user id.");
            }

            var keyPattern = BuildRefreshTokenCacheKey(userId, "*");
            var endpoints = _connectionMultiplexer.GetEndPoints(true);

            await endpoints.ParallelForEachAsync(async endpoint =>
            {
                var redisServer = _connectionMultiplexer.GetServer(endpoint);
                var keys = redisServer.Keys(pattern: keyPattern);

                foreach (var key in keys)
                {
                    await _redisDb.KeyDeleteAsync(key);
                }
            });
        }

        /// <inheritdoc/>
        public bool IsRefreshTokenValid(string userId, string? refreshToken)
        {
            if (string.IsNullOrWhiteSpace(userId)
                || string.IsNullOrWhiteSpace(refreshToken))
            {
                return false;
            }

            return _redisDb.KeyExists(BuildRefreshTokenCacheKey(userId, refreshToken));
        }

        private static string BuildBlockedTokenCacheKey(string token)
        {
            return $"{Assembly.GetEntryAssembly()!.GetName().Name}:blockedtoken:{token.GetHashCode()}";
        }

        private static string BuildRefreshTokenCacheKey(string userId, string refreshToken)
        {
            return $"{Assembly.GetEntryAssembly()!.GetName().Name}:refreshtoken:{userId}:{refreshToken}";
        }

        private ClaimsPrincipal? ParsePrincipalFromAccessToken(string? accessToken, bool validateLifeTime)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return null;
            }

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = true,
                ValidIssuer = _jwtBearerOptions.Issuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtBearerOptions.Secret)),
                ValidateLifetime = validateLifeTime
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out SecurityToken securityToken);

                if (securityToken is not JwtSecurityToken jwtSecurityToken
                    || !string.Equals(jwtSecurityToken.Header.Alg, _jwtAlgorithm, StringComparison.InvariantCultureIgnoreCase))
                {
                    return null;
                }

                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}
