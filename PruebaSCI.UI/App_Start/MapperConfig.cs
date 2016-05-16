using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PruebaSCI.Business.DTO;
using PruebaSCI.Data.Entities;
using PruebaSCI.UI.Models;

namespace PruebaSCI.UI.App_Start
{
    public class MapperConfig : Profile
    {
        protected override void Configure()
        {
            CreateMap<PaisModel, PaisDTO>();
            CreateMap<PaisDTO, PaisModel>();

            CreateMap<PaisDTO, Pais>();
            CreateMap<Pais, PaisDTO>();
        }
    }
}