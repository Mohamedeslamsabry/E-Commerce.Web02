using AutoMapper;
using Domain_Layer.Models.Prpducts;
using Shared.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Implemention.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() : base()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dist => dist.productBrand, options => options.MapFrom(src => src.productBrand.Name))
                .ForMember(dist => dist.productType, options => options.MapFrom(src => src.productType.Name))
                .ForMember(dist => dist.PictureUrl, options => options.MapFrom<PictureUrlResolver>());

            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductType, TypeDto>();
        }
    }
}
