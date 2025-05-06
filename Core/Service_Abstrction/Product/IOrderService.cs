using Shared.DTO.Order;

namespace Service_Abstrction.Product
{
    public interface IOrderService
    {
        #region Create Order
        //Create Order
        //Will Take Basket Id, Shipping Address , Delivery Method Id , Customer Email (Done)
        //And Return Order Details
        //(Id , UserEmail , OrderDate ,
        //Items (Product Name - Picture Url - Price - Quantity)
        //, Address , Delivery Method Name , Order Status Value , Sub Total, Total Price
        //)
        Task<OrderToReturnDTO> CreateOrderAsync(OrderDTO orderDTO, string Email);
        #endregion

        #region Get Delivery Method End Point 
        Task<IEnumerable<DelivaryMethodDTO>> GetDelivaryMethodAsync();
        #endregion

        #region Get All Orders End Point 
        Task<IEnumerable<OrderToReturnDTO>> AllOrderAsync(string Email);
        #endregion

        #region Get Order by Id End Point 
        Task<OrderToReturnDTO> GetOrderByIdAsync(Guid id);
        #endregion

    }
}
