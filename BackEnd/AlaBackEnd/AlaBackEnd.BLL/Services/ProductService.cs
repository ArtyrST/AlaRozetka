using AlaBackEnd.BLL.dto;
using AlaBackEnd.DAL.Entity;
using AlaBackEnd.DAL.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace AlaBackEnd.BLL.Services
{
    public class ProductService 
    {
        private readonly ProductRepository _ProductRepository;
        private readonly IMapper _Mapper;
        public ProductService(ProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _Mapper = mapper;
        }
        public async Task<ServiceResponse> GelAllAsync()
        {
            var entities = await _ProductRepository.GetAll().ToListAsync();
            var dtos = _Mapper.Map<List<ProductDto>>(entities);

            return ServiceResponse.Success("The list of products was got", dtos);
                
        }
        public async Task<ServiceResponse> GetByIdAsync(int id) 
        {
            var entity = await _ProductRepository.GetByIdAsync(id);

            if (entity == null)
            {
                return ServiceResponse.Error($"The product with id: {id} was not found");
            }
            var dtos = _Mapper.Map<List<ProductDto>>(entity);

            return ServiceResponse.Success($"The product with id: {id} was found", dtos);
        }

        public async Task<ServiceResponse> GetByNameAsync(string name)
        {
            var entity = await _ProductRepository.GetByNameAsync(name);

            if (entity == null)
            {
                return ServiceResponse.Error($"The product with name: {name} was not found");
            }

            var dtos = _Mapper.Map<List<ProductDto>>(entity);
            return ServiceResponse.Success($"The product with name: {name} was found", dtos);
        }
        public async Task<ServiceResponse> CreateAsync(CreateProductDto dto)
        {
            if (await _ProductRepository.IsExistAsync(dto.Name))
            {
                return ServiceResponse.Error($"The product with name {dto.Name} is already exist");
            }

            var entity = _Mapper.Map<BaseProductEntity>(dto);
            bool res = await _ProductRepository.CreateAsync(entity);
            if (!res)
            {
                return ServiceResponse.Error("Something problem with adding new product...");
            }
            var responseDto = _Mapper.Map<ProductDto>(entity);

            return ServiceResponse.Success("Success!", responseDto);
        }
    }
}
