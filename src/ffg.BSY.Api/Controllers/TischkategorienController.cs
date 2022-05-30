using ffg.BSY.Data;
using ffg.BSY.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ffg.BSY.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TischkategorienController : ControllerBase
{
    private readonly ILogger<TischkategorienController> logger;
    private readonly RepositoryContext repository;

    public TischkategorienController(ILogger<TischkategorienController> logger, RepositoryContext repository)
    {
        this.logger = logger;
        this.repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(this.repository.Tischkategorien.Read().AsEnumerable());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var Tischkategorien = this.repository.Tischkategorien.Read(id);
        return Tischkategorien is null ? new NotFoundResult() : new JsonResult(Tischkategorien);
    }

    [HttpPost]
    public IActionResult Create([FromBody] TischkategorieDto entity)
    {
        var Tischkategorien = this.repository.Tischkategorien.Create(entity);
        return new JsonResult(Tischkategorien);
    }

    [HttpPut("{id}")]
    public IActionResult Put([FromBody] TischkategorieDto entity)
    {
        var Tischkategorien = this.repository.Tischkategorien.Update(entity);
        return new JsonResult(Tischkategorien);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var success = this.repository.Tischkategorien.Delete(id);
        return success ? new OkResult() : new BadRequestResult();
    }
}
