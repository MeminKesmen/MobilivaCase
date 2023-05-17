using MobilivaCase.Application.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandResponse
    {
        public CreateOrderCommandResponse()
        {
            Result = new ApiResponse<int>();
        }
        public ApiResponse<int>? Result { get; set; }//Api response a göre ayarla
    }
}
