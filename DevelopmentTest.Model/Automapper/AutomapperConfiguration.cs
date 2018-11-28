using AutoMapper;
using DevelopmentTest.Model.DTO;
using DevelopmentTest.Model.Model;

namespace DevelopmentTest.Model.Automapper
{
    public static class AutoMapperConfiguration
    {
        public static IConfigurationProvider Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Employee, HourlyEmployeeDto>();

                cfg.CreateMap<Employee, MonthlyEmployeeDto>();
            });

            return Mapper.Configuration;
        }
    }
}
