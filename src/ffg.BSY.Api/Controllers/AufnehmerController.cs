using ffg.BSY.Data;
using ffg.BSY.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ffg.BSY.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AufnehmerController : ControllerBase
{
    private readonly ILogger<StatusController> logger;
    private readonly RepositoryContext repository;

    public AufnehmerController(ILogger<StatusController> logger, RepositoryContext repository)
    {
        this.logger = logger;
        this.repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(this.repository.Aufnehmer.Read().AsEnumerable());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var aufnehmer = this.repository.Aufnehmer.Read(id);
        return aufnehmer is null ? new NotFoundResult() : new JsonResult(aufnehmer);
    }

    [HttpPost]
    public IActionResult Create([FromBody] AufnehmerDto entity)
    {
        var aufnehmer = this.repository.Aufnehmer.Create(entity);
        return new JsonResult(aufnehmer);
    }

    [HttpPut("{id}")]
    public IActionResult Put([FromBody] AufnehmerDto entity)
    {
        var aufnehmer = this.repository.Aufnehmer.Update(entity);
        return new JsonResult(aufnehmer);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var success = this.repository.Aufnehmer.Delete(id);
        return success ? new OkResult() : new BadRequestResult();
    }
}