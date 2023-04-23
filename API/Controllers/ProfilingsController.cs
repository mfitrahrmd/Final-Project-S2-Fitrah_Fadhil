using API.DTOs;
using API.DTOs.request;
using API.DTOs.response;
using API.Models;
using API.Repositories.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfilingsController : CoreController<IProfilingRepository, string, TbTrProfiling, ProfilingDTO, InsertProfilingRequest, UpdateProfilingRequest>
{
    private readonly IEmployeeRepository _employeeRepository;
    
    public ProfilingsController(IProfilingRepository repository, IEmployeeRepository employeeRepository, IMapper mapper) : base(repository, mapper)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet("avggpa/{year}")]
    public async Task<IActionResult> Get(int year)
    {
        var employees = await _employeeRepository.FindManyByAboveAvgGpaAndHiringYear(year);

        return Ok(_mapper.Map<IEnumerable<EmployeesAboveAvgGpaAndHiringYearResponse>>(employees));
    }
}