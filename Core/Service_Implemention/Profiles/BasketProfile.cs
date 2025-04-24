using AutoMapper;
using Domain_Layer.Models.Basket;
using Shared.DTO.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Implemention.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile() :base()
        {
            CreateMap<CustomerBasket, CustomerBasketDTO>().ReverseMap();
            CreateMap<BasketItem, BasketItemDTO>().ReverseMap();
        }
    }
}
