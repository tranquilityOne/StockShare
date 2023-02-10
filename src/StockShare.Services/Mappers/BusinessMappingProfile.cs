using AutoMapper;
using StockShare.Data.Entities;

namespace StockShare.Services.Mappers
{
    /// <summary>
    /// Provides mapping configrations
    /// </summary>
    public class BusinessMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessMappingProfile"/> class.
        /// </summary>
        public BusinessMappingProfile()
        {
            CreateMap<DailyBasicEntity, Daily_BJS_Entity>();
            CreateMap<DailyBasicEntity, Daily_CYB_Entity>();
            CreateMap<DailyBasicEntity, Daily_ZB_Entity>();
            CreateMap<DailyBasicEntity, Daily_ZXB_Entity>();
            CreateMap<DailyBasicEntity, Daily_KCB_Entity>();
        }
    }
}
