using AutoMapper;
using SeteFios.API.Models;
using SeteFios.API.Models.DTOs;

namespace SeteFios.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegiterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ClientDto, Client>().ReverseMap();
                config.CreateMap<ScheduleDto, Schedule>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
