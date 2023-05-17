using AutoMapper;
using MediatR;
using MobilivaCase.Application.Constans.ApiResponse;
using MobilivaCase.Application.DTOs.Product;
using MobilivaCase.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        readonly IProductService _productService;
        readonly IRedisCacheService _redisCacheService;
        readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductService productService, IRedisCacheService redisCacheService, IMapper mapper)
        {
            _productService = productService;
            _redisCacheService = redisCacheService;
            _mapper = mapper;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {

            var response = new GetAllProductQueryResponse();
            response.Result.Status = Constans.ApiResponse.Status.Success;
            response.Result.ErrorCode = "";
            response.Result.ResultMessage = Message.ProductListingSuccessful;
            var productList = await _redisCacheService.GetFromRedis<List<GetProductDto>>("productList");
            if (!productList.Any())
            {
                productList = await _productService.GetAllProductAsync();
                await _redisCacheService.SetToRedis("productList", productList);

            }
            response.Result.Data= productList.Where(p => request.CategoryId > 0 ? p.CategoryId == request.CategoryId : true).ToList();
            

            return response;
        }
    }
}
