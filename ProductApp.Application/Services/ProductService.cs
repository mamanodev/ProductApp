using AutoMapper;
using ProductApp.Application.DTOs;
using ProductApp.Application.Interface;
using ProductApp.Application.Interface.Repositories;
using ProductApp.Application.Interface.Services;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Services
{
    public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork ,IMapper mapper) : IProductService
    {
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await productRepository.GetAllAsync();
            return mapper.Map<IEnumerable<ProductDto>>(products);
        }
        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return null;
            }
            return mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> AddAsync(ProductCreateDto dto)
        {
            var newProduct = mapper.Map<Product>(dto);
            await productRepository.AddAsync(newProduct);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<ProductDto>(newProduct);
        }
        public async Task<bool> UpdateAsync(int id, ProductUpdateDto dto)
        {
            var existingProduct = await productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return false;
            }
            mapper.Map(dto, existingProduct);
            existingProduct.UpdatedAt = DateTime.UtcNow;
            await productRepository.UpdateAsync(existingProduct);
            var result = await unitOfWork.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingProduct = await productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return false;
            }
           await productRepository.DeleteAsync(existingProduct);
            var result = await unitOfWork.SaveChangesAsync();
            return result > 0;
        }
}
}
