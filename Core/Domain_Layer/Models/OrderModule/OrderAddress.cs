namespace Domain_Layer.Models.OrderModule
{
    public class OrderAddress
    {
        #region prop
        //City, Street, Country, FirstName, and LastName
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Street { get; set; } = null!;
        #endregion
    }
}
