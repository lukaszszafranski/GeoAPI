using AutoMapper;
using StockAPI.Models;
using StockAPI.Resources;
using StockAPI.DTOs;
using StockAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<StockData, StockResource>();
            CreateMap<User, UserDTO>();
        }
    }
}
