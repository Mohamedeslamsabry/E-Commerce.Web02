namespace Domain_Layer.Exceptions
{
    public class AddressNotFoundException(string userName) : NotFoundExceptions($"User {userName} Has No Address")
    {
    }
}
