using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class AccountRoleProfile : Profile
{
    
    public AccountRoleProfile()
    {
        CreateMap<TbTrAccountRole, AccountRoleDTO>();
    }
}