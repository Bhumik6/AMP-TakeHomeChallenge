using System.Collections.Generic;
using System.Threading;

namespace BackgroundJobCodingChallenge.Services
{
    public class WorkerContext
    {
        public WorkerScope Scope { get; set; }
        public string? TenantId { get; set; } // Null if Global
        public IDictionary<string, string> State { get; set; } = new Dictionary<string, string>();
        public CancellationToken CancellationToken { get; set; }
    }
}
