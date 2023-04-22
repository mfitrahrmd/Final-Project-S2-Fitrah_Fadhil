using API.Models;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationsController : CoreController<IEducationRepository, int, TbMEducation>
{
    public EducationsController(IEducationRepository repository) : base(repository)
    {
    }
}