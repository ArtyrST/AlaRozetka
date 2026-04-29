using AlaBackEnd.BLL.dto;
using AlaBackEnd.DAL.Entity.Products;
using AlaBackEnd.DAL.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


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
        public async Task<ServiceResponse> GetAllServices()
        {
            var entitys = await _additionalServices.GetAll().ToListAsync();
            if (entitys == null)
            {
                return ServiceResponse.Error("The list of services is null");
            }
            var entity = _mapper.Map<List<GetAdditionalServicesDto>>(entitys);
            if (entity == null)
            {
                return ServiceResponse.Error("Something wrong");
            }
            return ServiceResponse.Success("Success", entity);
        }
    }
}
