using AutoMapper;
using AutoMapper.Execution;
using Domain_Layer.Models.OrderModule;
using Microsoft.Extensions.Configuration;
using Shared.DTO.Order;

namespace Service_Implemention.Profiles
{
    public class OrderPictureUrlResolver : IValueResolver<OrderItems, OrderItemDTO, string>
    {
        private readonly IConfiguration _configuration;

        public OrderPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(OrderItems source, OrderItemDTO destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.Product.PictureUrl)) return string.Empty;

            else
            {
                //var Url = $"https://localhost:7176/{source.PictureUrl}";
                var Url = $"{_configuration.GetSection("Urls")["BaseUrl"]}{source.Product.PictureUrl}";
                return Url;
            }
        }
    }
}
