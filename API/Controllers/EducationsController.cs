using API.DTOs;
using API.DTOs.request;
using API.Models;
using API.Repositories.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize(Policy = "ViewOnlyUser")] // user can only access controller with 'GET' method
[Route("api/[controller]")]
[ApiController]
public class EducationsController : CoreController<IEducationRepository, int, TbMEducation, EducationDTO, InsertEducationRequest, UpdateEducationRequest>
{
    public EducationsController(IEducationRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}