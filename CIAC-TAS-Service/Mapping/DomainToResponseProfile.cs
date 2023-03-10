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

            CreateMap<ConfiguracionPreguntaAsa, ConfiguracionPreguntaAsaResponse>()
                .ForMember(
                    x => x.GrupoResponse,
                    opt => opt.MapFrom(s => s.Grupo));

            CreateMap<EstudianteGrupo, EstudianteGrupoResponse>()
				.ForMember(
					x => x.EstudianteResponse,
					opt => opt.MapFrom(s => s.Estudiante))
				.ForMember(
					x => x.GrupoResponse,
					opt => opt.MapFrom(s => s.Grupo));

			CreateMap<RespuestasAsaConsolidado, RespuestasAsaConsolidadoResponse>()
                .ForMember(
                    x => x.ConfiguracionPreguntaAsaResponse,
                    opt => opt.MapFrom(s => s.ConfiguracionPreguntaAsa)
                );

			CreateMap<Tag, TagResponse>();
            CreateMap<Grupo, GrupoResponse>();
            CreateMap<GrupoPreguntaAsa, GrupoPreguntaAsaResponse>();
            CreateMap<Programa, ProgramaResponse>();
            CreateMap<ImagenAsa, ImagenAsaResponse>();
            CreateMap<EstadoPreguntaAsa, EstadoPreguntaAsaResponse>();            
            CreateMap<Estudiante, EstudianteResponse>();
            CreateMap<EstudiantePrograma, EstudianteProgramaResponse>();
            CreateMap<MenuSubModuloWeb, MenuSubModulosWebResponse>();
            
            CreateMap<PreguntaAsaImagenAsa, PreguntaAsaImagenAsaResponse>();
            CreateMap<IdentityUser, IdentityUserResponse>();
            CreateMap<PreguntaAsaOpcion, PreguntaAsaOpcionResponse>();
            CreateMap<RespuestasAsa, RespuestasAsaResponse>();            
        }
    }
}
