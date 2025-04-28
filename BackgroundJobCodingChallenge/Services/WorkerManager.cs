using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BackgroundJobCodingChallenge.Services;

namespace BackgroundJobCodingChallenge.Services
{
    public class WorkerManager
    {
        private readonly WorkerRegistry _registry;
        private readonly ITriggerService _triggerService;
        private readonly Dictionary<Type, Action> _unsubscribers = new Dictionary<Type, Action>();

        public WorkerManager(WorkerRegistry registry, ITriggerService triggerService)
        {
            _registry = registry;
            _triggerService = triggerService;
        }

        public void StartWorkers()
        {
            foreach (var worker in _registry.GetAllWorkers())
            {
                var unsubscribe = _triggerService.Subscribe(async cancellationToken =>
                {
                    var context = new WorkerContext
                    {
                        Scope = worker.Scope,
                        CancellationToken = cancellationToken
                    };

                    try
                    {
                        await RetryHelper.RetryAsync(() => worker.ExecuteAsync(context), 3);
                    }
                    catch (Exception ex)
                    {
                        await worker.OnErrorAsync(ex, context);
                    }
                });

                _unsubscribers[worker.GetType()] = unsubscribe;
            }
        }

        public void StopWorkers()
        {
            foreach (var unsubscribe in _unsubscribers.Values)
            {
                unsubscribe.Invoke();
            }
            _unsubscribers.Clear();
        }
    }
}
