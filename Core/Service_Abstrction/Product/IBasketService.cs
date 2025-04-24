using Shared.DTO.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Abstrction.Product
{
    public interface IBasketService
    {
        //Delete User Basket
        Task<bool> DeleteBasketAsync(string key);
        //Get User Basket
        Task<CustomerBasketDTO> GetUserBasketAsync(string key);
        //Create Or Update User Basket
        Task<CustomerBasketDTO> CreateOrUpdateAsync(CustomerBasketDTO basket);
    }
}
