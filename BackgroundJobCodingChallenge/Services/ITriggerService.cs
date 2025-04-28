namespace BackgroundJobCodingChallenge.Services
{
    public interface ITriggerService
    {
        Action Subscribe(Func<CancellationToken, Task> workerAction);
    }
}
