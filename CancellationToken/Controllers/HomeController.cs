using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CancellationToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _iLogger;

        public HomeController(ILogger<HomeController> iLogger)
        {
            _iLogger = iLogger;
        }

        [HttpGet]
        public async Task<IActionResult> GetStringAsync(System.Threading.CancellationToken cancellationToken)
        {
            try
            {
                _iLogger.LogInformation("istek Basşladı");
                await Task.Delay(5000);
                cancellationToken.ThrowIfCancellationRequested();
                var taskResult = new HttpClient().GetStringAsync("https://www.google.com");
                var result = await taskResult;
                _iLogger.LogInformation("istek bitt " + result.Length);

                return Ok(result.First());

            }
            catch (TaskCanceledException e)
            {
                _iLogger.LogInformation(e.Source);
                return BadRequest();
            }
            catch (OperationCanceledException oe)
            {
                _iLogger.LogInformation(oe.Source);
                return BadRequest();
            }

            

        }
    }
}
