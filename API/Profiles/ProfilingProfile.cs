using API.DTOs;
using API.DTOs.request;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class ProfilingProfile : Profile
{
    public ProfilingProfile()
    {
        CreateMap<Profiling, ProfilingDTO>();
        CreateMap<InsertProfilingRequest, Profiling>();
        CreateMap<UpdateProfilingRequest, Profiling>();
    }
}