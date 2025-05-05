namespace Domain_Layer.Models.OrderModule
{
    public class Order : BaseEntity<Guid>
    {
        public string UserEmail { get; set; } = null!;
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public OrderAddress Address { get; set; } = null!;
        public OrderState State { get; set; } = OrderState.Pending;

        #region DeliveryMethod And Fk
        public DeliveryMethod DeliveryMethod { get; set; } = null!;
        public int DeliveryMethodId { get; set; } // Fk 
        #endregion

        public ICollection<OrderItems> Items { get; set; } = [];
        public decimal SubTotal { get; set; }
        //[NotMapped]
        //public decimal Total { get => SubTotal + DeliveryMethod.Price; }
        public decimal GetTotal() => SubTotal + DeliveryMethod.Price;

    }
}
