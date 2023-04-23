using API.Models;
using API.Repositories.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfilingsController : CoreController<IProfilingRepository, string, TbTrProfiling>
{
    public ProfilingsController(IProfilingRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}