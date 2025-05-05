namespace Domain_Layer.Models.OrderModule
{
    public class OrderItems : BaseEntity<int>
    {
        public ProductItemOrdered Product { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
