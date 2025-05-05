using Shared.DTO.Identity;
using Shared.DTO.Order;
using System.Diagnostics;

namespace Service_Abstrction.Product
{
    public interface IOrderService
    {
        //Create Order
        //Will Take Basket Id, Shipping Address , Delivery Method Id , Customer Email (Done)
        //And Return Order Details
        //(Id , UserEmail , OrderDate ,
        //Items (Product Name - Picture Url - Price - Quantity)
        //, Address , Delivery Method Name , Order Status Value , Sub Total, Total Price
        //)
        Task<OrderToReturnDTO> CreateOrder(OrderDTO orderDTO, string Email);
    }
}
