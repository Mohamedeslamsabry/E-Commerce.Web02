using Shared.DTO.Identity;

namespace Shared.DTO.Order
{
    public class OrderToReturnDTO
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; } = null!;
        public DateTimeOffset OrderDate { get; set; }
        public ICollection<OrderItemDTO> Items { get; set; } = [];   
        public AddressDTO Address { get; set; } = null!;
        public string State { get; set; } = null!;
        public string DeliveryMethodName { get; set; } = null!;
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
