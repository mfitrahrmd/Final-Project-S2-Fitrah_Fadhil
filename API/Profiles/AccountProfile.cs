using API.DTOs;
using API.DTOs.request;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Account, AccountDTO>();
        CreateMap<InsertAccountRequest, Account>();
        CreateMap<UpdateAccountRequest, Account>();
    }
}