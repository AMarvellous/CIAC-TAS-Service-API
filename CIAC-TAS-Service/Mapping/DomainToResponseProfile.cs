using AutoMapper;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain.General;

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

            CreateMap<Tag, TagResponse>();
            CreateMap<Grupo, GrupoResponse>();
            CreateMap<GrupoPreguntaAsa, GrupoPreguntaAsaResponse>();
            CreateMap<Programa, ProgramaResponse>();
            CreateMap<ImagenAsa, ImagenAsaResponse>();
            CreateMap<EstadoPreguntaAsa, EstadoPreguntaAsaResponse>();
            CreateMap<ConfiguracionPreguntaAsa, ConfiguracionPreguntaAsaResponse>();
            CreateMap<Estudiante, EstudianteResponse>();
        }
    }
}
