using AutoMapper;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain.InstructorDomain;
using CIAC_TAS_Service.Domain.Menu;
using Microsoft.AspNetCore.Identity;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

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

            CreateMap<EstudianteMateria, EstudianteMateriaResponse>()
                .ForMember(
                    x => x.EstudianteResponse,
                    opt => opt.MapFrom(s => s.Estudiante))
                .ForMember(
                    x => x.GrupoResponse,
                    opt => opt.MapFrom(s => s.Grupo))
                .ForMember(
                    x => x.MateriaResponse,
                    opt => opt.MapFrom(s => s.Materia));

            CreateMap<RespuestasAsaConsolidado, RespuestasAsaConsolidadoResponse>()
                .ForMember(
                    x => x.ConfiguracionPreguntaAsaResponse,
                    opt => opt.MapFrom(s => s.ConfiguracionPreguntaAsa)
                );

            CreateMap<ExamenGenerado, ExamenGeneradoResponse>()
                .ForMember(x => x.GrupoResponse,
                opt => opt.MapFrom(s => s.Grupos));

            CreateMap<ModuloMateria, ModuloMateriaResponse>()
                .ForMember(
                    x => x.ModuloResponse,
                    opt => opt.MapFrom(m => m.Modulo))
                .ForMember(
                    x => x.MateriaResponse,
                    opt => opt.MapFrom(m => m.Materia));

            CreateMap<AsistenciaEstudianteHeader, AsistenciaEstudianteHeaderResponse>()
                .ForMember(
                    x => x.ProgramaResponse,
                    opt => opt.MapFrom(m => m.Programa))
                .ForMember(
                    x => x.GrupoResponse,
                    opt => opt.MapFrom(m => m.Grupo))
                .ForMember(
                    x => x.MateriaResponse,
                    opt => opt.MapFrom(m => m.Materia))
                .ForMember(
                    x => x.ModuloResponse,
                    opt => opt.MapFrom(m => m.Modulo))
                .ForMember(
                    x => x.InstructorResponse,
                    opt => opt.MapFrom(m => m.Instructor))
                .ForMember(
                    x => x.TipoAsistenciaEstudianteHeaderResponse,
                    opt => opt.MapFrom(m => m.TipoAsistenciaEstudianteHeader))
                .ForMember(
                    x => x.AsistenciaEstudiantesResponse,
                    opt => opt.MapFrom(m => m.AsistenciaEstudiantes));

            CreateMap<CierreMateria, CierreMateriaResponse>()
                .ForMember(
                    x => x.Grupo,
                    opt => opt.MapFrom(m => m.Grupo))
                .ForMember(
                    x => x.Materia,
                    opt => opt.MapFrom(m => m.Materia));

            CreateMap<AsistenciaEstudiante, AsistenciaEstudianteResponse>()
                .ForMember(
                    x => x.EstudianteResponse,
                    opt => opt.MapFrom(m => m.Estudiante))
                .ForMember(
                    x => x.TipoAsistenciaResponse,
                    opt => opt.MapFrom(m => m.TipoAsistencia));

            CreateMap<Estudiante, EstudianteResponse>();

            CreateMap<RegistroNotaEstudiante, RegistroNotaEstudianteResponse>()
                .ForMember(
                    x => x.TipoRegistroNotaEstudiante,
                    opt => opt.MapFrom(m => m.TipoRegistroNotaEstudiante));

            CreateMap<RegistroNotaEstudianteHeader, RegistroNotaEstudianteHeaderResponse>()
                .ForMember(
                    x => x.Estudiante,
                    opt => opt.MapFrom(m => m.Estudiante))
                .ForMember(
                    x => x.RegistroNotaEstudiantes,
                    opt => opt.MapFrom(m => m.RegistroNotaEstudiantes));
                //.ForMember(
                //    x => x.RegistroNotaEstudiantes,
                //    opt => opt.MapFrom(
                //        src => src.RegistroNotaEstudiantes.Select(x => new RegistroNotaEstudianteResponse
                //        {
                //            Id = x.Id,
                //            RegistroNotaEstudianteHeaderId = x.RegistroNotaEstudianteHeaderId,
                //            Nota = x.Nota,
                //            TipoRegistroNotaEstudianteId = x.TipoRegistroNotaEstudianteId,
                //            TipoRegistroNotaEstudiante = new TipoRegistroNotaEstudianteResponse
                //            {
                //                Id = x.TipoRegistroNotaEstudiante.Id,
                //                Nombre = x.TipoRegistroNotaEstudiante.Nombre,
                //            }
                //        })));

            CreateMap<RegistroNotaHeader, RegistroNotaHeaderResponse>()
                .ForMember(
                    x => x.Programa,
                    opt => opt.MapFrom(m => m.Programa))
                .ForMember(
                    x => x.Grupo,
                    opt => opt.MapFrom(m => m.Grupo))
                .ForMember(
                    x => x.Materia,
                    opt => opt.MapFrom(m => m.Materia))
                .ForMember(
                    x => x.Modulo,
                    opt => opt.MapFrom(m => m.Modulo))
                .ForMember(
                    x => x.Instructor,
                    opt => opt.MapFrom(m => m.Instructor))
                .ForMember(
                    x => x.TipoRegistroNotaHeader,
                    opt => opt.MapFrom(m => m.TipoRegistroNotaHeader))
                .ForMember(
                    x => x.RegistroNotaEstudianteHeaders,
                    opt => opt.MapFrom(m => m.RegistroNotaEstudianteHeaders));

            CreateMap<InhabilitacionEstudiante, InhabilitacionEstudianteResponse>()
                .ForMember(
                    x => x.Estudiante,
                    opt => opt.MapFrom(m => m.Estudiante));

            CreateMap<Tag, TagResponse>();
            CreateMap<Grupo, GrupoResponse>();
            CreateMap<GrupoPreguntaAsa, GrupoPreguntaAsaResponse>();
            CreateMap<Programa, ProgramaResponse>();
            CreateMap<ImagenAsa, ImagenAsaResponse>();
            CreateMap<EstadoPreguntaAsa, EstadoPreguntaAsaResponse>();            
            CreateMap<EstudiantePrograma, EstudianteProgramaResponse>();
            CreateMap<MenuSubModuloWeb, MenuSubModulosWebResponse>();
            CreateMap<PreguntaAsaImagenAsa, PreguntaAsaImagenAsaResponse>();
            CreateMap<IdentityUser, IdentityUserResponse>();
            CreateMap<PreguntaAsaOpcion, PreguntaAsaOpcionResponse>();
            CreateMap<RespuestasAsa, RespuestasAsaResponse>();
            CreateMap<Instructor, InstructorResponse>();
            CreateMap<Administrativo, AdministrativoResponse>();
            CreateMap<Materia, MateriaResponse>();
            CreateMap<Modulo, ModuloResponse>();
            CreateMap<TipoAsistencia, TipoAsistenciaResponse>();
            CreateMap<ProgramaAnaliticoPdf, ProgramaAnaliticoPdfResponse>();
            CreateMap<InstructorMateria, InstructorMateriaResponse>();
            CreateMap<InstructorProgramaAnalitico, InstructorProgramaAnaliticoResponse>();
            CreateMap<TipoRegistroNotaEstudiante, TipoRegistroNotaEstudianteResponse>();
            CreateMap<TipoRegistroNotaHeader, TipoRegistroNotaHeaderResponse>();
            CreateMap<TipoAsistenciaEstudianteHeader, TipoAsistenciaEstudianteHeaderResponse>();
        }
    }
}
