using Microsoft.AspNetCore.Mvc;

namespace ffg.BSY.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StatusController : ControllerBase
{
    private readonly ILogger<StatusController> _logger;

    public StatusController(ILogger<StatusController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Status")]
    public IActionResult Status()
    {
        return Content(DateTime.Now.ToUniversalTime().ToString("o"));
    }
}