using System.Collections.Concurrent;
using System.Text.Json;
using BackgroundJobCodingChallenge.Services;

namespace BackgroundJobCodingChallenge.Services
{
    public class MockQueueService : IQueueService
    {
        private readonly ConcurrentDictionary<string, ConcurrentQueue<string>> _queues = new();

        public Task EnqueueAsync(string queueName, object data)
        {
            var queue = _queues.GetOrAdd(queueName, _ => new ConcurrentQueue<string>());
            var jsonData = JsonSerializer.Serialize(data);
            queue.Enqueue(jsonData);
            return Task.CompletedTask;
        }

        public Task<object?> DequeueAsync(string queueName)
        {
            if (_queues.TryGetValue(queueName, out var queue) && queue.TryDequeue(out var jsonData))
            {
                return Task.FromResult<object?>(JsonSerializer.Deserialize<object>(jsonData));
            }

            return Task.FromResult<object?>(null);
        }
    }
}
