using AutoMapper;
using MediatR;
using MobilivaCase.Application.Constans.ApiResponse;
using MobilivaCase.Application.DTOs.Order;
using MobilivaCase.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        readonly IOrderService _orderService;
        readonly IMapper _mapper;
        public CreateOrderCommandHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var createOrder=_mapper.Map<CreateOrderDto>(request);
            var result=await _orderService.CreateOrderAsync(createOrder);
            var response=new CreateOrderCommandResponse();
            response.Result.Status = result > 0 ? Status.Success : Status.Failed;
            response.Result.ResultMessage = result > 0 ? Message.OrderAddedSuccess : Message.OrderAddedFailed;
            response.Result.Data = result;
            return response;

        }
    }
}
