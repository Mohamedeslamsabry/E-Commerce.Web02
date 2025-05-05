namespace Domain_Layer.Exceptions
{
    public class DelvairyMeyhodNotFoundException (int id) : NotFoundExceptions($"Delivary Method By Id :{id} is not found")
    {

    }
}
