using AlaBackEnd.BLL.dto;
using AlaBackEnd.DAL.Entity;
using AutoMapper;


namespace AlaBackEnd.BLL.MapperProfiles
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            //DevEntity -> DevDto
            CreateMap<BaseProductEntity, ProductDto>();

            //DevDto -> DevEnity
            CreateMap<CreateProductDto, BaseProductEntity>()
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            //UpdateDevDto -> DevEntity
            CreateMap<UpdateProductDto, BaseProductEntity>()
                .ForMember(dest => dest.Images, opt => opt.Ignore());
                
            


        }
    }
}
