using AlaBackEnd.BLL.dto;
using AlaBackEnd.BLL.Services.ImagesService;
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
        private readonly ImageService _Image;

        public ProductService(ProductRepository ProductRepository, IMapper mapper, TagRepository tags, CategoryRepository categoryRepository, ImageService image)
        {
            _ProductRepository = ProductRepository;
            _Mapper = mapper;
            _Tags = tags;
            _CategoryRepository = categoryRepository;
            _Image = image;

        }
        public async Task<ServiceResponse> GetAllAsync(int PageNumber, int PageSize)
        {
            var entities = await _ProductRepository.GetAllWithCategoryAsync(PageNumber, PageSize);
                
                
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
            var dtos = _Mapper.Map<ProductDto>(entity);

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
            Console.WriteLine($"Name: {dto.Name}, Images count: {dto.Images?.Count ?? 0}");
            if (await _ProductRepository.IsExistAsync(dto.Name))
            {
                return ServiceResponse.Error($"The product with name {dto.Name} is already exist");
            }

            
            var entity = _Mapper.Map<BaseProductEntity>(dto);
            
            if (dto.Images != null && dto.Images.Count > 0)
            {
                for (int i = 0; i < dto.Images.Count; i++)
                {
                    var image = dto.Images[i];
                    string imagePath = await _Image.SaveImageAsync(image, "products");
                    var newImage = new ImageEntity
                    {
                        Path = imagePath,
                        IsPreview = (i == dto.PreviewImageId)

                    };
                   

                    entity.Images.Add(newImage);

                }
            }

            
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

            Console.WriteLine($"DEBUG: Перед збереженням у продукту {entity.Images.Count} картинок.");
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


            
            var responseDto = _Mapper.Map<ProductDto>(entity);
            return ServiceResponse.Success($"Product with name: {oldName} was successfull chanched!", responseDto);


        }
        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var entity = await _ProductRepository.GetByIdAsync(id);
            if (entity == null )
            {
                return ServiceResponse.Error($"The product with that id was not found");
            }

            string nameOfDeletedProduct = entity.Name;

            var res = await _ProductRepository.DeleteEntityAsync(entity);
            if (!res)
            {
                return ServiceResponse.Error("Something wrong with deleting that product...");
            }
            
            return ServiceResponse.Success($"Succssfully deleting product with name: {nameOfDeletedProduct}!", true);

        }
    }
}
