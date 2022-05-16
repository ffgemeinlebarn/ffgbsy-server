using ffg.BSY.Data;
using Microsoft.AspNetCore.Mvc;

namespace ffg.BSY.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AufnehmerController : ControllerBase
{
    private readonly ILogger<StatusController> logger;
    private readonly DataContext dataContext;

    public AufnehmerController(ILogger<StatusController> logger, DataContext dataContext)
    {
        this.logger = logger;
        this.dataContext = dataContext;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var aufnehmer = this.dataContext.Aufnehmers.SingleOrDefault(a => a.Id == id);
        return new JsonResult(aufnehmer);
    }
}