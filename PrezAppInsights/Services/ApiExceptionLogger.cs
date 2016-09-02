using Microsoft.ApplicationInsights;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace PrezAppInsights.Services
{
    public class ApiExceptionLogger : ExceptionLogger
    {
        public override Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Log(context);
            }, cancellationToken);
        }

        public override void Log(ExceptionLoggerContext context)
        {
            // Log into Application Insights
            var ai = new TelemetryClient();
            ai.TrackException(context.Exception);
        }
    }
}