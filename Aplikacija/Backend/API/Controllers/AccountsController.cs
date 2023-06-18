using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.ExternalServices;
using Services.Implementations;
using Services.Interfaces;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _service;
        private readonly TokenService _token;
        public AccountController(IAccountService service, TokenService token)
        {
            _service = service;

            _token = token;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("Users")]
        public async Task<IReadOnlyList<User>> GetUsers()
        {
            return await _service.GetUsersAsync();
        }
        [Authorize]
        [HttpGet("currentUser")]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var user = await _service.GetCurrentUser(User.Identity.Name);

            return new UserDTO
            {
                Email = user.Email,
                Token = await _token.GenerateToken(user)
            };
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDTO registerDTO)
        {

            var result = await _service.Register(registerDTO.UserName, registerDTO.Email, registerDTO.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return ValidationProblem();
            }

            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var result = await _service.Login(loginDTO);

            if (result == null)
                return Unauthorized("Pogrešno korisničko ime ili lozinka");

            return new UserDTO
            {
                Email = result.Email,
                Token = await _token.GenerateToken(result)
            };
        }
        [Authorize]
        [HttpGet("savedAddress")]
        public async Task<ActionResult<UserAddress>> GetSavedAddress()
        {
            return await _service.GetSavedAddress(User.Identity.Name);
        }
    }
}
