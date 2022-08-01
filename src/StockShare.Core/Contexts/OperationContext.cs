using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using StockShare.Core.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace StockShare.Core.Contexts
{
    /// <summary>
    /// Operation context.
    /// </summary>
    public class OperationContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private BasicUserInfo? _currentUser;
        private string? _accessToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationContext"/> class.
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public OperationContext(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Default instance of the <see cref="OperationContext"/> class.
        /// </summary>
        public static OperationContext Default
        {
            get
            {
                var httpContextAccessor = new HttpContextAccessor
                {
                    HttpContext = new DefaultHttpContext()
                };

                return new OperationContext(httpContextAccessor);
            }
        }

        /// <summary>
        /// Current user.
        /// </summary>
        public BasicUserInfo? CurrentUser
        {
            get
            {
                try
                {
                    if (_currentUser == null)
                    {
                        if (_httpContextAccessor.HttpContext == null)
                        {
                            return null;
                        }

                        var userId = _httpContextAccessor.HttpContext.User.Claims
                            .SingleOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid);

                        _currentUser = new BasicUserInfo
                        {
                            Id = Convert.ToInt32(string.IsNullOrEmpty(userId?.Value) ? 0 : userId.Value)
                        };
                    }

                    return _currentUser;
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Access token.
        /// </summary>
        public string? AccessToken
        {
            get
            {
                if (string.IsNullOrEmpty(_accessToken))
                {
                    if (_httpContextAccessor.HttpContext == null)
                    {
                        return null;
                    }

                    if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue(
                        "Authorization", out StringValues authorization))
                    {
                        _accessToken = authorization.FirstOrDefault()?.Replace("Bearer ", string.Empty);
                    }
                }

                return _accessToken;
            }
        }
    }
}
