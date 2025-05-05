namespace Domain_Layer.Exceptions
{
    public class AddressNotFoundException(string Email) : NotFoundExceptions($"User By Email {Email} Has No Address")
    {
    }
}
