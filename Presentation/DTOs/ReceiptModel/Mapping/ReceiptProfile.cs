using AutoMapper;
using Data.Domain.Entities;
using Presentation.DTOs.ReceiptModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.DTOs.ShopModels.Mapping
{
    public class ReceiptProfile : Profile
    {
        public ReceiptProfile()
        {
            CreateMap<CreateReceiptModel, Receipt>().ReverseMap();
        }
    }
}
