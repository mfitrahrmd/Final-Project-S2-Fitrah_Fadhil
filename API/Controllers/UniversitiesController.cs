using API.Models;
using API.Repositories.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversitiesController : CoreController<IUniversityRepository, int, TbMUniversity>
{
    public UniversitiesController(IUniversityRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}