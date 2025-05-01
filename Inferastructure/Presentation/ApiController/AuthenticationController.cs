using Microsoft.AspNetCore.Mvc;
using Service_Abstrction.Product;
using Shared.DTO.Identity;

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

    }
}
