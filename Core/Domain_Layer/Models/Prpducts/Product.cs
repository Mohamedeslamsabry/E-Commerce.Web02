using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models.Prpducts
{
    public class Product : BaseEntity<int>
    {
        #region Prop
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PictureUrl { get; set; } = null!;
        public decimal Price { get; set; }
        #endregion

        #region RelationShip

        #region Relation
        public ProductBrand productBrand { get; set; }

        public int BrandId { get; set; } //Fk 
        #endregion

        #region Relation
        public ProductType productType { get; set; }
        public int TypeId { get; set; } //Fk 
        #endregion

        #endregion
    }
}
