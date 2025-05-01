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

        //Check Email Endpoint
        //Will Take Email Then Return boolean To Client  
        Task<bool> CheckEmailAsync(string email);

        //Get Current User Address Endpoint
        //Will Take Email Then Return Address of Current Logged in User To Client  
        Task<AddressDTO> GetCurrentUserAddressAsync(string email);

        //Update Current User Address Endpoint
        //Will Handle Updating User Address Take Updated Address and Email Then Return Address after Update To Client  
        Task<AddressDTO> UpdateAddressAsync(string email, AddressDTO addressDTO);

        //Get Current User Endpoint
        //Will Take Email Then Return Token , Email and Display Name To Client  
        Task<UserDTO> GetCurrentUserAsync(string email);





    }
}
