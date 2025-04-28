using Microsoft.AspNetCore.Mvc;
using BackgroundJobCodingChallenge.Services;
using System.Linq; // <== ADD THIS if not already

namespace BackgroundJobCodingChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TriggerController : ControllerBase
    {
        private readonly WorkerRegistry _registry;

        public TriggerController(WorkerRegistry registry)
        {
            _registry = registry;
        }

        [HttpPost("{workerName}")]
        public async Task<IActionResult> TriggerWorker(string workerName)
        {
            var worker = _registry.GetAllWorkers()
                .FirstOrDefault(w => w.GetType().Name.Equals(workerName, StringComparison.OrdinalIgnoreCase));

            if (worker == null)
            {
                return NotFound($"Worker '{workerName}' not found.");
            }

            var context = new WorkerContext
            {
                Scope = worker.Scope,
                CancellationToken = HttpContext.RequestAborted
            };

            try
            {
                await worker.ExecuteAsync(context);
                return Ok($"Worker '{workerName}' executed successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Worker '{workerName}' failed: {ex.Message}");
            }
        }
    }
}
