namespace Domain_Layer.Models.OrderModule
{
    public class Order : BaseEntity<Guid>
    {
        public Order()
        {
            
        }
        public Order(string userEmail, OrderAddress address, ICollection<OrderItems> items, decimal subTotal, DeliveryMethod deliveryMethod)
        {
            UserEmail = userEmail;
            Address = address;
            Items = items;
            SubTotal = subTotal;
            DeliveryMethod = deliveryMethod;
        }

        public string UserEmail { get; set; } = null!;
        public OrderAddress Address { get; set; } = null!; // Owned
        public ICollection<OrderItems> Items { get; set; } = [];
        public decimal SubTotal { get; set; }

        #region DeliveryMethod And Fk
        public DeliveryMethod DeliveryMethod { get; set; } = null!;
        public int DeliveryMethodId { get; set; } // Fk 
        #endregion

        public OrderState State { get; set; } = OrderState.Pending;
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        //[NotMapped]
        //public decimal Total { get => SubTotal + DeliveryMethod.Price; }
        public decimal GetTotal() => SubTotal + DeliveryMethod.Price;

    }
}
