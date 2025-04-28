using System;
using System.Threading.Tasks;

namespace BackgroundJobCodingChallenge.Services
{
    public static class RetryHelper
    {
        public static async Task RetryAsync(Func<Task> action, int maxRetries)
        {
            int retries = 0;
            while (true)
            {
                try
                {
                    await action();
                    break;
                }
                catch
                {
                    retries++;
                    if (retries >= maxRetries)
                        throw;
                }
            }
        }
    }
}