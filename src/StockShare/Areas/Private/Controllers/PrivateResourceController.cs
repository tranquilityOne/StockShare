using AutoMapper;
using Fengchao.Gallery.WebApi.ViewModels;
using Fengchao.Greeter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockShare.Areas.Basic.Controllers;
using StockShare.Areas.Private.ViewModels;
using System.Threading.Tasks;

namespace StockShare.Areas.Private.Controllers
{
    /// <summary>
    /// Private controller.
    /// </summary>
    [Authorize]
    public class PrivateResourceController : BasicController
    {
        private readonly IMapper _mapper;
        private readonly GreeterService.GreeterServiceClient _greeterServiceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrivateResourceController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="greeterServiceClient"></param>
        public PrivateResourceController(
            IMapper mapper,
            GreeterService.GreeterServiceClient greeterServiceClient)
        {
            _mapper = mapper;
            _greeterServiceClient = greeterServiceClient;
        }

        /// <summary>
        /// Queries private resource.
        /// </summary>
        /// <returns>Private resource.</returns>
        [HttpGet]
        public PagerResponseResult<string> Query()
        {
            return Succeed<string>(new string[] { "value1", "value2" });
        }

        /// <summary>
        /// Leaves a greet message to somebody.
        /// </summary>
        /// <param name="greetMessage"></param>
        /// <returns>Greet result.</returns>
        [HttpPost]
        public async Task<StatusResponseResult> Greet([FromBody] GreetMessage greetMessage)
        {
            var leaveMessageRequest = _mapper.Map<LeaveMessageRequest>(greetMessage);
            leaveMessageRequest.SenderName = GetUserNameById(CurrentUser.Id);

            await _greeterServiceClient.LeaveMessageAsync(leaveMessageRequest);

            return Succeed();
        }

        private static string GetUserNameById(int id)
        {
            return $"User {id}";
        }
    }
}
