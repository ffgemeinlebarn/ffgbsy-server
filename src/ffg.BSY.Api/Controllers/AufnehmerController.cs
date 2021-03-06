using ffg.BSY.Data;
using ffg.BSY.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ffg.BSY.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AufnehmerController : ControllerBase
{
    private readonly ILogger<AufnehmerController> logger;
    private readonly RepositoryContext repository;

    public AufnehmerController(ILogger<AufnehmerController> logger, RepositoryContext repository)
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
        return new JsonResult(this.repository.Aufnehmer.Create(entity));
    }

    [HttpPut("{id}")]
    public IActionResult Put([FromBody] AufnehmerDto entity)
    {
        return new JsonResult(this.repository.Aufnehmer.Update(entity));
    }

    [HttpPut("{id}/Activate")]
    public IActionResult Activate(int id)
    {
        var success = this.repository.Aufnehmer.Activate(id);
        return success ? new OkResult() : new BadRequestResult();
    }

    [HttpPut("{id}/Deactivate")]
    public IActionResult Deactivate(int id)
    {
        var success = this.repository.Aufnehmer.Deactivate(id);
        return success ? new OkResult() : new BadRequestResult();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var success = this.repository.Aufnehmer.Delete(id);
        return success ? new OkResult() : new BadRequestResult();
    }
}
