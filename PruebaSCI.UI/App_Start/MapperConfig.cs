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

            CreateMap<PilotoModel, PilotoDTO>()
                .ForMember(dest => dest.FechaNacimiento, opt => opt.ResolveUsing((a,src) => src.FechaNacimeinto ?? DateTime.Now))
                .ForMember(dest => dest.Equipo, opt => opt.ResolveUsing((a, src) => new EquipoDTO { Id = src.Equipo}))
                .ForMember(dest => dest.Nacionalidad, opt => opt.ResolveUsing((a, src) => new PaisDTO { Id = src.Nacionalidad }));

            CreateMap<PilotoDTO, PilotoModel>()
                .ForMember(dest => dest.FechaNacimeinto, opt => opt.MapFrom(src => src.FechaNacimiento))
                .ForMember(dest => dest.Equipo, opt => opt.ResolveUsing(src => src.Equipo == null ? Guid.Empty : src.Equipo.Id))
                .ForMember(dest => dest.NombreEquipo, opt => opt.ResolveUsing((a, src) => src.Equipo == null ? string.Empty : src.Equipo.Nombre))
                .ForMember(dest => dest.NombrePais, opt => opt.ResolveUsing((a, src) => src.Nacionalidad == null ? string.Empty : src.Nacionalidad.Nombre))
                .ForMember(dest => dest.Nacionalidad, opt => opt.ResolveUsing(src => src.Nacionalidad == null ? Guid.Empty : src.Nacionalidad.Id));

            CreateMap<PilotoDTO, Piloto>();
            CreateMap<Piloto, PilotoDTO>();

            CreateMap<EquipoDTO, Equipo>();
            CreateMap<Equipo, EquipoDTO>();

            CreateMap<EquipoModel, EquipoDTO>();
            CreateMap<EquipoDTO, EquipoModel>();

        }
    }
}