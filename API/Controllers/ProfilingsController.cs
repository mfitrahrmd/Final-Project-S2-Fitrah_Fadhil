using API.Models;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfilingsController : CoreController<IProfilingRepository, string, TbTrProfiling>
{
    public ProfilingsController(IProfilingRepository repository) : base(repository)
    {
    }
}