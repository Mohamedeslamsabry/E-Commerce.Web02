namespace Domain_Layer.Models.Identity
{
    public class Address
    {
        #region prop
        //City, Street, Country, FirstName, and LastName
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Street { get; set; } = null!;
        #endregion

        public ApplicationUser User { get; set; } = null!; // IEnumrable Whyyy ?? Becouse This User Have one address
        public string UserId { get; set; } //fk [Unique Index]
    }
}
