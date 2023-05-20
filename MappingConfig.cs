using AutoMapper;
using BasketAPI.Models;
using BasketAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<WineDto, Wine>().ReverseMap();
                config.CreateMap<BasketHeader, BasketHeaderDto>().ReverseMap();
                config.CreateMap<BasketDetails, BasketDetailsDto>().ReverseMap();
                config.CreateMap<Models.Basket, BasketDto>().ReverseMap();
                
            });
            return mappingConfig;
        }
    }
}