using System;
using System.Collections.Generic;

namespace BackgroundJobCodingChallenge.Services
{
    public class WorkerRegistry
    {
        private readonly Dictionary<string, BackgroundWorkerBase> _workers = new Dictionary<string, BackgroundWorkerBase>();

        public void Register<TWorker>(TWorker worker) where TWorker : BackgroundWorkerBase
        {
            _workers[typeof(TWorker).Name] = worker;
        }

        public BackgroundWorkerBase? GetWorker(string name)
        {
            _workers.TryGetValue(name, out var worker);
            return worker;
        }

        public IEnumerable<BackgroundWorkerBase> GetAllWorkers()
        {
            return _workers.Values;
        }
    }
}
