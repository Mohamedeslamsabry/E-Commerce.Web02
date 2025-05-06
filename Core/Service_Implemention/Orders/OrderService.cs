using AutoMapper;
using Domain_Layer.Contract;
using Service_Abstrction.Product;
using Shared.DTO.Identity;
using Shared.DTO.Order;
using Domain_Layer.Models.OrderModule;
using Domain_Layer.Exceptions;
using Shared.DTO.Basket;
using Domain_Layer.Models.Prpducts;
using Domain_Layer.Models.Basket;
using Service_Implemention.Specifications;

namespace Service_Implemention.Orders
{
    public class OrderService(IUnitOfWork _unitOfWork, IBasketReposatiry _basketReposatiry, IMapper _mapper) : IOrderService
    {
        #region Create Order
        public async Task<OrderToReturnDTO> CreateOrderAsync(OrderDTO orderDTO, string Email)
        {
            #region Step01 OrderAddress
            //Map From AddressDTO To OrderAddress
            var OrderAddress = _mapper.Map<AddressDTO, OrderAddress>(orderDTO.Address)
                ?? throw new AddressNotFoundException(Email);
            #endregion

            #region Step02 productitems

            var Baseket = await _basketReposatiry.GetUserBasketAsync(orderDTO.BasketId)
                ?? throw new BasketNotFoundException(orderDTO.BasketId);

            List<OrderItems> Orderitems = [];
            var ProductRepo = _unitOfWork.genricRepository<Product, int>();


            foreach (var item in Baseket.Items)
            {
                var Product = await ProductRepo.GetByIdAsync(item.Id)
                    ?? throw new ProductNotFoundException(item.Id);

                OrderItems OrderItem = CreateOrderItem(item, Product);
                Orderitems.Add(OrderItem);
            }
            #endregion

            #region Delivary Method
            //Delivary Method

            var DelivaryMethod = await _unitOfWork.genricRepository<DeliveryMethod, int>()
                .GetByIdAsync(orderDTO.DeliveryMethodId)
                ?? throw new DelvairyMeyhodNotFoundException(orderDTO.DeliveryMethodId);
            #endregion

            #region Step04 SubTotal
            //SubTotal
            var SubbTotal = Orderitems.Sum(O => O.Quantity * O.Price);
            #endregion

            #region Create Object From Order
            var Order = new Order(Email, OrderAddress, Orderitems, SubbTotal, DelivaryMethod);
            await _unitOfWork.genricRepository<Order, Guid>().AddAsync(Order);
            await _unitOfWork.SaveChanges();
            #endregion

            return _mapper.Map<Order, OrderToReturnDTO>(Order);
        }

        private static OrderItems CreateOrderItem(BasketItem item, Product Product)
        {
            return new OrderItems()
            {
                Price = Product.Price,
                Quantity = item.Quantity,
                Product = new ProductItemOrdered()
                {
                    ProductId = Product.Id,
                    PictureUrl = Product.PictureUrl,
                    ProductName = Product.Name
                }
            };
        }
        #endregion

        #region GetDelivaryMethodAsync
        public async Task<IEnumerable<DelivaryMethodDTO>> GetDelivaryMethodAsync()
        {
            var Delivary = await _unitOfWork.genricRepository<DeliveryMethod, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<DeliveryMethod>, IEnumerable<DelivaryMethodDTO>>(Delivary);
        }
        #endregion

        #region AllOrderAsync
        public async Task<IEnumerable<OrderToReturnDTO>> AllOrderAsync(string Email)
        {
            var Spec = new OrderSpecification(Email);
            var orders = await _unitOfWork.genricRepository<Order, Guid>().GetAllAsync(Spec);
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderToReturnDTO>>(orders);
        }
        #endregion

        #region GetOrderByIdAsync
        public async Task<OrderToReturnDTO> GetOrderByIdAsync(Guid id)
        {
            var Spec = new OrderSpecification(id);
            var Order = await _unitOfWork.genricRepository<Order,Guid>().GetByIdAsync(Spec);
            return _mapper.Map<Order, OrderToReturnDTO>(Order!);
        } 
        #endregion
    }
}
