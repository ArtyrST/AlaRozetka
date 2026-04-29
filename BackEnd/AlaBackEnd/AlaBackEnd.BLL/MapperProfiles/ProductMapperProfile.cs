using AlaBackEnd.BLL.dto;
using AlaBackEnd.BLL.dto.UserDto;
using AlaBackEnd.BLL.Services.LoginService;
using AlaBackEnd.DAL.Entity;
using AlaBackEnd.DAL.Entity.ProductCart;
using AlaBackEnd.DAL.Entity.Products;
using AlaBackEnd.DAL.Entity.Users;
using AlaBackEnd.Entity.Products;
using AutoMapper;
using AlaBackEnd.BLL.dto;


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
                .ForMember(dest => dest.DateTo, opt => opt.MapFrom(src => DateTime.Parse(src.CreateDateTo).ToUniversalTime()))
                .ForMember(dest => dest.AdditionalServices, opt => opt.Ignore());
                
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


            //CreateOrderDto -> OrderEntity
            CreateMap<CreateOrderDto, OrderItemEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.TotalPrice, opt => opt.Ignore());

            //CreateFeedBackDto -> FeedBackDto
            CreateMap<CreateFeedBackDto, FeedBackEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            //PandingDto -> PandingEntity
                CreateMap<PandingUserDto, PandingUserEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            //PandingEntity -> UserEntity
            CreateMap<PandingUserEntity, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<CartEntity, CartDto>()
    .ForMember(dest => dest.Orders , opt => opt.MapFrom(src => src.OrderItems));

            CreateMap<OrderItemEntity, OrderDto>()
                .ForMember(dest => dest.IdHash, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VisitersCount, opt => opt.MapFrom(src => src.VisitorsCount))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.TotalPrice));


            CreateMap<RieltorAcceptEntity, RieltorRequestsDto>();
            CreateMap<RieltorRequestsDto, RieltorAcceptEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());


            CreateMap<CreateAdditionalServiceDto, AdditionalServicesEntity>();
                //.ForMember(dest => dest.Id, opt => opt.Ignore());

            
                
        }
    }
}
