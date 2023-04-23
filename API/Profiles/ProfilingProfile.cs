using API.DTOs;
using API.DTOs.request;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class ProfilingProfile : Profile
{
    public ProfilingProfile()
    {
        CreateMap<TbTrProfiling, ProfilingDTO>();
        CreateMap<InsertProfilingRequest, TbTrProfiling>();
        CreateMap<UpdateProfilingRequest, TbTrProfiling>();
    }
}