using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Core.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cart, CartDto>()
                .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.CartItems)); // CartItems'ı doğrudan CartItem'lardan al

            CreateMap<CartItem, CartItemDTO>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId)) //productId'yi al
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Product.ImageUrl))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity)); // quantity'i al
            //ReverseMap'e gerek yok

        }


    }
}