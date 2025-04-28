using System.Threading.Tasks;

namespace BackgroundJobCodingChallenge.Services
{
    public abstract class BackgroundWorkerBase
    {
        public abstract WorkerScope Scope { get; }

        public abstract Task ExecuteAsync(WorkerContext context);

        public virtual Task OnErrorAsync(System.Exception exception, WorkerContext context)
        {
            return Task.CompletedTask;
        }
    }
}
