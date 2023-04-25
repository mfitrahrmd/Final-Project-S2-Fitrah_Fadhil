using API.DTOs;
using API.DTOs.request;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class AccountRoleProfile : Profile
{
    
    public AccountRoleProfile()
    {
        CreateMap<AccountRole, AccountRoleDTO>();
        CreateMap<InsertAccountRoleRequest, AccountRole>();
        CreateMap<UpdateAccountRoleRequest, AccountRole>();
    }
}