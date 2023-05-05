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
public class ProfilingsController : CoreController<IProfilingRepository, string, Profiling, ProfilingDTO, InsertProfilingRequest, UpdateProfilingRequest>
{
    private readonly IEmployeeRepository _employeeRepository;
    
    public ProfilingsController(IProfilingRepository repository, IEmployeeRepository employeeRepository, IMapper mapper) : base(repository, mapper)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet("avggpa/{year}")]
    public async Task<IActionResult> Get([FromRoute] int year)
    {
        var employees = await _employeeRepository.FindManyByAboveAvgGpaAndHiringYear(year);

        return Ok(_mapper.Map<IEnumerable<EmployeesAboveAvgGpaAndHiringYearResponse>>(employees));
    }

    [HttpGet("totalbymajor")]
    public async Task<IActionResult> Get()
    {
        var result = await _employeeRepository.FindTotalGroupByMajorAndUniversityName();

        return Ok(result);
    }

    [HttpGet("workperiod")]
    public async Task<IActionResult> GetByWorkPeriod()
    {
        var result = await _employeeRepository.FindByWorkPeriod();

        return Ok(_mapper.Map<IEnumerable<EmployeeDTO>>(result));
    }
}