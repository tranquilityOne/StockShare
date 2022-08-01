using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockShare.Core.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace StockShare.Areas.Basic.Controllers
{
    /// <summary>
    /// A base class for api controller.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public partial class BasicController : ControllerBase
    {
        private BasicUserInfo _currentUser = default!;

        /// <summary>
        /// Gets current oa user info.
        /// </summary>
        public BasicUserInfo CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    var userId = HttpContext.User.Claims
                        .SingleOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid);

                    _currentUser = new BasicUserInfo
                    {
                        Id = Convert.ToInt32(string.IsNullOrEmpty(userId?.Value) ? 0 : userId.Value)
                    };
                }

                return _currentUser;
            }
        }
    }
}
