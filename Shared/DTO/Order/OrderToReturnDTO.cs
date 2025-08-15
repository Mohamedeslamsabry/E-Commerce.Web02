using Shared.DTO.Identity;

namespace Shared.DTO.Order
{
    public class OrderToReturnDTO
    {
        public Guid Id { get; set; }
        public DateTimeOffset buyerEmail { get; set; }
        public ICollection<OrderItemDTO> Items { get; set; } = [];   
        public AddressDTO shipToAddress { get; set; } = null!;
        public string status { get; set; } = null!;
        public string deliveryMethod { get; set; } = null!;
        public decimal deliveryCost { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
