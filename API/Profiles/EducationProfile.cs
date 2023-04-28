using API.DTOs;
using API.DTOs.request;
using API.DTOs.response;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class EducationProfile : Profile
{
    public EducationProfile()
    {
        CreateMap<Education, EducationDTO>();
        CreateMap<InsertEducationRequest, Education>();
        CreateMap<UpdateEducationRequest, Education>();
    }
}