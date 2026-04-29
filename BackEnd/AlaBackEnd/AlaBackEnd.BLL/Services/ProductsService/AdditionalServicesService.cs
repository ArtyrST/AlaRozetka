using AlaBackEnd.BLL.dto;
using AlaBackEnd.DAL.Entity.Products;
using AlaBackEnd.DAL.Repositories;
using AutoMapper;


namespace AlaBackEnd.BLL.Services.ProductsService
{
    public class AdditionalServicesService
    {
        private readonly AdditionalServicesRepository _additionalServices;
        private readonly IMapper _mapper;
        private readonly ProductRepository _product;
        public AdditionalServicesService(AdditionalServicesRepository additionalServices, IMapper mapper, ProductRepository product)
        {
            _additionalServices = additionalServices;
            _mapper = mapper;
            _product = product;
        }
        //public async Task<bool> AddAdditionalService(CreateAdditionalServiceDto dto)
        //{
            //if (await _additionalservices.isexistbynameasync(dto.name))
            //{
            //    return serviceresponse.success("the service with this name is now exist", await _additionalservices
            //        .getbynameasync(dto.name));
            //}

            //var entity = _mapper.map<additionalservicesentity>(dto);

            //bool res = await _additionalservices.createasync(entity);
            //if (!res)
            //{
            //    return serviceresponse.error("something wrong");
            //}
            //return serviceresponse.success("successfuly add a service", entity);
        //}
    }
}
