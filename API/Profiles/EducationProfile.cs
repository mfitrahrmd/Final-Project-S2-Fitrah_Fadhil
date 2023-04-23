using API.DTOs;
using API.DTOs.response;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class EducationProfile : Profile
{
    public EducationProfile()
    {
        CreateMap<TbMEducation, EducationDTO>();
    }
}