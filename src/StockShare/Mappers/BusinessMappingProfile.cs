using AutoMapper;
using Fengchao.Greeter;
using StockShare.Areas.Private.ViewModels;
using StockShare.Data.Entities;

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

            CreateMap<DailyBasicEntity, Daily_BJS_Entity>();
            CreateMap<DailyBasicEntity, Daily_CYB_Entity>();
            CreateMap<DailyBasicEntity, Daily_ZB_Entity>();
            CreateMap<DailyBasicEntity, Daily_ZXB_Entity>();
            CreateMap<DailyBasicEntity, Daily_KCB_Entity>();
        }
    }
}
