using AutoMapper;
using GeolocationAPI.Models;
using GeolocationAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolocationAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<GeolocationData, GeolocationResource>();
        }
    }
}
