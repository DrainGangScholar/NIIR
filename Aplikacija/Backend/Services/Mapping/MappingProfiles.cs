using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Services.DTO;
using AutoMapper;

namespace Services.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();
            //CreateMap<Basket, BasketDTO>();
            //CreateMap<BasketItem, BasketItemDTO>();
        }
    }
}