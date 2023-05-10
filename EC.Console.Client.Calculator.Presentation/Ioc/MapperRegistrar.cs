using AutoMapper;
using EC.Api.Calculator.Presentation.WebApi.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace EC.Console.Client.Calculator.Presentation.Ioc
{
    public static class MapperRegistrar
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            IMapper mapper = CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }

        private static IMapper CreateMapper()
        {
            MapperConfiguration mappingConfiguration = new(mc =>
            {
                mc.AddProfile<ServicesMappingProfile>();
            });
            mappingConfiguration.AssertConfigurationIsValid();

            return mappingConfiguration.CreateMapper();
        }



    }
}