namespace Domain_Layer.Models.Basket
{
    public class CustomerBasket
    {
        public string Id { get; set; } = null!; // GUID (Front End Send)
        public ICollection<BasketItem> Items { get; set; } = [];
    }
}
    