using API.Models;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversityController : CoreController<IUniversityRepository, int, TbMUniversity>
{
    public UniversityController(IUniversityRepository repository) : base(repository)
    {
    }
}