using API.DTOs;
using API.DTOs.request;
using API.DTOs.response;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDTO>();
        CreateMap<Employee, EmployeesMasterResponse>()
            .ForMember(dest => dest.Education, opt => opt.MapFrom(src => src.TbTrProfiling.Education))
            .ForMember(dest => dest.University, opt => opt.MapFrom(src => src.TbTrProfiling.Education.University));
        CreateMap<InsertEmployeeRequest, Employee>();
        CreateMap<UpdateEmployeeRequest, Employee>();
        CreateMap<Employee, EmployeesAboveAvgGpaAndHiringYearResponse>()
            .ForMember(dest => dest.Education, opt => opt.MapFrom(src => src.TbTrProfiling.Education))
            .ForMember(dest => dest.University, opt => opt.MapFrom(src => src.TbTrProfiling.Education.University));
    }
}