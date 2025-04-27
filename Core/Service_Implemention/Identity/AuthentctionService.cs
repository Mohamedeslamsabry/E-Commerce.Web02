using Domain_Layer.Exceptions;
using Domain_Layer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Service_Abstrction.Product;
using Shared.DTO.Identity;

namespace Service_Implemention.Identity
{
    class AuthentctionService(UserManager<ApplicationUser> _userManager ) : IAuthenticationService
    {
        public async Task<UserDTO> LoginAsync(LoginDTO loginDTO)
        {
            var User = await _userManager.FindByEmailAsync(loginDTO.Email) ?? throw new UserNotFoundException(loginDTO.Email);

            //Check passowrd
            var IsPassowrdValid = await _userManager.CheckPasswordAsync(User, loginDTO.Password);
            if (IsPassowrdValid)
            {
                return new UserDTO()
                {
                    DisplayName = User.DisplayName,
                    Email = User.Email!,
                    Token = GenerateTokenAsync(User)
                };
            }
            else
            {
                throw new UnauthorizedException();
            }

        }

        public async Task<UserDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            var User = new ApplicationUser()
            {
                Email = registerDTO.Email,
                DisplayName = registerDTO.DisplayName,
                UserName = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber
            };

            var Result = await _userManager.CreateAsync(User, registerDTO.Password);

            if (Result.Succeeded)
            {
                return new UserDTO()
                {
                    DisplayName = User.DisplayName,
                    Email = User.Email!,
                    Token = GenerateTokenAsync(User)
                };
            }

            else
            {
                var Errors = Result.Errors.Select(E => E.Description).ToList();
                throw new BadRequestException(Errors);
            }
        }

        private static string GenerateTokenAsync(ApplicationUser user)
        {
            return "TODO";
        }
    }
}
