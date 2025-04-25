using AutoMapper;
using Domain_Layer.Contract;
using Domain_Layer.Exceptions;
using Domain_Layer.Models.Basket;
using Service_Abstrction.Product;
using Shared.DTO.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Implemention.Basket
{
    public class BasketService(IBasketReposatiry _basketReposatiry, IMapper _mapper) : IBasketService
    {
        #region DeleteBasketAsync
        public async Task<bool> DeleteBasketAsync(string key) => await _basketReposatiry.DeleteUserBasketAsync(key);

        #endregion

        #region GetUserBasketAsync
        public async Task<CustomerBasketDTO> GetUserBasketAsync(string key)
        {
           var Basket = await _basketReposatiry.GetUserBasketAsync(key);
            if (Basket is not null)
               return _mapper.Map<CustomerBasket, CustomerBasketDTO>(Basket);
            else
                throw new BasketNotFoundException(key);
        }
        #endregion

        #region CreateOrUpdateAsync
        public async Task<CustomerBasketDTO> CreateOrUpdateAsync(CustomerBasketDTO basket)
        {
            var Basket = _mapper.Map<CustomerBasketDTO, CustomerBasket>(basket);
            var CustomerBasket = await _basketReposatiry.CreateUpdateUserBasketAsync(Basket);
            if (CustomerBasket is not null)
            {
                return await GetUserBasketAsync(basket.Id);
            }
            else
            {
                throw new Exception("Can Not Create or Update now , Try letteer");
            }
        }
        #endregion
    }
}
