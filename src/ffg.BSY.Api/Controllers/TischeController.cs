using ffg.BSY.Data;
using ffg.BSY.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ffg.BSY.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TischeController : ControllerBase
{
    private readonly ILogger<TischeController> logger;
    private readonly RepositoryContext repository;

    public TischeController(ILogger<TischeController> logger, RepositoryContext repository)
    {
        this.logger = logger;
        this.repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(this.repository.Tische.Read().AsEnumerable());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var tisch = this.repository.Tische.ReadWithKategorie(id);
        return tisch is null ? new NotFoundResult() : new JsonResult(tisch);
    }

    [HttpPost]
    public IActionResult Create([FromBody] TischDto entity)
    {
        return new JsonResult(this.repository.Tische.Create(entity));
    }

    [HttpPut("{id}")]
    public IActionResult Put([FromBody] TischDto entity)
    {
        return new JsonResult(this.repository.Tische.Update(entity));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var success = this.repository.Tische.Delete(id);
        return success ? new OkResult() : new BadRequestResult();
    }
}
