using AutoMapper;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain.Menu;
using Microsoft.AspNetCore.Identity;

namespace CIAC_TAS_Service.Mapping
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Post, PostResponse>()
                .ForMember(dest => dest.Tags,
                opt => opt.MapFrom(
                    src => src.Tags.Select(x => new TagResponse
                    {
                        Name = x.Name
                    }))
                );
            CreateMap<MenuModuloWeb, MenuModulosWebResponse>()
                .ForMember(
                x => x.MenuSubModulosWebResponse,
                opt => opt.MapFrom(s => s.MenuSubModulosWeb));

            CreateMap<PreguntaAsa, PreguntaAsaResponse>()
                .ForMember(
                    x => x.GrupoPreguntaAsaResponse,
                    opt => opt.MapFrom(s => s.GrupoPreguntaAsa))
                .ForMember(
                    x => x.EstadoPreguntaAsaResponse,
                    opt => opt.MapFrom(s => s.EstadoPreguntaAsa))
                .ForMember(
                    dest => dest.PreguntaAsaOpcionesResponse,
                    opt => opt.MapFrom(s => s.PreguntaAsaOpciones));

            CreateMap<Tag, TagResponse>();
            CreateMap<Grupo, GrupoResponse>();
            CreateMap<GrupoPreguntaAsa, GrupoPreguntaAsaResponse>();
            CreateMap<Programa, ProgramaResponse>();
            CreateMap<ImagenAsa, ImagenAsaResponse>();
            CreateMap<EstadoPreguntaAsa, EstadoPreguntaAsaResponse>();
            CreateMap<ConfiguracionPreguntaAsa, ConfiguracionPreguntaAsaResponse>();
            CreateMap<Estudiante, EstudianteResponse>();
            CreateMap<EstudianteGrupo, EstudianteGrupoResponse>();
            CreateMap<EstudiantePrograma, EstudianteProgramaResponse>();
            CreateMap<MenuSubModuloWeb, MenuSubModulosWebResponse>();
            
            CreateMap<PreguntaAsaImagenAsa, PreguntaAsaImagenAsaResponse>();
            CreateMap<IdentityUser, IdentityUserResponse>();
            CreateMap<PreguntaAsaOpcion, PreguntaAsaOpcionResponse>();
            CreateMap<RespuestasAsa, RespuestasAsaResponse>();
        }
    }
}
