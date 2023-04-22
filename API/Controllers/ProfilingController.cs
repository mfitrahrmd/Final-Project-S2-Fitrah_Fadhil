using API.Models;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfilingController : CoreController<IProfilingRepository, string, TbTrProfiling>
{
    public ProfilingController(IProfilingRepository repository) : base(repository)
    {
    }
}