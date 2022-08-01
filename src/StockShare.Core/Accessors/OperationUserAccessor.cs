using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StockShare.Core.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace StockShare.Core.Accessors
{
    /// <summary>
    /// Provides <see langword="static"/> access to operation user.
    /// </summary>
    public static class OperationUserAccessor
    {
        /// <summary>
        /// The user of current pipeline.
        /// </summary>
        public static BasicUserInfo? CurrentUser
        {
            get
            {
                var httpContextAccessor = ServiceProviderAccessor.ServiceProvider.GetRequiredService<IHttpContextAccessor>();

                if (httpContextAccessor.HttpContext == null)
                {
                    return null;
                }

                var userId = httpContextAccessor.HttpContext.User.Claims
                    .SingleOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid);

                return new BasicUserInfo
                {
                    Id = Convert.ToInt32(string.IsNullOrEmpty(userId?.Value) ? 0 : userId.Value)
                };
            }
        }
    }
}
