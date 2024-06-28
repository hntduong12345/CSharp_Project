using AutoMapper;
using ITCenterBO.Models;
using ITCenterBO.DTOs.Request.Account;
using ITCenterBO.DTOs.Response.Account;

namespace ITCenterDAO.Mappers
{
    public class AccountMapper : Profile
    {
        public AccountMapper()
        {
            CreateMap<CreateAccountRequest, Account>();
            CreateMap<Account, UpdateAccountResponse>();
        }
    }
}
