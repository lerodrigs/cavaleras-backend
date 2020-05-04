using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cavaleras.Api.Extensions.HealthChecks
{
    public class GCInfoHealthCheck: IHealthCheck
    {
        private readonly IOptionsMonitor<GCHealthCheckInfoOptions> _optionsMonitor; 
        public GCInfoHealthCheck(IOptionsMonitor<GCHealthCheckInfoOptions> optionsMonitor)
        {
            _optionsMonitor = optionsMonitor; 
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            GCHealthCheckInfoOptions options = _optionsMonitor.Get(context.Registration.Name);

            long allocated = GC.GetTotalMemory(false);
            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                { "Allocated", allocated },
                { "Gen0Collections",GC.CollectionCount(0)},
                { "Gen1Collections", GC.CollectionCount(1)},
                { "Gen2Collections", GC.CollectionCount(2)}
            };

            HealthStatus status = allocated >= options.Threshold ? context.Registration.FailureStatus : HealthStatus.Healthy;
            return Task.FromResult(new HealthCheckResult(status, description: "reports degraded if allocated bytes >= 1GB.", data: data));
        }
    }
}
