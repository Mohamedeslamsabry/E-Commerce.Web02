using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Service_Abstrction.Product;
using Shared.DTO.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ApiController
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController(IServiceManger _serviceManger) : ControllerBase
    {
        #region Get User Basket 
        [HttpGet]
        public async Task<ActionResult<CustomerBasketDTO>> GetUserBasket(string key)
        {
          var Basket = await _serviceManger.BasketService.GetUserBasketAsync(key);
            return Ok(Basket);
        }

        #endregion

        #region Delete User Basket 
        [HttpDelete("{key}")]
        public async Task<ActionResult<bool>> DeleteUserBasket(string key)
        {
            var Basket = await _serviceManger.BasketService.DeleteBasketAsync(key);
            return Ok(Basket);
        }
        #endregion

        #region Create Or Update User basket
        [HttpPost]
        public async Task<ActionResult<CustomerBasketDTO>> CreateOrUpdateUserBasket(CustomerBasketDTO basket)
        {
            var Basket = await _serviceManger.BasketService.CreateOrUpdateAsync(basket);
            return Ok(Basket);
        }


        #endregion
    }
}
