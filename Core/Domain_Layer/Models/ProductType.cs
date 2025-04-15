using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models
{
    public class ProductType : BaseEntity<int>
    {
        public string Name { get; set; } = null!;

       // public ICollection<Product> products { get; set; }

    }
}
