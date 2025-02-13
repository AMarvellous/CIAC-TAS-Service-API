﻿using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
                });
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DataContext>();
            services.AddScoped<IIdentityRoleService, IdentityRoleService>();

            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IGrupoService, GrupoService>();
            services.AddScoped<IGrupoPreguntaAsaService, GrupoPreguntaAsaService>();
            services.AddScoped<IProgramaService, ProgramaService>();
            services.AddScoped<IImagenAsaService, ImagenAsaService>();
            services.AddScoped<IEstadoPreguntaAsaService, EstadoPreguntaAsaService>();
            services.AddScoped<IConfiguracionPreguntaAsaService, ConfiguracionPreguntaAsaService>();
            services.AddScoped<IEstudianteService, EstudianteService>();
            services.AddScoped<IEstudianteGrupoService, EstudianteGrupoService>();
            services.AddScoped<IEstudianteProgramaService, EstudianteProgramaService>();
            services.AddScoped<IMenuModulosWebService, MenuModulosWebService>();
            services.AddScoped<IMenuSubModulosWebService, MenuSubModulosWebService>();
            services.AddScoped<IPreguntaAsaService, PreguntaAsaService>();
            services.AddScoped<IPreguntaAsaImagenAsaService, PreguntaAsaImagenAsaService>();
            services.AddScoped<IPreguntaAsaOpcionService, PreguntaAsaOpcionService>();
            services.AddScoped<IRespuestasAsaService, RespuestasAsaService>();
            services.AddScoped<IRespuestasAsaConsolidadoService, RespuestasAsaConsolidadoService>();
			services.AddScoped<IExamenGeneradoService, ExamenGeneradoService>();
            services.AddScoped<IInstructorService, InstructorService>();
            services.AddScoped<IAdministrativoService, AdministrativoService>();
            services.AddScoped<IMateriaService, MateriaService>();
            services.AddScoped<IModuloService, ModuloService>();
            services.AddScoped<IModuloMateriaService, ModuloMateriaService>();
            services.AddScoped<IAsistenciaEstudianteHeaderService, AsistenciaEstudianteHeaderService>();
            services.AddScoped<IAsistenciaEstudianteService, AsistenciaEstudianteService>();
            services.AddScoped<IEstudianteMateriaService, EstudianteMateriaService>();
            services.AddScoped<ITipoAsistenciaService, TipoAsistenciaService>();
            services.AddScoped<IProgramaAnaliticoPdfService, ProgramaAnaliticoPdfService>();
            services.AddScoped<IInstructorMateriaService, InstructorMateriaService>();
            services.AddScoped<IInstructorProgramaAnaliticoService, InstructorProgramaAnaliticoService>();
            services.AddScoped<IRegistroNotaHeaderService, RegistroNotaHeaderService>();
            services.AddScoped<IRegistroNotaEstudianteHeaderService, RegistroNotaEstudianteHeaderService>();
            services.AddScoped<IRegistroNotaEstudianteService, RegistroNotaEstudianteService>();
            services.AddScoped<ITipoRegistroNotaEstudianteService, TipoRegistroNotaEstudianteService>();
            services.AddScoped<ITipoRegistroNotaHeaderService, TipoRegistroNotaHeaderService>();
            services.AddScoped<IInhabilitacionEstudianteService, InhabilitacionEstudianteService>();
            services.AddScoped<ICierreMateriaService, CierreMateriaService>();
            services.AddScoped<ITipoAsistenciaEstudianteHeaderService, TipoAsistenciaEstudianteHeaderService>();
        }
    }
}
