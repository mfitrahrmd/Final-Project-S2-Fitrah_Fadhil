using API.Models;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController : CoreController<IRoleRepository, int, TbMRole>
{
    public RolesController(IRoleRepository repository) : base(repository)
    {
    }
}