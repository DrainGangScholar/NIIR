using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Services.DTO;

namespace Services.Interfaces
{
    public interface IAccountService
    {
        public Task<IReadOnlyList<User>> GetUsersAsync();
        public Task<IdentityResult> Register(string userName, string eMail, string password);
        public Task<User> Login(LoginDTO loginDTO);
        public Task AddToRole(User member, string role);
        public Task<User> GetCurrentUser(string name);
        public Task<User> GetUserAsync(string name);
        public Task<UserAddress> GetSavedAddress(string name);
    }
}