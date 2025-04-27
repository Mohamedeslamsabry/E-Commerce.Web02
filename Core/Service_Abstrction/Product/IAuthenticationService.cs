using Shared.DTO.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Abstrction.Product
{
    public interface IAuthenticationService
    {
        //Login
        Task<UserDTO> LoginAsync(LoginDTO loginDTO);
        //Register
        Task<UserDTO> RegisterAsync(RegisterDTO registerDTO);
    }
}
