using API.DTOs;
using API.DTOs.request;
using API.DTOs.response;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class UniversityProfile : Profile
{
    public UniversityProfile()
    {
        CreateMap<University, UniversityDTO>();
        CreateMap<InsertUniversityRequest, University>();
        CreateMap<UpdateUniversityRequest, University>();
    }
}