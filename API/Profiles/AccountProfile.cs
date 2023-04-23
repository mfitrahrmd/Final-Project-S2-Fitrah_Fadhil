using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<TbMAccount, AccountDTO>();
    }
}