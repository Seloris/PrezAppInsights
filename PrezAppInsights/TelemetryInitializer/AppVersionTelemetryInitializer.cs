using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using System.Web;

namespace PrezAppInsights.TelemetryInitializer
{
    public class AppVersionTelemetryInitializer : ITelemetryInitializer
    {
        private static string applicationVersion = "1.0";

        public void Initialize(ITelemetry telemetry)
        {
            telemetry.Context.Component.Version = applicationVersion;

            // we can set other informations too
            //telemetry.Context.User.Id = "";
            //telemetry.Context.Device.Id = "";
            //telemetry.Context.Properties["CustomKey"] = "CustomData";
        }
    }
}