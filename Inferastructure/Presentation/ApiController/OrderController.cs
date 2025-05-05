using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service_Abstrction.Product;
using Shared.DTO.Order;
using System.Security.Claims;

namespace Presentation.ApiController
{
    public class OrderController(IServiceManger _serviceManger) : ApiBaseController
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<OrderToReturnDTO>> CreateOrder(OrderDTO orderDTO)
        {
            //var Email = User.FindFirstValue(ClaimTypes.Email);
            var Result = await _serviceManger.orderService.CreateOrder(orderDTO, GetEmailFromToken());
            return Ok(Result);
        }
    }
}
