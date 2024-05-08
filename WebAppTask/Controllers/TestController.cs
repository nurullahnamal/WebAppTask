using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;


namespace WebAppTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("Sync")]
        public IActionResult Get()
        {
            Thread.Sleep(1000); 
            return Ok();
        }

        [HttpGet]
        [Route("Async")]
        public async Task< IActionResult> GetAsync()
        {
           await Task.Delay(1000);
            return Ok();
        }

    }
}
