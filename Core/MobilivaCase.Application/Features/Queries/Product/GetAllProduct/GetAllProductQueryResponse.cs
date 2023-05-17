using MobilivaCase.Application.DTOs.Product;
using MobilivaCase.Application.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryResponse
    {
        public GetAllProductQueryResponse()
        {
            Result = new ApiResponse<List<GetProductDto>>();
        }
        public ApiResponse<List<GetProductDto>>? Result { get; set; }//Api response a göre ayarla
    }
}
