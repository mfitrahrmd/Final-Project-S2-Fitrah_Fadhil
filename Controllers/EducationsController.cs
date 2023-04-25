using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DTS_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "MethodGetForUser")]
    public class EducationsController : GeneralController<Education,IEducationRepository, int>

    {
        public EducationsController(IEducationRepository repository) : base(repository)
        {
        }        
    }
}
