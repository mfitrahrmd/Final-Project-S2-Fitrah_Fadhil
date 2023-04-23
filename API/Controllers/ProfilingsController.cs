using API.DTOs;
using API.DTOs.request;
using API.Models;
using API.Repositories.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfilingsController : CoreController<IProfilingRepository, string, TbTrProfiling, ProfilingDTO, InsertProfilingRequest, UpdateProfilingRequest>
{
    public ProfilingsController(IProfilingRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}