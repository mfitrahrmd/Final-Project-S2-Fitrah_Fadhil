using API.Repositories.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoreController<TRepository, TPk, TEntity> : ControllerBase
    where TRepository : IBaseRepository<TPk, TEntity>
    where TEntity : class, IEntity<TPk>
{
    protected readonly TRepository _repository;
    protected readonly IMapper _mapper;

    public CoreController(TRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> GetAsync()
    {
        var entities = await _repository.FindAll();

        return Ok(entities);
    }

    [HttpGet("{pk}")]
    public async Task<ActionResult> GetAsync(TPk pk)
    {
        var entity = await _repository.FindOneByPk(pk);

        return Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync(TEntity entity)
    {
        var insertedEntity = await _repository.InsertOne(entity);

        return Created("", insertedEntity);
    }

    [HttpPut("{pk}")]
    public async Task<ActionResult> PutAsync(TPk pk, TEntity entity)
    {
        var updatedEntity = await _repository.UpdateOneByPk(pk, entity);

        return Ok(updatedEntity);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAsync(TPk pk)
    {
        var deletedEntity = await _repository.DeleteOneByPk(pk);

        return Ok(deletedEntity);
    }
}