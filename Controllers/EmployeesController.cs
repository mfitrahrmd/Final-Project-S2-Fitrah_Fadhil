using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;
using DTS_Web_Api.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DTS_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : GeneralController<Employee, IEmployeeRepository, string>

    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IProfilingRepository _profilingRepository;
        public EmployeesController(IEmployeeRepository repository, 
                                    IUniversityRepository universityRepository,
                                    IEducationRepository educationRepository,
                                    IProfilingRepository profilingRepository) : base(repository)
        {
            _universityRepository = universityRepository;
            _educationRepository = educationRepository;
            _profilingRepository = profilingRepository;
        }

        [HttpGet("master")]
        public async Task<IActionResult> Master()
        {
            var employees = _repository.GetAllAsync().Result;
            var universtiy = _universityRepository.GetAllAsync().Result;
            var education = _educationRepository.GetAllAsync().Result;
            var profiling = await _profilingRepository.GetAllAsync();

            try
            {
                var result = from e in employees
                             join p in profiling on e.Nik equals p.Id
                             join ed in education on p.EducationId equals ed.Id
                             join u in universtiy on ed.UniversityId equals u.Id
                             select new
                             {
                                 e.Nik,
                                 e.FirstName,
                                 e.LastName,
                                 e.BirthDate,
                                 e.Gender,
                                 e.HiringDate,
                                 e.Email,
                                 e.PhoneNumber,
                                 ed.Major,
                                 u.Name
                             };

                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    message = "Succes Request",
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
