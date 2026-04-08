using AlaBackEnd.BLL.dto;
using AlaBackEnd.DAL.Entity;
using AlaBackEnd.DAL.Entity.Products;
using AlaBackEnd.DAL.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace AlaBackEnd.BLL.Services
{
    public class ProductService 
    {
        private readonly ProductRepository _ProductRepository;
        private readonly CategoryRepository _CategoryRepository;
        private readonly IMapper _Mapper;
       private readonly TagRepository _Tags;
        public ProductService(ProductRepository ProductRepository, IMapper mapper, TagRepository tags, CategoryRepository categoryRepository)
        {
            _ProductRepository = ProductRepository;
            _Mapper = mapper;
            _Tags = tags;
            _CategoryRepository = categoryRepository;
        }
        public async Task<ServiceResponse> GetAllAsync()
        {
            var entities = await _ProductRepository.GetAllWithCategoryAsync();
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
        public async Task<ServiceResponse> GetByTagAsync(List<int> tagIds)
        {
            var entity = await _ProductRepository.GetByTagAsync(tagIds);
            if ( entity == null )
            {
                return ServiceResponse.Error("No hotels with that tags");
            }
            var dto = _Mapper.Map<List<ProductDto>>(entity);
            return ServiceResponse.Success("List of hotels with this tag was got", dto);
        }
        public async Task<ServiceResponse> CreateAsync(CreateProductDto dto)
        {
            
            if (await _ProductRepository.IsExistAsync(dto.Name))
            {
                return ServiceResponse.Error($"The product with name {dto.Name} is already exist");
            }

            
            var entity = _Mapper.Map<BaseProductEntity>(dto);

            
            var categ = await _CategoryRepository.GetAllAsync(dto.CategoryId);

            if (categ == null)
            {
                return ServiceResponse.Error($"Category with id {dto.CategoryId} not found");
            }

            
            entity.CategoryId = categ.Id;
            
            entity.Category = null;

            entity.Tags = new List<ProductTagEntity>();
            if (dto.Tags != null && dto.Tags.Any())
            {
                foreach (int tagId in dto.Tags)
                {
                    var addedTag = await _Tags.GetByIdAsync(tagId);
                    if (addedTag != null)
                    {
                        entity.Tags.Add(addedTag);
                    }
                }
            }

            
            bool res = await _ProductRepository.CreateAsync(entity);

            if (!res)
            {
                return ServiceResponse.Error("Something wrong with adding new product to the database.");
            }

            
            var responseDto = _Mapper.Map<ProductDto>(entity);

            return ServiceResponse.Success("Success!", responseDto);
        }
        public async Task<ServiceResponse> UpdateAsync(UpdateProductDto dto)
        {
            var entity = await _ProductRepository.GetByIdAsync(dto.Id);
            if (entity  == null)
            {
                return ServiceResponse.Error($"Entity with id: {dto.Id} was not found");
            }
            if (await _ProductRepository.IsExistAsync(dto.Name, dto.Id))
            {
                return ServiceResponse.Error($"The name: {dto.Name} is already used");
            }
            string oldName = entity.Name;

            _Mapper.Map(dto, entity);

            bool res = await _ProductRepository.UpdateAsync(entity);
            if (!res)
            {
                return ServiceResponse.Error("Something wrong with updated product...");
            }


            var updatedentity = _ProductRepository.GetAllWithCategory1Async(entity.Id);
            var responseDto = _Mapper.Map<ProductDto>(updatedentity);
            return ServiceResponse.Success($"Product with name: {oldName} was successfull chanched!", responseDto);


        }
    }
}
