using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.Basket
{
    public class BasketItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PictureUrl { get; set; } = null!;
        [Range(1,int.MaxValue)]
        public decimal Price { get; set; }
        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}
