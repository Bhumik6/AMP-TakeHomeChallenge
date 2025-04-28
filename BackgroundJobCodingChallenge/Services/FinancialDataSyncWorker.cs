using System;
using System.Threading.Tasks;

namespace BackgroundJobCodingChallenge.Services
{
    public class FinancialDataSyncWorker : BackgroundWorkerBase
    {
        public override WorkerScope Scope => WorkerScope.Tenant;

        public override async Task ExecuteAsync(WorkerContext context)
        {
            Console.WriteLine($"Synchronizing financial data for tenant {context.TenantId}...");
            await Task.Delay(3000, context.CancellationToken); // Simulate work
        }
    }
}
