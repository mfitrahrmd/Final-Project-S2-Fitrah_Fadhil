using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class ProfilingProfile : Profile
{
    public ProfilingProfile()
    {
        CreateMap<TbTrProfiling, ProfilingDTO>();
    }
}