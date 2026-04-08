using AlaBackEnd.BLL.dto;
using AlaBackEnd.DAL.Entity;
using AlaBackEnd.DAL.Entity.Products;
using AlaBackEnd.Entity.Products;
using AutoMapper;


namespace AlaBackEnd.BLL.MapperProfiles
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            //DevEntity -> DevDto
            CreateMap<BaseProductEntity, ProductDto>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(t => t.Id).ToList()));


            //Image dto -> image entity
            CreateMap<ImageDto, ImageEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            


            //CategoryDto -> CategEn
            //CreateMap<CategoryDto, CategoryEntity>();


            //DevDto -> DevEnity
            CreateMap<CreateProductDto, BaseProductEntity>()
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore());
                //.ForMember(dest => dest.Category, opt => opt.Ignore());

            //CreateMap<CategoryEntity, CategoryDto>();


            //UpdateDevDto -> DevEntity 
            CreateMap<UpdateProductDto, BaseProductEntity>()
                .ForMember(dest => dest.Images, opt => opt.Ignore());

            
            
            


        }
    }
}
