using API.Models;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationController : CoreController<IEducationRepository, int, TbMEducation>
{
    public EducationController(IEducationRepository repository) : base(repository)
    {
    }
}