using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cavaleras.Api.Extensions.HealthChecks
{
    public static class GCHealthCheckInfoBuilderExtensions
    {
        public static IHealthChecksBuilder AddMemoryInfoHealthCheck(this IHealthChecksBuilder builder, string name, HealthStatus? failureStatus = null, IEnumerable<string> tags = null, long? thresholdInBytes = null)
        {
            builder.AddCheck<GCInfoHealthCheck>(name, failureStatus ?? HealthStatus.Degraded, tags);

            if(thresholdInBytes.HasValue)
            {
                builder.Services.Configure<GCHealthCheckInfoOptions>(name, options =>
                {
                    options.Threshold = thresholdInBytes.Value;
                });
            }

            return builder;
        }
    }
}
