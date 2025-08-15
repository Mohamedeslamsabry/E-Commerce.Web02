using AutoMapper;
using Domain_Layer.Models.OrderModule;
using Microsoft.Extensions.Configuration;
using Shared.DTO.Identity;
using Shared.DTO.Order;

namespace Service_Implemention.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile() : base()
        {
            CreateMap<AddressDTO, OrderAddress>().ReverseMap();


            CreateMap<Order, OrderToReturnDTO>()
                .ForMember(src => src.deliveryMethod, dist => dist.MapFrom(O => O.DeliveryMethod.ShortName));

            CreateMap<OrderItems, OrderItemDTO>()
                .ForMember(Src => Src.ProductName, dist => dist.MapFrom(O => O.Product.ProductName))
                .ForMember(Src => Src.PictureUrl, dist => dist.MapFrom< OrderPictureUrlResolver>());

            CreateMap<DeliveryMethod, DelivaryMethodDTO>();
        }
    }
}
