using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service_Abstrction.Product;
using Shared.DTO.Order;
using System.Security.Claims;

namespace Presentation.ApiController
{
    public class OrderController(IServiceManger _serviceManger) : ApiBaseController
    {
        #region CreateOrder
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<OrderToReturnDTO>> CreateOrder(OrderDTO orderDTO)
        {
            //var Email = User.FindFirstValue(ClaimTypes.Email);
            var Result = await _serviceManger.orderService.CreateOrderAsync(orderDTO, GetEmailFromToken());
            return Ok(Result);
        }
        #endregion

        #region GetDelivaryMethodAsync
        [HttpGet("DelivaryMethods")]
        public async Task<ActionResult<DelivaryMethodDTO>> GetDelivaryMethods()
        {
            var Result = await _serviceManger.orderService.GetDelivaryMethodAsync();
            return Ok(Result);
        }
        #endregion

        #region AllOrderAsync
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderToReturnDTO>>> AllOrderAsync()
        {
            var Result = await _serviceManger.orderService.AllOrderAsync(GetEmailFromToken());
            return Ok(Result);
        }
        #endregion

        #region GetOrderByIdAsync
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDTO>> GetOrderByIdAsync(Guid id)
        {
            var Result = await _serviceManger.orderService.GetOrderByIdAsync(id);
            return Ok(Result);
        }
        #endregion
    }
}
