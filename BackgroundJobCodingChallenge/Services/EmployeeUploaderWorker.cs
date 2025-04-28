using System;
using System.Threading.Tasks;

namespace BackgroundJobCodingChallenge.Services
{
    public class EmployeeUploaderWorker : BackgroundWorkerBase
    {
        public override WorkerScope Scope => WorkerScope.Global;

        public override async Task ExecuteAsync(WorkerContext context)
        {
            Console.WriteLine("Uploading employee data...");
            await Task.Delay(1500, context.CancellationToken); // Simulate work
        }
    }
}
