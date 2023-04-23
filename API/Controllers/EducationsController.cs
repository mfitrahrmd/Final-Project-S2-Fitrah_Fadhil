using API.DTOs;
using API.DTOs.request;
using API.Models;
using API.Repositories.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationsController : CoreController<IEducationRepository, int, TbMEducation, EducationDTO, InsertEducationRequest, UpdateEducationRequest>
{
    public EducationsController(IEducationRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}