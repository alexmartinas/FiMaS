using AutoMapper;
using Data.Domain.Entities;

namespace Presentation.DTOs.ProductModels.Mapping
{
    class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductModel, Product>().ReverseMap();
        }
    }
}
