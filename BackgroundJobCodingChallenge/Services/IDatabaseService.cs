namespace BackgroundJobCodingChallenge.Services
{
    public interface IDatabaseService
    {
        Task SaveAsync(string entityName, object data);
        Task<IEnumerable<object>> GetAllAsync(string entityName);
    }
}