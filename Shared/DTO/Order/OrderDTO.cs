using Shared.DTO.Identity;

namespace Shared.DTO.Order
{
    public class OrderDTO
    {
        public string BasketId { get; set; } = null!;
        public AddressDTO Address { get; set; } = null!;
        public int DeliveryMethodId { get; set; }
    }
}
    