using API.DTOs;
using API.DTOs.request;
using API.Models;
using API.Repositories.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountRolesController : CoreController<IAccountRoleRepository, int, AccountRole, AccountRoleDTO, InsertAccountRoleRequest, UpdateAccountRoleRequest>
{
    public AccountRolesController(IAccountRoleRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}