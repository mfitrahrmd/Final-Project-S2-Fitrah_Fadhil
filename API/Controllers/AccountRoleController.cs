using API.Models;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountRoleController : CoreController<IAccountRoleRepository, int, TbTrAccountRole>
{
    public AccountRoleController(IAccountRoleRepository repository) : base(repository)
    {
    }
}