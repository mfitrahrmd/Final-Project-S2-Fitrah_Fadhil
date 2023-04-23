using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<TbMRole, RoleDTO>();
    }
}