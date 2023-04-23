using API.DTOs;
using API.DTOs.request;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<TbMAccount, AccountDTO>();
        CreateMap<InsertAccountRequest, TbMAccount>();
        CreateMap<UpdateAccountRequest, TbMAccount>();
    }
}