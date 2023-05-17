using AutoMapper;
using MobilivaCase.Application.Constans.ApiResponse;
using MobilivaCase.Application.DTOs.Product;
using MobilivaCase.Application.Repositories.Product;
using MobilivaCase.Application.Result;
using MobilivaCase.Application.Services;
using MobilivaCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Persistence.Services
{
    public class ProductService : IProductService
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly IMapper _mapper;

        public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
        }
        public async Task<List<GetProductDto>> GetAllProductAsync(Expression<Func<Product, bool>> filter = null)
        {
            var productList = await _productReadRepository.GetAllAsync(filter, false);
            var result = _mapper.Map<List<GetProductDto>>(productList);
            return result;
        }
        public async Task<int> CreateProductAsync(CreateProductDto model)
        {
            var product = _mapper.Map<Product>(model);
            await _productWriteRepository.AddAsync(product);
            _productWriteRepository.SaveAsync();
            return product.Id;
        }

        public Task DeleteCarrierById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<GetProductDto> GetProductAsync(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCarrierAsync(CreateProductDto model)
        {
            throw new NotImplementedException();
        }
    }
}
