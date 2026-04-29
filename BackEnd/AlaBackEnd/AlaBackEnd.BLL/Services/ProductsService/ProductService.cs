using AlaBackEnd.BLL.dto;
using AlaBackEnd.BLL.Services.ImagesService;
using AlaBackEnd.DAL.Entity;
using AlaBackEnd.DAL.Entity.Products;
using AlaBackEnd.DAL.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;



namespace AlaBackEnd.BLL.Services
{
    public class ProductService 
    {
        private readonly ProductRepository _ProductRepository;
        private readonly CategoryRepository _CategoryRepository;
        private readonly IMapper _Mapper;
        private readonly TagRepository _Tags;
        private readonly ImageService _Image;
        private readonly IHttpContextAccessor _httpAccessor;
        private readonly AdditionalServicesRepository _additionalServices;

        public ProductService(AdditionalServicesRepository additionalServices, IHttpContextAccessor httpAccessor, ProductRepository ProductRepository, IMapper mapper, TagRepository tags, CategoryRepository categoryRepository, ImageService image)
        {
            _ProductRepository = ProductRepository;
            _Mapper = mapper;
            _Tags = tags;
            _CategoryRepository = categoryRepository;
            _Image = image;
            _httpAccessor = httpAccessor;
            _additionalServices = additionalServices;
        }
        public async Task<ServiceResponse> GetAllAsync(int PageNumber, int PageSize)
        {
            var entities = await _ProductRepository.GetAll(PageNumber, PageSize);
                
                
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
            Console.WriteLine($"DateFrom: '{dto.CreateDateFrom}', DateTo: '{dto.CreateDateTo}'");
            if (await _ProductRepository.IsExistAsync(dto.Name))
            {
                return ServiceResponse.Error($"The product with name {dto.Name} is already exist");
            }

            
            var entity = _Mapper.Map<BaseProductEntity>(dto);
            
            //var userId = _httpAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //entity.UserId = int.Parse(userId);
            
            if (dto.AdditionalServices != null && dto.AdditionalServices.Count > 0)
            {
                var mapped = _Mapper.Map<List<AdditionalServicesEntity>>(dto.AdditionalServices);
                entity.AdditionalServices.AddRange(mapped); // замість циклу
                //var addServicesMapped = _Mapper.Map<List<AdditionalServicesEntity>>(dto.AdditionalServices);
                //bool addingRes = await _additionalServices.CreateRangeListAsync(addServicesMapped);
                //if (!addingRes)
                //{
                //    return ServiceResponse.Error("Something wrong with adding additional");
                //}
            }

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

            
            var categ = await _CategoryRepository.GetByIdAsync(dto.CategoryId);

            if (categ == null)
            {
                return ServiceResponse.Error($"Category with id {dto.CategoryId} not found");
            }

            
            entity.CategoryId = categ.Id;
            
            entity.Category = null;

            entity.Tags = new List<ProductTagEntity>();
            if (dto.Tags != null && dto.Tags.Any())
            {
                var tags = await _Tags.tags
                    .Where(t => dto.Tags.Contains(t.Id))
                    
                    .ToListAsync();
                    
                entity.Tags = tags;
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

            if (dto.UpdateDateFrom != null && dto.UpdateDateTo != null)
            {
                entity.DateFrom = DateTime.Parse(dto.UpdateDateFrom).ToUniversalTime();
                entity.DateTo = DateTime.Parse(dto.UpdateDateTo).ToUniversalTime();
            }
            if (dto.Tags.Any())
            {

                var currentTags = entity.Tags.Select(t => t.Id).ToHashSet();
                var newTags = dto.Tags.ToHashSet();

                var tagsToRemove = entity.Tags
                    .Where(t => !newTags.Contains(t.Id))
                    .ToList();
                foreach (var tags in  tagsToRemove)
                {
                    entity.Tags.Remove(tags);
                }
                var newTagsId = newTags.Except(currentTags).ToList();
                if (newTagsId.Any())
                {
                    var tagsToAdd = await _Tags.GetByIdAsync(newTagsId);
                    foreach (var tag in  tagsToAdd)
                    {
                        entity.Tags.Add(tag);
                    }
                }


            }



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
            
            return ServiceResponse.Success($"Succssfully deleting product with name: {nameOfDeletedProduct}!", null);

        }
        public async Task<ServiceResponse> DeleteRangeAsync(List<int> id)
        {
            var entities = await _ProductRepository.GetRangeByIdAsync(id);
            if (entities == null )
            {
                return ServiceResponse.Error("The products with these id's were not found");
            }
            var res = await _ProductRepository.DeleteRangeAsync(entities);
            if (!res)
            {
                return ServiceResponse.Error("Something wrong with deleting these products...");
            }
            return ServiceResponse.Success("Successfuly deleting range of products!", null);

        }
    }
}
