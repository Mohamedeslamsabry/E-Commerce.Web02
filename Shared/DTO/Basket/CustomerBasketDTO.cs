using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.Basket
{
    public class CustomerBasketDTO
    {
        public string Id { get; set; } = null!; // GUID (Front End Send)
        public ICollection<BasketItemDTO> Items { get; set; } = [];
        public string? clientSecret { get; set; }
        public string? paymentIntentId { get; set; }
        public int? deliveryMethodId { get; set; }
        public decimal? shippingPrice { get; set; }
    }

}
