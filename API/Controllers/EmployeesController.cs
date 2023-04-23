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
public class EmployeesController : CoreController<IEmployeeRepository, string, TbMEmployee, EmployeeDTO, InsertEmployeeRequest, UpdateEmployeeRequest>
{
    public EmployeesController(IEmployeeRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    [HttpGet("master")]
    public async Task<IActionResult> Get()
    {
        var employees = await _repository.FindManyIncludeEducationAndUniversityAsync();

        var employeesMasterResponse = _mapper.Map<IEnumerable<EmployeesMasterResponse>>(employees);
        
        return Ok(employeesMasterResponse);
    }
}