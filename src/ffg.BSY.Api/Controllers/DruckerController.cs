using ffg.BSY.Data;
using ffg.BSY.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ffg.BSY.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DruckerController : ControllerBase
{
    private readonly ILogger<DruckerController> logger;
    private readonly RepositoryContext repository;

    public DruckerController(ILogger<DruckerController> logger, RepositoryContext repository)
    {
        this.logger = logger;
        this.repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(this.repository.Drucker.Read().AsEnumerable());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var drucker = this.repository.Drucker.Read(id);
        return drucker is null ? new NotFoundResult() : new JsonResult(drucker);
    }

    [HttpPost]
    public IActionResult Create([FromBody] DruckerDto entity)
    {
        return new JsonResult(this.repository.Drucker.Create(entity));
    }

    [HttpPut("{id}")]
    public IActionResult Put([FromBody] DruckerDto entity)
    {
        return new JsonResult(this.repository.Drucker.Update(entity));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var success = this.repository.Drucker.Delete(id);
        return success ? new OkResult() : new BadRequestResult();
    }
}
