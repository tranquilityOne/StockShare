using Fengchao.Gallery.WebApi.Extensions;
using Fengchao.Gallery.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StockShare.Areas.Authentication.ViewModels;
using StockShare.Areas.Basic.Controllers;
using StockShare.Core.Configuration;
using StockShare.SystemServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StockShare.Areas.Authentication.Controllers
{
    /// <summary>
    /// Users controller.
    /// </summary>
    public partial class UsersController : BasicController
    {
        private readonly ITokenService _tokenService;
        private readonly JwtIssuerOptions _jwtIssuerOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="jwtIssuerOptionsMonitor"></param>
        /// <param name="tokenService"></param>
        public UsersController(
            IOptionsMonitor<JwtIssuerOptions> jwtIssuerOptionsMonitor,
            ITokenService tokenService)
        {
            _tokenService = tokenService;
            _jwtIssuerOptions = jwtIssuerOptionsMonitor.CurrentValue;
        }

        /// <summary>
        /// User login.
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns>Token info.</returns>
        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<ResponseResult<TokenInfo>> Login([FromBody] LoginRequest loginRequest)
        {
            var responseResult = new ResponseResult<TokenInfo>();

            var userName = "default_user";
            responseResult.Data = await CreateLoginTokenAsync(1, null);
            responseResult.Data.LoginName = userName;
            responseResult.Data.StaffName = userName;

            return responseResult;
        }

        /// <summary>
        /// Refreshes token.
        /// </summary>
        /// <param name="request">Request for refreshing token.</param>
        /// <returns>Token info.</returns>
        /// <response code="200">Refreshes token successfully.</response>
        /// <response code="400">Claim principal of expired token is invalid.</response>
        /// <response code="403">Failed to validate refresh token.</response>
        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseResult<TokenInfo>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var principal = _tokenService.ParsePrincipalFromAccessToken(request.AccessToken);

            if (principal == null)
            {
                return BadRequest(new { Error = "Invalid access token." });
            }

            var userId = principal.Claims.GetClaimValue(JwtRegisteredClaimNames.Sid);

            if (!_tokenService.IsRefreshTokenValid(userId ?? string.Empty, request.RefreshToken))
            {
                return Forbid();
            }

            var tokenInfo = await CreateLoginTokenAsync(int.Parse(userId!), request.RefreshToken);

            return Ok(new ResponseResult<TokenInfo>
            {
                Data = tokenInfo
            });
        }

        private async Task<TokenInfo> CreateLoginTokenAsync(int userId, string? oldRefreshToken)
        {
            var userIdStr = userId.ToString();

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sid, userIdStr),
            };

            var token = new TokenInfo()
            {
                AccessToken = _tokenService.GenerateAccessToken(claims),
                RefreshToken = _tokenService.GenerateRefreshToken(),
                ExpiresIn = _jwtIssuerOptions.TokenExpirationInMinutes * 60,
            };

            await _tokenService.CacheRefreshTokenAsync(userIdStr, token.RefreshToken);

            if (!string.IsNullOrWhiteSpace(oldRefreshToken))
            {
                await _tokenService.RevokeRefreshTokenAsync(userIdStr, oldRefreshToken);
            }

            return token;
        }
    }
}
