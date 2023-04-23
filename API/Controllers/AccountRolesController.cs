using API.Models;
using API.Repositories.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountRolesController : CoreController<IAccountRoleRepository, int, TbTrAccountRole>
{
    public AccountRolesController(IAccountRoleRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}