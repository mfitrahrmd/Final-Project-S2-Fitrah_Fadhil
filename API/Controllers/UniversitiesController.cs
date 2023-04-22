using API.Models;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversitiesController : CoreController<IUniversityRepository, int, TbMUniversity>
{
    public UniversitiesController(IUniversityRepository repository) : base(repository)
    {
    }
}