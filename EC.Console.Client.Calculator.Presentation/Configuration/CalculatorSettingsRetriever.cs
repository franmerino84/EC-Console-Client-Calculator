using Microsoft.Extensions.Configuration;

namespace EC.Console.Client.Calculator.Presentation.Configuration
{
    public static class CalculatorSettingsRetriever
    {
        public static CalculatorSettings GetSettings()
        {
            var configuration = new ConfigurationBuilder()
                 .AddJsonFile($"appsettings.json");

            var configurationRoot = configuration.Build();
            var settings = new CalculatorSettings();
            configurationRoot.GetSection("CalculatorSettings").Bind(settings);

            return settings;
        }
    }
}
