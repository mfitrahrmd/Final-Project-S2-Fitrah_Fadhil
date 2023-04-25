using DTS_Web_Api.Contexts;
using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;
using DTS_Web_Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DTS_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilingsController : GeneralController<Profiling, IProfilingRepository, string>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEducationRepository _educationRepository;
        public ProfilingsController(IProfilingRepository repository, 
                                    IEmployeeRepository employeeRepository,
                                    IEducationRepository educationRepository,
                                    IUniversityRepository universityRepository) 
                                    : base(repository)
        {
            _employeeRepository = employeeRepository;
            _educationRepository = educationRepository;
        }

        [HttpGet("WorkPeriod")]
        public async Task<IActionResult> WorkPeriodAsync()
        {
            try
            {
                var employees = await _employeeRepository.GetAllAsync();
                var result = from e in employees
                             orderby e.HiringDate ascending, e.FirstName descending
                             select e;
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    message = "Request Successfully",
                    data = result
                });
            }
            catch
            {
                return NotFound(new
                {
                    code = StatusCodes.Status404NotFound,
                    status = HttpStatusCode.NotFound.ToString(),
                    data = new
                    {
                        message = "Data Not Found!"
                    }
                });
            }
        }

        [HttpGet("TotalByMajor")]
        public async Task<IActionResult> TotalByMajorAsync()
        {
            try
            {
                var result = await _repository.GetTotalByMajorAsync();  

                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    message = "Request Successfully",
                    data = result
                });
            }
            catch
            {
                return NotFound(new
                {
                    code = StatusCodes.Status404NotFound,
                    status = HttpStatusCode.NotFound.ToString(),
                    data = new
                    {
                        message = "Data Not Found!"
                    }
                });
            }
        }

        [HttpPost("AvgGPA/{tahun}")]
        public async Task<IActionResult> AvgGpaAsync(int tahun)
        {
            try
            {
                var employees = _employeeRepository.GetAllAsync().
                                                    Result.Where(e => e.HiringDate.Year.Equals(tahun));   
                var education = _educationRepository.GetAllAsync().Result;
                var average = _educationRepository.GetAllAsync().
                                                   Result.Select(e => e.Gpa).
                                                   AsEnumerable().
                                                   Average();

                var profiling = await _repository.GetAllAsync();
                var result = from e in employees
                             join p in profiling on e.Nik equals p.Id
                             join ed in education on p.EducationId equals ed.Id
                             where ed.Gpa > average
                             select e;

                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    message = "Request Successfully",
                    data = result
                });
            }
            catch
            {
                return NotFound(new
                {
                    code = StatusCodes.Status404NotFound,
                    status = HttpStatusCode.NotFound.ToString(),
                    data = new
                    {
                        message = "Data Not Found!"
                    }
                });
            }
        }
    }
}
