namespace Domain_Layer.Exceptions
{
    public class AddressNotFoundException(string userName) : Exception($"User {userName} Has No Address")
    {
    }
}
