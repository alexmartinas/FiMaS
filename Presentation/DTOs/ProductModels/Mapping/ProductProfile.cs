using AutoMapper;
using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
