using System;
using System.Threading.Tasks;

namespace BackgroundJobCodingChallenge.Services
{
    public class CustomerActionWorker : BackgroundWorkerBase
    {
        public override WorkerScope Scope => WorkerScope.Tenant;

        public override async Task ExecuteAsync(WorkerContext context)
        {
            Console.WriteLine($"Processing customer actions for tenant {context.TenantId}...");
            await Task.Delay(2000, context.CancellationToken); // Simulate work
        }
    }
}
