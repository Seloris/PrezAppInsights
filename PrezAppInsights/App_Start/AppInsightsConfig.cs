using Microsoft.ApplicationInsights.Extensibility;
using PrezAppInsights.TelemetryInitializer;
using System.Configuration;

namespace PrezAppInsights.App_Start
{
    public static class AppInsightsConfig
    {
        public static void Register()
        {
            // Retrieve current telemetry configuration
            TelemetryConfiguration telemetryConfig = TelemetryConfiguration.Active;

            // Could set the instrumentation key by app settings
            //telemetryConfig.InstrumentationKey = ConfigurationManager.AppSettings["AppInsKey"];

            // Add telemetry initializers
            telemetryConfig.TelemetryInitializers.Add(new AppVersionTelemetryInitializer());
        }
    }
}