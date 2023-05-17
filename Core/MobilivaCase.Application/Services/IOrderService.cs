using MobilivaCase.Application.DTOs.Order;
using MobilivaCase.Application.Result;
using MobilivaCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.Services
{
    public  interface IOrderService
    {
        Task<int> CreateOrderAsync(CreateOrderDto model);
        Task<List<GetOrderDto>> GetAllOrderAsync(Expression<Func<Order, bool>> filter = null);
        Task<GetOrderDto> GetOrderAsync(Expression<Func<Order, bool>> filter);
        Task DeleteCarrierById(int id);
        Task UpdateCarrierAsync(CreateOrderDto model);
    }
}
