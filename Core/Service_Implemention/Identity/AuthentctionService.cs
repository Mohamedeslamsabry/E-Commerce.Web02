using Domain_Layer.Exceptions;
using Domain_Layer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service_Abstrction.Product;
using Shared.DTO.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service_Implemention.Identity
{
    class AuthentctionService(UserManager<ApplicationUser> _userManager , IConfiguration _configuration) : IAuthenticationService
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
                    Token = await GenerateTokenAsync(User)
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
                    Token = await GenerateTokenAsync(User)
                };
            }

            else // Occures ModelState error Example Passowrd not Correct Microsoft configraution
            {
                var Errors = Result.Errors.Select(E => E.Description).ToList();
                throw new BadRequestException(Errors);
            }
        }

        private async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            #region Payload (Claim)
            var Clamis = new List<Claim>()
            {
                new (ClaimTypes.Email, user.Email!),
                new (ClaimTypes.Name, user.UserName!),
                new (ClaimTypes.NameIdentifier, user.Id),
            };

            var Roles = await _userManager.GetRolesAsync(user);
            foreach (var role in Roles)
                Clamis.Add(new Claim(ClaimTypes.Role, role));
            #endregion

            var SecritKey = _configuration.GetSection("JWTOptions")["SecritKey"];
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecritKey!));

            var Credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken
                            (
                               issuer: _configuration["SecritKey:issuer"], //Claim
                               audience: _configuration["SecritKey:audience"],//Claim
                               expires: DateTime.Now.AddHours(1),//Claim
                               claims: Clamis,//Claim
                               signingCredentials: Credentials
                            );
            var returnToken = new JwtSecurityTokenHandler().WriteToken(Token);
            return returnToken;
        }
    }
}
