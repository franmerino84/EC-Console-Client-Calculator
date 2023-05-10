using EC.Console.Client.Calculator.Presentation.Client;
using EC.Console.Client.Calculator.Presentation.Configuration;
using EC.Console.Client.Calculator.Presentation.Processors;
using EC.Console.Client.Calculator.Presentation.Processors.Factory;
using EC.Console.Client.Calculator.Services.Ioc;
using EC.Console.Client.Calculator.Services.Resolvers.Additions.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.Divisions;
using EC.Console.Client.Calculator.Services.Resolvers.Journals;
using EC.Console.Client.Calculator.Services.Resolvers.Multiplications;
using EC.Console.Client.Calculator.Services.Resolvers.SquareRoots;
using EC.Console.Client.Calculator.Services.Resolvers.Subtractions;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable CS8604 // Possible null reference argument.

namespace EC.Console.Client.Calculator.Presentation.Ioc
{
    public static class ServiceProviderBuilder
    {
        public static ServiceProvider Build(CalculatorSettings settings)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMappings();
            serviceCollection.AddServices(settings.CalculatorApiUrl);            
            serviceCollection.AddSingleton<IOperationProcessorFactory, OperationProcessorFactory>();
            serviceCollection.AddSingleton<ICalculatorClient, CalculatorClient>();
            serviceCollection.AddSingleton(x => new AdditionProcessor(x.GetService<IOperationResolver<AdditionResponse>>()));
            serviceCollection.AddSingleton(x => new DivisionProcessor(x.GetService<IOperationResolver<DivisionResponse>>()));
            serviceCollection.AddSingleton(x => new MultiplicationProcessor(x.GetService<IOperationResolver<MultiplicationResponse>>()));
            serviceCollection.AddSingleton(x => new SquareRootProcessor(x.GetService<IOperationResolver<SquareRootResponse>>()));
            serviceCollection.AddSingleton(x => new SubtractionProcessor(x.GetService<IOperationResolver<SubtractionResponse>>()));
            serviceCollection.AddSingleton(x => new JournalProcessor(x.GetService<IOperationResolver<JournalResponse>>()));

            return serviceCollection.BuildServiceProvider();
        }
    }
}

#pragma warning restore CS8604 // Possible null reference argument.
