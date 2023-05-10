using EC.Console.Client.Calculator.Services.Resolvers;
using EC.Console.Client.Calculator.Services.Resolvers.Additions;
using EC.Console.Client.Calculator.Services.Resolvers.Additions.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.Divisions;
using EC.Console.Client.Calculator.Services.Resolvers.Journals;
using EC.Console.Client.Calculator.Services.Resolvers.Multiplications;
using EC.Console.Client.Calculator.Services.Resolvers.SquareRoots;
using EC.Console.Client.Calculator.Services.Resolvers.Subtractions;
using Microsoft.Extensions.DependencyInjection;

namespace EC.Console.Client.Calculator.Services.Ioc
{
    public static class ServicesRegistrar
    {
        public static ServiceCollection AddServices(this ServiceCollection services, string calculatorApiUrl)
        {
            services.AddSingleton(x => new HttpClient
            {
                BaseAddress = new Uri(calculatorApiUrl)
            });
            services.AddSingleton<IApiManager, ApiManager>();
            services.AddSingleton<IOperationResolver<AdditionResponse>, AdditionResolver>();
            services.AddSingleton<IOperationResolver<DivisionResponse>, DivisionResolver>();
            services.AddSingleton<IOperationResolver<MultiplicationResponse>, MultiplicationResolver>();
            services.AddSingleton<IOperationResolver<SquareRootResponse>, SquareRootResolver>();
            services.AddSingleton<IOperationResolver<SubtractionResponse>, SubtractionResolver>();
            services.AddSingleton<IOperationResolver<JournalResponse>, JournalResolver>();

            return services;
        }
    }
}
