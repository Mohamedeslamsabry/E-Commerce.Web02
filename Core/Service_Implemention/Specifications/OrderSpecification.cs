using Domain_Layer.Models.OrderModule;

namespace Service_Implemention.Specifications
{
    public class OrderSpecification : BaseSpecification<Order,Guid>
    {
        public OrderSpecification(string Email) : base(O=>O.buyerEmail == Email)
        {
            AddInclude(O => O.Items);
            AddInclude(O => O.DeliveryMethod);
            SetOrderyDesc(O => O.OrderDate);
        }

        public OrderSpecification(Guid id) : base(O => O.Id == id)
        {
            AddInclude(O => O.Items);
            AddInclude(O => O.DeliveryMethod);
        }
    }
}
