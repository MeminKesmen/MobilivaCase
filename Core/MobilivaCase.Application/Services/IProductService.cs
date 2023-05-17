using MobilivaCase.Application.DTOs.Product;
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
    public interface IProductService
    {
        Task<int> CreateProductAsync(CreateProductDto model);
        Task<List<GetProductDto>> GetAllProductAsync(Expression<Func<Product, bool>> filter = null);
        Task<GetProductDto> GetProductAsync(Expression<Func<Product, bool>> filter);
        Task DeleteCarrierById(int id);
        Task UpdateCarrierAsync(CreateProductDto model);

       
    }
}
