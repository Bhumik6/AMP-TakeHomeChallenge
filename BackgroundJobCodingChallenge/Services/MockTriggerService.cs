using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundJobCodingChallenge.Services
{
    public class MockTriggerService : ITriggerService
    {
        public Action Subscribe(Func<CancellationToken, Task> handler)
        {
            Console.WriteLine("[Trigger] Mock subscription set.");
            return () => Console.WriteLine("[Trigger] Mock unsubscribe called.");
        }
    }
}
