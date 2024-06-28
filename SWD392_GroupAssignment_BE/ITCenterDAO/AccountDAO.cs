﻿using AutoMapper;
using ITCenterBO.Models;
using ITCenterBO.Paginate;
using ITCenterBO.DTOs.Request.Account;
using ITCenterBO.DTOs.Response.Account;
using ITCenterDAO.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ITCenterBO.DTOs.Response.Authentication;
using ITCenterBO.DTOs.Request.Authentication;
using Microsoft.AspNetCore.Http;

namespace ITCenterDAO
{
    public class AccountDAO
    {
        private readonly ITCenterContext _dbContext = null;
        private readonly IMapper _mapper;

        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }

        public AccountDAO()
        {
            if (_dbContext == null)
                _dbContext = new ITCenterContext();
            if (_mapper == null)
                _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new AccountMapper())).CreateMapper().ConfigurationProvider);
        }

        #region AccountFunction
        public async Task<IPaginate<GetAccountResponse>> GetAllAccounts(int page, int size)
        {
            IPaginate<GetAccountResponse> accountList = await _dbContext.Accounts.Select(x => new GetAccountResponse
            {
                AccountId = x.AccountId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                IsActive = x.IsActive,
                Role = x.Role.RoleName
            }).Where(x => x.IsActive == true).ToPaginateAsync(page, size, 1);
            return accountList;
        }

        public async void CreateAccount(CreateAccountRequest createAccountRequest)
        {
            Account account = _dbContext.Accounts.FirstOrDefault(x => x.Email.Equals(createAccountRequest.Email));

            if (account == null)
            {
                _dbContext.Accounts.Add(_mapper.Map<Account>(createAccountRequest));
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<UpdateAccountResponse> UpdateAccountInformation(int id, UpdateAccountRequest updateAccountRequest)
        {
            Account account = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);

            if (account != null)
            {
                account.FirstName = string.IsNullOrEmpty(updateAccountRequest.FirstName) ?
                                    account.FirstName : updateAccountRequest.FirstName;
                account.LastName = string.IsNullOrEmpty(updateAccountRequest.LastName) ?
                                    account.LastName : updateAccountRequest.LastName;
                account.Email = string.IsNullOrEmpty(updateAccountRequest.Email) ?
                                    account.Email : updateAccountRequest.Email;
                account.Address = string.IsNullOrEmpty(updateAccountRequest.Address) ?
                                    account.Address : updateAccountRequest.Address;
                account.Phone = string.IsNullOrEmpty(updateAccountRequest.Phone) ?
                                    account.Phone : updateAccountRequest.Phone;
                account.DigitalSignature = string.IsNullOrEmpty(updateAccountRequest.DigitalSignature) ?
                                    account.DigitalSignature : updateAccountRequest.DigitalSignature;
                account.BirthDate = updateAccountRequest.BirthDate;

                _dbContext.Accounts.Update(account);
                await _dbContext.SaveChangesAsync();

                UpdateAccountResponse response = _mapper.Map<UpdateAccountResponse>(account);
                return response;
            }

            return null;
        }

        public async Task<bool> ChangeAccountStatus(int id)
        {
            Account account = _dbContext.Accounts.FirstOrDefault(x => x.AccountId == id);

            if (account != null)
            {
                _dbContext.Entry(account).Property("IsActive").CurrentValue = !account.IsActive;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion

        #region AuthenticationFunction
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            Account account = await _dbContext.Accounts.Include(p => p.Role)
                                                       .FirstOrDefaultAsync(x => x.Email.Equals(loginRequest.Email) &&
                                                                                 x.Password.Equals(loginRequest.Password));

            if (account == null) return null;
            LoginResponse response = new LoginResponse(account.AccountId, account.Email, account.FirstName,
                                                       account.Role.RoleName, account.IsActive);

            var token = Utils.GenerateJwtToken(account);
            response.AccessToken = token;
            return response;
        }

        public async Task<LoginResponse> SignUp(SignUpRequest signUpRequest)
        {
            Account account = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Email.Equals(signUpRequest.Email));
            if (account != null) throw new BadHttpRequestException("Already Used Email");

            Account newAccount = new Account()
            {
                AccountId = 0,
                RoleId = 3,
                FirstName = string.Empty,
                LastName = string.Empty,
                BirthDate = DateTime.Now,
                Email = signUpRequest.Email,
                Gender = true,
                Address = String.Empty,
                Phone = String.Empty,
                DigitalSignature = String.Empty,
                Password = signUpRequest.Password,
                IsActive = true,
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now,
            };

            _dbContext.Accounts.Add(newAccount);
            await _dbContext.SaveChangesAsync();

            //Login
            Account createdAccount = await _dbContext.Accounts.Include(p => p.Role)
                                                              .FirstOrDefaultAsync(x => x.Email.Equals(newAccount.Email) &&
                                                                                        x.Password.Equals(newAccount.Password));

            LoginResponse response = new LoginResponse(createdAccount.AccountId, createdAccount.Email, createdAccount.FirstName,
                                                       createdAccount.Role.RoleName, createdAccount.IsActive);

            var token = Utils.GenerateJwtToken(createdAccount);
            response.AccessToken = token;
            return response;
        }
        #endregion
    }
}
