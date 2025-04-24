namespace Domain_Layer.Models.Basket
{
    public class BasketItem
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string PictureUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
