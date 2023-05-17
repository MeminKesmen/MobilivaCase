using AutoMapper;
using MobilivaCase.Application.Constans.ApiResponse;
using MobilivaCase.Application.DTOs.Order;
using MobilivaCase.Application.DTOs.RabbitMq;
using MobilivaCase.Application.Repositories.Order;
using MobilivaCase.Application.Repositories.OrderDetail;
using MobilivaCase.Application.Repositories.Product;
using MobilivaCase.Application.Result;
using MobilivaCase.Application.Services;
using MobilivaCase.Application.Services.RabbitMqServices;
using MobilivaCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderReadRepository _orderReadRepository;
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IOrderDetailReadRepository _orderDetailReadRepository;
        readonly IOrderDetailWriteRepository _orderDetailWriteRepository;
        readonly IProductReadRepository _productReadRepository;
        readonly IRabbitMqOrderMailPublisher _rabbitMqOrderMailPublisher;
        readonly IMapper _mapper;

        public OrderService(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, IOrderDetailReadRepository orderDetailReadRepository, IOrderDetailWriteRepository orderDetailWriteRepository, IRabbitMqOrderMailPublisher rabbitMqOrderMailPublisher, IMapper mapper, IProductReadRepository productReadRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _orderDetailReadRepository = orderDetailReadRepository;
            _orderDetailWriteRepository = orderDetailWriteRepository;
            _rabbitMqOrderMailPublisher = rabbitMqOrderMailPublisher;
            _mapper = mapper;
            _productReadRepository = productReadRepository;
        }

        public async Task<int> CreateOrderAsync(CreateOrderDto model)
        {
            var productIds = model.OrderDetails.Select(o => o.ProductId).ToList();
            var orderProducts = await _productReadRepository.GetAllAsync(p => productIds.Contains(p.Id));
            var order = _mapper.Map<Order>(model);
            order.TotalAmount = model.OrderDetails.Sum(od => od.Amount);
            await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.SaveAsync();
            var orderMailDetails = new List<OrderMailDetailDto>();
            var orderDetails = _mapper.Map<List<OrderDetail>>(model.OrderDetails);
            orderDetails.ForEach(od =>
            {
                od.OrderId = order.Id;
                var product = orderProducts.FirstOrDefault(p => p.Id == od.ProductId);
                orderMailDetails.Add(new OrderMailDetailDto() { Description = product.Description, Price = product.UnitPrice, Amount = od.Amount });

            });
            await _orderDetailWriteRepository.AddRangeAsync(orderDetails);
            await _orderDetailWriteRepository.SaveAsync();

            _rabbitMqOrderMailPublisher.Publish(new OrderMailDto { CustomerEmail = model.CustomerEmail, CustomerName = model.CustomerName, OrderDetails = orderMailDetails });
            return order.Id;

        }

        public Task DeleteCarrierById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetOrderDto>> GetAllOrderAsync(Expression<Func<Order, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<GetOrderDto> GetOrderAsync(Expression<Func<Order, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCarrierAsync(CreateOrderDto model)
        {
            throw new NotImplementedException();
        }
    }
}
