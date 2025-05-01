using AutoMapper;
using Domain_Layer.Exceptions;
using Domain_Layer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service_Abstrction.Product;
using Shared.DTO.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service_Implemention.Identity
{
    public class AuthentctionService(UserManager<ApplicationUser> _userManager , IConfiguration _configuration , IMapper _mapper) : IAuthenticationService
    {
        #region Login
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
        #endregion

        #region Register
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
        #endregion

        #region Token
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
                               issuer: _configuration.GetSection("JWTOptions")["Issuer"], //Claim
                               audience: _configuration.GetSection("JWTOptions")["Audience"],//Claim
                               claims: Clamis,//Claim
                               expires: DateTime.Now.AddHours(1),//Claim
                               signingCredentials: Credentials
                            );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
        #endregion

        #region Check Email
        public async Task<bool> CheckEmailAsync(string email)
        {
            var User = await _userManager.FindByEmailAsync(email);
            if (User is null)
                return false;
            else
                return true;
        }
        #endregion

        #region GetCurrentUserAsync
        public async Task<UserDTO> GetCurrentUserAsync(string email)
        {
            var User = await _userManager.FindByEmailAsync(email) ?? throw new UserNotFoundException(email);

            return new UserDTO()
            {
                DisplayName = User.DisplayName,
                Email = User.Email!,
                Token = await GenerateTokenAsync(User)
            };

        }
        #endregion

        #region GetCurrentUserAddressAsync
        public async Task<AddressDTO> GetCurrentUserAddressAsync(string email)
        {
            var User = await _userManager.Users.Include(U => U.Address)
                .FirstOrDefaultAsync(U => U.Email == email) ?? throw new UserNotFoundException(email);
            if (User.Address is not null)
                return _mapper.Map<Address, AddressDTO>(User.Address);
            else
                throw new AddressNotFoundException(User.UserName!);
        }
        #endregion


        public async Task<AddressDTO> UpdateAddressAsync(string email, AddressDTO addressDTO)
        {
            var User = await _userManager.Users.Include(U => U.Address)
                .FirstOrDefaultAsync(U => U.Email == email) ?? throw new UserNotFoundException(email);
            if (User.Address is not null) // Update
            {
                User.Address.FirstName = addressDTO.FirstName;
                User.Address.LastName = addressDTO.LastName;
                User.Address.City = addressDTO.City;
                User.Address.Country = addressDTO.Country;
                User.Address.Street = addressDTO.Street;
            }
            else //Add
            {
                User.Address = _mapper.Map<AddressDTO, Address>(addressDTO);
            }
             await _userManager.UpdateAsync(User);

            return _mapper.Map<AddressDTO>(User.Address);
        }
    }
}
