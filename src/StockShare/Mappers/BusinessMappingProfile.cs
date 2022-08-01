using AutoMapper;
using Fengchao.Greeter;
using StockShare.Areas.Private.ViewModels;

namespace StockShare.Mappers
{
    /// <summary>
    /// Provides mapping configrations for business logic.
    /// </summary>
    public class BusinessMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessMappingProfile"/> class.
        /// </summary>
        public BusinessMappingProfile()
        {
            CreateMap<GreetMessage, LeaveMessageRequest>();
        }
    }
}
