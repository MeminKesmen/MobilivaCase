using AutoMapper;
using MobilivaCase.Application.DTOs.Order;
using MobilivaCase.Application.DTOs.OrderDetail;
using MobilivaCase.Application.DTOs.Product;
using MobilivaCase.Application.Features.Commands.Order.CreateOrder;
using MobilivaCase.Application.Features.Queries.Product.GetAllProduct;
using MobilivaCase.Application.Result;
using MobilivaCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.MappingProfiles
{
    public class AllProfile:Profile
    {
        public AllProfile()
        {
            CreateMap<CreateOrderCommandRequest, CreateOrderDto>().ReverseMap();
            CreateMap<CreateOrderDto, Order>().ReverseMap(); 
            CreateMap<CreateOrderDetailDto, OrderDetail>().ReverseMap();
            CreateMap<Product,GetProductDto>().ReverseMap();
        }
    }
}
