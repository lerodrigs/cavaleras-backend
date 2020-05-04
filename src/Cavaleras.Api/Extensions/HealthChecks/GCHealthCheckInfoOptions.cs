using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cavaleras.Api.Extensions.HealthChecks
{
    public class GCHealthCheckInfoOptions
    {
        public long Threshold { get; set; } = 1024L * 1204L * 1204L; 
    }
}
