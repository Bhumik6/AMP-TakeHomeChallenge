namespace BackgroundJobCodingChallenge.Services
{
    public interface IQueueService
    {
        Task EnqueueAsync(string queueName, object data);
        Task<object?> DequeueAsync(string queueName);
    }
}
