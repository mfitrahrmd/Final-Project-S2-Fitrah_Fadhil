using API.DTOs;
using API.DTOs.response;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class UniversityProfile : Profile
{
    public UniversityProfile()
    {
        CreateMap<TbMUniversity, UniversityDTO>();
    }
}