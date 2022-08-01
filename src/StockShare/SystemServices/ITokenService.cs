using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StockShare.SystemServices
{
    /// <summary>
    /// Provides methods for managing tokens.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Genereates access token with the given claims.
        /// </summary>
        /// <param name="claims">The claims to be added to the access token.</param>
        /// <returns>Access token.</returns>
        string GenerateAccessToken(IEnumerable<Claim>? claims);

        /// <summary>
        /// Genereates a new refresh token.
        /// </summary>
        /// <returns>Refresh token.</returns>
        string GenerateRefreshToken();

        /// <summary>
        /// Caches a new refresh token to distributed cache.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="refreshToken">The refresh token to be cached.</param>
        /// <returns>A task that represents the result.</returns>
        Task CacheRefreshTokenAsync(string userId, string refreshToken);

        /// <summary>
        /// Revokes the given user refresh token.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="refreshToken">The refresh token to be revoked.</param>
        /// <returns>A task that represents the result.</returns>
        Task RevokeRefreshTokenAsync(string userId, string refreshToken);

        /// <summary>
        /// Gets principal from expired token.
        /// </summary>
        /// <param name="accessToken">The access token to be parsed.</param>
        /// <returns>The <see cref="ClaimsPrincipal"/> parsed from the given access token.</returns>
        ClaimsPrincipal? ParsePrincipalFromAccessToken(string? accessToken);

        /// <summary>
        /// Blocks the given access token.
        /// </summary>
        /// <param name="accessToken">The access token to be blocked.</param>
        /// <returns>A task that represents the result.</returns>
        Task BlockAccessTokenAsync(string accessToken);

        /// <summary>
        /// Checks whether the given access token has been blocked.
        /// </summary>
        /// <param name="accessToken">The access token to be validated.</param>
        /// <returns>
        /// <see langword="true"/> if the given access token is blocked; otherwise, <see langword="false"/>.
        /// </returns>
        bool IsAccessTokenBlocked(string? accessToken);

        /// <summary>
        /// Revokes all refresh tokens of the given user.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns>A task that represents the result.</returns>
        Task RevokeAllRefreshTokensAsync(string userId);

        /// <summary>
        /// Checks whether the given user refresh token is valid.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="refreshToken">The refresh token to be validated.</param>
        /// <returns>
        /// <see langword="true"/> if the given user refresh token is valid; otherwise, <see langword="false"/>.
        /// </returns>
        bool IsRefreshTokenValid(string userId, string? refreshToken);
    }
}
