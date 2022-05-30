using ffg.BSY.Data;
using ffg.BSY.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ffg.BSY.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DruckerController : ControllerBase
{
    private readonly ILogger<StatusController> logger;
    private readonly RepositoryContext repository;

    public DruckerController(ILogger<StatusController> logger, RepositoryContext repository)
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
        var Drucker = this.repository.Drucker.Read(id);
        return Drucker is null ? new NotFoundResult() : new JsonResult(Drucker);
    }

    [HttpPost]
    public IActionResult Create([FromBody] DruckerDto entity)
    {
        var Drucker = this.repository.Drucker.Create(entity);
        return new JsonResult(Drucker);
    }

    [HttpPut("{id}")]
    public IActionResult Put([FromBody] DruckerDto entity)
    {
        var Drucker = this.repository.Drucker.Update(entity);
        return new JsonResult(Drucker);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var success = this.repository.Drucker.Delete(id);
        return success ? new OkResult() : new BadRequestResult();
    }
}