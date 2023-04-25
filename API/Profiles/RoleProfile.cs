using API.DTOs;
using API.DTOs.request;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<Role, RoleDTO>();
        CreateMap<InsertRoleRequest, Role>();
        CreateMap<UpdateRoleRequest, Role>();
    }
}