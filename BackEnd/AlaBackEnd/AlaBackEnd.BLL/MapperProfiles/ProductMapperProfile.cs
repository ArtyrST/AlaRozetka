using AlaBackEnd.BLL.dto;
using AlaBackEnd.BLL.dto.UserDto;
using AlaBackEnd.DAL.Entity;
using AlaBackEnd.DAL.Entity.Products;
using AlaBackEnd.DAL.Entity.Users;
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
            CreateMap<ImageEntity, ImageDto>()
                .ForMember(dest => dest.Path, opt => opt.MapFrom(src =>
                    $"/uploads/images/{src.Path}"));

            CreateMap<ImageDto, ImageEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());



            //CategoryDto -> CategEn
            //CreateMap<CategoryDto, CategoryEntity>();


            //DevDto -> DevEnity
            CreateMap<CreateProductDto, BaseProductEntity>()
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.DateFrom, opt => opt.MapFrom(src => DateTime.Parse(src.CreateDateFrom).ToUniversalTime()))
                .ForMember(dest => dest.DateTo, opt => opt.MapFrom(src => DateTime.Parse(src.CreateDateTo).ToUniversalTime()));

            //CreateMap<CategoryEntity, CategoryDto>();


            //UpdateDevDto -> DevEntity 
            CreateMap<UpdateProductDto, BaseProductEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore())
                .ForMember(dest => dest.DateFrom, opt => opt.Ignore())
                .ForMember(dest => dest.DateTo, opt => opt.Ignore())
                
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            CreateMap<List<BaseProductEntity>, ProductDto>();



            //UserDto -> UserEntity
            CreateMap<RegisterUserDto, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Roles, opt => opt.Ignore());
            


        }
    }
}
