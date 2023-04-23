using API.DTOs;
using API.DTOs.request;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class AccountRoleProfile : Profile
{
    
    public AccountRoleProfile()
    {
        CreateMap<TbTrAccountRole, AccountRoleDTO>();
        CreateMap<InsertAccountRoleRequest, TbTrAccountRole>();
        CreateMap<UpdateAccountRoleRequest, TbTrAccountRole>();
    }
}