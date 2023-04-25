using API.DTOs;
using API.DTOs.request;
using API.Models;
using API.Repositories.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UniversitiesController : CoreController<IUniversityRepository, int, University, UniversityDTO, InsertUniversityRequest, UpdateUniversityRequest>
{
    public UniversitiesController(IUniversityRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}