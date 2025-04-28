using System.Collections.Concurrent;

namespace BackgroundJobCodingChallenge.Services
{
    public class MockDatabaseService : IDatabaseService
    {
        private readonly ConcurrentDictionary<string, List<object>> _data = new();

        public Task SaveAsync(string entityName, object data)
        {
            var list = _data.GetOrAdd(entityName, _ => new List<object>());
            list.Add(data);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<object>> GetAllAsync(string entityName)
        {
            _data.TryGetValue(entityName, out var list);
            return Task.FromResult((IEnumerable<object>)(list ?? new List<object>()));
        }
    }
}