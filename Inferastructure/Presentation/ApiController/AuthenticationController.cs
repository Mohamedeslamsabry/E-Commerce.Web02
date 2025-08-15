using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service_Abstrction.Product;
using Shared.DTO.Identity;
using System.Security.Claims;

namespace Presentation.ApiController
{
    public class AuthenticationController(IServiceManger _serviceManger) : ApiBaseController
    {
        #region Login
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var Result = await _serviceManger.authenticationService.LoginAsync(loginDTO);
            return Ok(Result);
        }
        #endregion

        #region Register
        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO register)
        {
            var Result = await _serviceManger.authenticationService.RegisterAsync(register);
            return Ok(Result);
        }
        #endregion

        #region CheckEmail
        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmail(string email)
        {
            var Result = await _serviceManger.authenticationService.CheckEmailAsync(email);
            return Ok(Result);
        }
        #endregion

        #region Get Current User
        [Authorize]
        [HttpGet("CurrentUser")]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var Result = await _serviceManger.authenticationService.GetCurrentUserAsync(Email!);
            return Ok(Result);
        }
        #endregion

        #region GetCurrentUserAddress
        [Authorize]
        [HttpGet("Address")]
        public async Task<ActionResult<AddressDTO>> GetCurrentUserAddress()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var Address = await _serviceManger.authenticationService.GetCurrentUserAddressAsync(Email!);
            return Ok(Address);
        }
        #endregion

        #region UpdateAddress
        [HttpPut("Address")]
        public async Task<ActionResult<AddressDTO>> UpdateAddress(AddressDTO addressDTO)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var address = await _serviceManger.authenticationService.UpdateAddressAsync(Email!, addressDTO);
            return Ok(address);
        } 
        #endregion
    }
}
