using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.Interfaces;

namespace Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;

        public AccountService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.UserName);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDTO.Password))
                return null;

            return user;
        }

        public async Task<IdentityResult> Register(string userName, string eMail, string password)
        {
            var member = new User
            {
                UserName = userName,
                Email = eMail
            };

            var result= await _userManager.CreateAsync(member, password);

            await _userManager.AddToRoleAsync(member, "Member");

            return result;
        }

        public async Task AddToRole(User member, string role)
        {
            await _userManager.AddToRoleAsync(member, "Member");
        }

        public async Task<IReadOnlyList<User>> GetUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<User> GetCurrentUser(string name)
        {
            return await _userManager.FindByNameAsync(name);
        }

        public async Task<User> GetUserAsync(string name)
        {
            return await _userManager.Users
            .Include(u => u.Address)
            .FirstOrDefaultAsync(x => x.UserName == name);
        }

        public async Task<UserAddress> GetSavedAddress(string name)
        {
            return await _userManager.Users
                .Where(x => x.UserName == name)
                .Select(user => user.Address)
                .FirstOrDefaultAsync();
        }
    }
}