using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain.Menu;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;
using System.Collections.Generic;
using System.Xml.Linq;
using CIAC_TAS_Service.Domain.InstructorDomain;

namespace CIAC_TAS_Service.Data
{
    public class DataContext : IdentityDbContext
    {
		//dotnet ef migrations add "Added_UserId_InPosts" ---Command
		//dotnet ef database update ---Command
		// Remove-migration if the database update was not run
		// dotnet ef migrations remove   in order to remove the last migration applied 
		public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {          
            base.OnModelCreating(builder);

            builder.Entity<EstudianteGrupo>()
                .HasKey(eg => new {eg.EstudianteId, eg.GrupoId});
            builder.Entity<EstudianteGrupo>()
                .HasOne<Estudiante>(eg => eg.Estudiante)
                .WithMany(e => e.EstudianteGrupos)
                .HasForeignKey(eg => eg.EstudianteId);
            builder.Entity<EstudianteGrupo>()
                .HasOne<Grupo>(eg => eg.Grupo)
                .WithMany(g => g.EstudianteGrupos)
                .HasForeignKey(eg => eg.GrupoId);

            builder.Entity<PreguntaAsaImagenAsa>()
                .HasKey(pi => new { pi.PreguntaAsaId, pi.ImagenAsaId });
            builder.Entity<PreguntaAsaImagenAsa>()
                .HasOne(pi => pi.PreguntaAsa)
                .WithMany(p => p.PreguntaAsaImagenAsas)
                .HasForeignKey(pi => pi.PreguntaAsaId);
            builder.Entity<PreguntaAsaImagenAsa>()
                .HasOne(pi => pi.ImagenAsa)
                .WithMany(i => i.PreguntaAsaImagenAsas)
                .HasForeignKey(pi => pi.ImagenAsaId);

            builder.Entity<EstudiantePrograma>()
                .HasKey(ep => new { ep.EstudianteId, ep.ProgramaId });
            builder.Entity<EstudiantePrograma>()
                .HasOne(ep => ep.Estudiante)
                .WithMany(e => e.EstudianteProgramas)
                .HasForeignKey(ep => ep.EstudianteId);
            builder.Entity<EstudiantePrograma>()
                .HasOne(ep => ep.Programa)
                .WithMany(p => p.EstudianteProgramas)
                .HasForeignKey(ep => ep.ProgramaId);

            builder.Entity<ConfiguracionPreguntaAsa>()
                .HasIndex(x => x.GrupoId)
                .IsUnique(false);

            builder.Entity<Estudiante>()
                .HasIndex(x => x.UserId)
                .IsUnique();

            builder.Entity<PreguntaAsa>()
                .HasIndex(x => x.GrupoPreguntaAsaId)
                .IsUnique(false);
            builder.Entity<PreguntaAsa>()
                .HasIndex(x => x.EstadoPreguntaAsaId)
                .IsUnique(false);      
            
            builder.Entity<AsistenciaEstudiante>()
                .HasIndex(x => x.TipoAsistenciaId)
                .IsUnique(false);

            builder.Entity<RespuestasAsaConsolidado>()
                .HasKey(r => new { r.Id, r.LoteRespuestasId });

            builder.Entity<ModuloMateria>()
               .HasKey(eg => new { eg.ModuloId, eg.MateriaId });
            builder.Entity<ModuloMateria>()
                .HasOne<Modulo>(mm => mm.Modulo)
                .WithMany(e => e.ModuloMaterias)
                .HasForeignKey(mm => mm.ModuloId);
            builder.Entity<ModuloMateria>()
                .HasOne<Materia>(mm => mm.Materia)
                .WithMany(m => m.ModuloMaterias)
                .HasForeignKey(mm => mm.MateriaId);

            builder.Entity<EstudianteMateria>()
                .HasKey(eg => new { eg.EstudianteId, eg.GrupoId, eg.MateriaId });
            builder.Entity<EstudianteMateria>()
                .HasOne<Estudiante>(eg => eg.Estudiante)
                .WithMany(e => e.EstudianteMaterias)
                .HasForeignKey(eg => eg.EstudianteId);
            builder.Entity<EstudianteMateria>()
                .HasOne<Grupo>(eg => eg.Grupo)
                .WithMany(e => e.EstudianteMaterias)
                .HasForeignKey(eg => eg.GrupoId);
            builder.Entity<EstudianteMateria>()
                .HasOne<Materia>(eg => eg.Materia)
                .WithMany(g => g.EstudianteMaterias)
                .HasForeignKey(eg => eg.MateriaId);

            builder.Entity<RespuestasAsa>()
                .HasOne<PreguntaAsa>(p => p.PreguntaAsa)
                .WithMany(e => e.RespuestasAsas)
                .HasForeignKey(eg => eg.PreguntaAsaId);

            builder.Entity<InstructorMateria>()
                .HasKey(im => new { im.InstructorId, im.GrupoId, im.MateriaId });

            builder.Entity<InstructorProgramaAnalitico>()
                .HasKey(ipa => new { ipa.InstructorId, ipa.ProgramaAnaliticoPdfId });


            builder.Entity<TipoAsistencia>()
                .HasData(
                new TipoAsistencia { Id = 1, Nombre = "Presente" },
                new TipoAsistencia { Id = 2, Nombre = "Justificada" },
                new TipoAsistencia { Id = 3, Nombre = "Injustificada" }
                );
            builder.Entity<GrupoPreguntaAsa>()
                .HasData(
                new Domain.ASA.GrupoPreguntaAsa { Id = 1, Nombre = "AIRFRAME" },
                new Domain.ASA.GrupoPreguntaAsa { Id = 2,Nombre = "GENERAL" },
                new Domain.ASA.GrupoPreguntaAsa { Id = 3, Nombre = "POWERPLANT" }
                );
            builder.Entity<EstadoPreguntaAsa>()
                .HasData(
                new EstadoPreguntaAsa { Id = 1, Estado = 'A'},
                new EstadoPreguntaAsa { Id = 2, Estado = 'I' }
                );

            builder.Entity<Programa>()
                .HasData(
                new Programa {Id = 1, Nombre = "TMA" });

            builder.Entity<Modulo>()
                .HasData(
                new Modulo { Id = 1, ModuloCodigo = "1", Nombre = "Modulo 1" },
                new Modulo { Id = 2, ModuloCodigo = "2", Nombre = "Modulo 2" },
                new Modulo { Id = 3, ModuloCodigo = "3", Nombre = "Modulo 3" },
                new Modulo { Id = 4, ModuloCodigo = "4", Nombre = "Modulo 4" },
                new Modulo { Id = 5, ModuloCodigo = "5", Nombre = "Modulo 5" },
                new Modulo { Id = 6, ModuloCodigo = "6", Nombre = "Modulo 6" },
                new Modulo { Id = 7, ModuloCodigo = "7", Nombre = "Modulo 7" },
                new Modulo { Id = 8, ModuloCodigo = "8", Nombre = "Modulo 8" },
                new Modulo { Id = 9, ModuloCodigo = "9", Nombre = "Modulo 9" },
                new Modulo { Id = 10, ModuloCodigo = "10", Nombre = "Modulo 10" },
                new Modulo { Id = 11, ModuloCodigo = "11", Nombre = "Modulo 11" },
                new Modulo { Id = 12, ModuloCodigo = "12", Nombre = "Modulo 12" });

            builder.Entity<Materia>()
                .HasData(
                new Materia { Id = 1, MateriaCodigo = "1.1", Nombre = "Requerimientos, Leyes y Reglamentos de Aviación Civil" },
                new Materia { Id = 2, MateriaCodigo = "2.1", Nombre = "Matemáticas" },
                new Materia { Id = 3, MateriaCodigo = "2.2", Nombre = "Física" },
                new Materia { Id = 4, MateriaCodigo = "2.3", Nombre = "Química" },
                new Materia { Id = 5, MateriaCodigo = "2.4", Nombre = "Dibujo Técnico" },
                new Materia { Id = 6, MateriaCodigo = "2.5", Nombre = "Control de vuelo y aerodinámica en ala fija y helicóptero" },
                new Materia { Id = 7, MateriaCodigo = "2.6", Nombre = "Peso y balance" },
                new Materia { Id = 8, MateriaCodigo = "2.7", Nombre = "Lineas de fluidos y terminales" },
                new Materia { Id = 9, MateriaCodigo = "3.1", Nombre = "Materiales y Procesos" },
                new Materia { Id = 10, MateriaCodigo = "3.2", Nombre = "Electricidad básica" },
                new Materia { Id = 11, MateriaCodigo = "3.3", Nombre = "Soldadura" },
                new Materia { Id = 12, MateriaCodigo = "3.4", Nombre = "Corrosión" },
                new Materia { Id = 13, MateriaCodigo = "3.5", Nombre = "Operación y servicio en tierra" },
                new Materia { Id = 14, MateriaCodigo = "3.6", Nombre = "Ensayos no destructivos" },
                new Materia { Id = 15, MateriaCodigo = "3.7", Nombre = "Estructuras I" },
                new Materia { Id = 16, MateriaCodigo = "3.8", Nombre = "Sistema de tren de aterrizaje" },
                new Materia { Id = 17, MateriaCodigo = "3.9", Nombre = "Sistema hidráulico y neumático" },
                new Materia { Id = 18, MateriaCodigo = "3.10", Nombre = "Sistema de control atmosférico (cabina)" },
                new Materia { Id = 19, MateriaCodigo = "3.11", Nombre = "Sistema de combustible" },
                new Materia { Id = 20, MateriaCodigo = "3.12", Nombre = "Sistema de control de lluvia y hielo" },
                new Materia { Id = 21, MateriaCodigo = "3.13", Nombre = "Sistema de protección de fuego" },
                new Materia { Id = 22, MateriaCodigo = "3.14", Nombre = "Estructuras II" },
                new Materia { Id = 23, MateriaCodigo = "4.1", Nombre = "Motores recíprocos" },
                new Materia { Id = 24, MateriaCodigo = "4.2", Nombre = "Hélices" },
                new Materia { Id = 25, MateriaCodigo = "4.3", Nombre = "Motores a turbina" },
                new Materia { Id = 26, MateriaCodigo = "4.4", Nombre = "Sistema de combustible" },
                new Materia { Id = 27, MateriaCodigo = "5.1", Nombre = "Materiales y prácticas de mantenimiento" },
                new Materia { Id = 28, MateriaCodigo = "5.2", Nombre = "Fundamentos de Electricidad y Electrónica" },
                new Materia { Id = 29, MateriaCodigo = "5.3", Nombre = "Técnicas digitales, computadoras y dispositivos asociados" },
                new Materia { Id = 30, MateriaCodigo = "5.4", Nombre = "Sistemas eléctricos de aeronaves" },
                new Materia { Id = 31, MateriaCodigo = "5.5", Nombre = "Sistemas de instrumentos de aeronaves" },
                new Materia { Id = 32, MateriaCodigo = "6.1", Nombre = "Sistemas automáticos de control de vuelo (AFCS): Ala Fija y Rotatoria" },
                new Materia { Id = 33, MateriaCodigo = "6.2", Nombre = "Sistemas de navegación Inercial de aeronaves (INS)" },
                new Materia { Id = 34, MateriaCodigo = "6.3", Nombre = "Sistemas de radio y radio navegación de aeronaves" },
                new Materia { Id = 35, MateriaCodigo = "7.1", Nombre = "Actuación humana" },
                new Materia { Id = 36, MateriaCodigo = "8.1", Nombre = "Prácticas de habilidades de mantenimiento: Célula" },
                new Materia { Id = 37, MateriaCodigo = "9.1", Nombre = "Prácticas de habilidades de mantenimiento: Sistema Motopropulsor" },
                new Materia { Id = 38, MateriaCodigo = "10.1", Nombre = "Prácticas de habilidades de mantenimiento: Aviónica, Electricidad, instrumentos, radio y vuelo automático." },
                new Materia { Id = 39, MateriaCodigo = "11.1", Nombre = "Prácticas aplicadas a las operaciones de mantenimiento de Línea" },
                new Materia { Id = 40, MateriaCodigo = "11.2", Nombre = "Prácticas aplicadas a las operaciones de producción de Base" },
                new Materia { Id = 41, MateriaCodigo = "12.1", Nombre = "Inglés" });

            builder.Entity<ModuloMateria>()
                .HasData(
                new ModuloMateria { ModuloId = 1, MateriaId = 1 },
                new ModuloMateria { ModuloId = 2, MateriaId = 2 },
                new ModuloMateria { ModuloId = 2, MateriaId = 3 },
                new ModuloMateria { ModuloId = 2, MateriaId = 4 },
                new ModuloMateria { ModuloId = 2, MateriaId = 5 },
                new ModuloMateria { ModuloId = 2, MateriaId = 6 },
                new ModuloMateria { ModuloId = 2, MateriaId = 7 },
                new ModuloMateria { ModuloId = 2, MateriaId = 8 },
                new ModuloMateria { ModuloId = 3, MateriaId = 9 },
                new ModuloMateria { ModuloId = 3, MateriaId = 10 },
                new ModuloMateria { ModuloId = 3, MateriaId = 11 },
                new ModuloMateria { ModuloId = 3, MateriaId = 12 },
                new ModuloMateria { ModuloId = 3, MateriaId = 13 },
                new ModuloMateria { ModuloId = 3, MateriaId = 14 },
                new ModuloMateria { ModuloId = 3, MateriaId = 15 },
                new ModuloMateria { ModuloId = 3, MateriaId = 16 },
                new ModuloMateria { ModuloId = 3, MateriaId = 17 },
                new ModuloMateria { ModuloId = 3, MateriaId = 18 },
                new ModuloMateria { ModuloId = 3, MateriaId = 19 },
                new ModuloMateria { ModuloId = 3, MateriaId = 20 },
                new ModuloMateria { ModuloId = 3, MateriaId = 21 },
                new ModuloMateria { ModuloId = 3, MateriaId = 22 },
                new ModuloMateria { ModuloId = 4, MateriaId = 23 },
                new ModuloMateria { ModuloId = 4, MateriaId = 24 },
                new ModuloMateria { ModuloId = 4, MateriaId = 25 },
                new ModuloMateria { ModuloId = 4, MateriaId = 26 },
                new ModuloMateria { ModuloId = 5, MateriaId = 27 },
                new ModuloMateria { ModuloId = 5, MateriaId = 28 },
                new ModuloMateria { ModuloId = 5, MateriaId = 29 },
                new ModuloMateria { ModuloId = 5, MateriaId = 30 },
                new ModuloMateria { ModuloId = 5, MateriaId = 31 },
                new ModuloMateria { ModuloId = 6, MateriaId = 32 },
                new ModuloMateria { ModuloId = 6, MateriaId = 33 },
                new ModuloMateria { ModuloId = 6, MateriaId = 34 },
                new ModuloMateria { ModuloId = 7, MateriaId = 35 },
                new ModuloMateria { ModuloId = 8, MateriaId = 36 },
                new ModuloMateria { ModuloId = 9, MateriaId = 37 },
                new ModuloMateria { ModuloId = 10, MateriaId = 38 },
                new ModuloMateria { ModuloId = 11, MateriaId = 39 },
                new ModuloMateria { ModuloId = 11, MateriaId = 40 },
                new ModuloMateria { ModuloId = 12, MateriaId = 41 });

            builder.Entity<TipoRegistroNotaHeader>()
                .HasData(
                new TipoRegistroNotaHeader { Id = 1, Nombre = "Regular" },
                new TipoRegistroNotaHeader { Id = 2, Nombre = "Tutorial" });

            builder.Entity<TipoAsistenciaEstudianteHeader>()
               .HasData(
               new TipoAsistenciaEstudianteHeader { Id = 1, Nombre = "Regular" },
               new TipoAsistenciaEstudianteHeader { Id = 2, Nombre = "Tutorial" });

            builder.Entity<TipoRegistroNotaEstudiante>()
                .HasData(
                new TipoRegistroNotaEstudiante { Id = 1, Nombre = "Progreso" },
                new TipoRegistroNotaEstudiante { Id = 2, Nombre = "Dominio" },
                new TipoRegistroNotaEstudiante { Id = 3, Nombre = "Recuperatorio" });

            //Script para llenar las preguntasAsa
            //INSERT INTO[CIAC_TAS_DEV].[dbo].[PreguntaAsa]
            //(NumeroPregunta, Pregunta, GrupoPreguntaAsaId, EstadoPreguntaAsaId, Ruta)
            //Select ASAPregunta.NroPregunta, ASAPregunta.Pregunta,
            //(CASE
            //     WHEN ASAPregunta.GrupoPregunta = 'AIRFRAME'
            //         THEN 1
            //     WHEN ASAPregunta.GrupoPregunta = 'GENERAL'
            //        THEN 2
            //     ELSE 3

            // END)as GrupoPreguntaId,
            //  1 as EstadoPreguntaAsaId, '' as Ruta
            //From[CIAC_TAS_OLD].[dbo].[ASAPregunta] AS ASAPregunta;



            //            INSERT INTO[CIAC_TAS_DEV].[dbo].[PreguntaAsaOpcion]
            //Select ASAPreguntaRespuesta.Opcion, ASAPreguntaRespuesta.Respuesta, ASAPreguntaRespuesta.Correcto, PreguntaAsa.Id as PreguntaAsaId
            //From[PROSIANAdministrador2018].[dbo].[ASAPreguntaRespuesta] AS ASAPreguntaRespuesta
            //JOIN[CIAC_TAS_DEV].[dbo].[PreguntaAsa] ON ASAPreguntaRespuesta.NroPregunta = PreguntaAsa.NumeroPregunta;


            //RoleId need to be changed depends on what was generated
            //Insert INTO MenuModulosWeb
            //INSERT[dbo].[MenuModulosWeb]( [RoleId], [Nombre], [Estilo]) VALUES((SELECT Id FROM AspNetRoles Where Name = 'Admin'), N'Usuarios', N'fa-users')
            //INSERT[dbo].[MenuModulosWeb]( [RoleId], [Nombre], [Estilo]) VALUES((SELECT Id FROM AspNetRoles Where Name = 'Admin'), N'Estudiantes', N'fa-book')
            //INSERT[dbo].[MenuModulosWeb]( [RoleId], [Nombre], [Estilo]) VALUES((SELECT Id FROM AspNetRoles Where Name = 'Admin'), N'ASA', N'fa-list')
            //INSERT[dbo].[MenuModulosWeb]( [RoleId], [Nombre], [Estilo]) VALUES((SELECT Id FROM AspNetRoles Where Name = 'Estudiante'), N'ASA', N'fa-list')
            //INSERT[dbo].[MenuModulosWeb]( [RoleId], [Nombre], [Estilo]) VALUES((SELECT Id FROM AspNetRoles Where Name = 'Admin'), N'Instructores', N'fa-chalkboard-teacher')

            //INSERT[dbo].[MenuSubModulosWeb]([ModuloId], [Nombre], [Pagina], [Estilo]) VALUES(1, N'Usuarios Lista', N'/Usuario/Usuarios', N'')
            //INSERT[dbo].[MenuSubModulosWeb]([ModuloId], [Nombre], [Pagina], [Estilo]) VALUES(2, N'Estudiantes Lista', N'/Estudiante/Estudiantes', N'')
            //INSERT[dbo].[MenuSubModulosWeb]([ModuloId], [Nombre], [Pagina], [Estilo]) VALUES(3, N'ASA Configuracion', N'/ASA/Configuracion', N'')
            //INSERT[dbo].[MenuSubModulosWeb]( [ModuloId], [Nombre], [Pagina], [Estilo]) VALUES(3, N'ASA Pregunta', N'/ASA/PreguntasAsa', N'')
            //INSERT[dbo].[MenuSubModulosWeb]( [ModuloId], [Nombre], [Pagina], [Estilo]) VALUES(4, N'Cuestionario ASA', N'/ASA/CuestionarioASA', N'')
            //INSERT[dbo].[MenuSubModulosWeb]( [ModuloId], [Nombre], [Pagina], [Estilo]) VALUES(3, N'Generar Examen', N'', N'')
            //INSERT[dbo].[MenuSubModulosWeb]( [ModuloId], [Nombre], [Pagina], [Estilo]) VALUES(3, N'Examen Reporte', N'', N'')
            //INSERT[dbo].[MenuSubModulosWeb]( [ModuloId], [Nombre], [Pagina], [Estilo]) VALUES(2, N'Asistencia Estudiante', N'', N'')
            //INSERT[dbo].[MenuSubModulosWeb]( [ModuloId], [Nombre], [Pagina], [Estilo]) VALUES(2, N'Grupos', N'', N'')
            //INSERT[dbo].[MenuSubModulosWeb]( [ModuloId], [Nombre], [Pagina], [Estilo]) VALUES(5, N'Instructores Lista', N'', N'')

            var foreignKeys = builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in foreignKeys)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<PreguntaAsa>()
                .HasOne(p => p.GrupoPreguntaAsa)
                .WithOne(p => p.PreguntaAsa)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<PreguntaAsaOpcion>()
                .HasOne(x => x.PreguntaAsa)
                .WithMany(p => p.PreguntaAsaOpciones)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<AsistenciaEstudiante>()
                .HasOne(x => x.TipoAsistencia)
                .WithMany(p => p.AsistenciaEstudiantes)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PreguntaAsa> PreguntaAsa { get; set; }
        public DbSet<GrupoPreguntaAsa> GrupoPreguntaAsa { get; set; }
        public DbSet<EstadoPreguntaAsa> EstadoPreguntaAsa { get; set; }
        public DbSet<ImagenAsa> ImagenAsa { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<EstudianteGrupo> EstudianteGrupo { get; set; }
        public DbSet<PreguntaAsaImagenAsa> PreguntaAsaImagenAsa { get; set; }
        public DbSet<ConfiguracionPreguntaAsa> ConfiguracionPreguntaAsa { get; set; }
        public DbSet<MenuModuloWeb> MenuModulosWeb { get; set; }
        public DbSet<MenuSubModuloWeb> MenuSubModulosWeb { get; set; }
        public DbSet<Programa> Programa { get; set; }
        public DbSet<EstudiantePrograma> EstudiantePrograma { get; set; }
        public DbSet<PreguntaAsaOpcion> PreguntaAsaOpcion { get; set; }
        public DbSet<RespuestasAsa> RespuestasAsas { get; set; }
        public DbSet<RespuestasAsaConsolidado> RespuestasAsaConsolidado { get; set; }
        public DbSet<ExamenGenerado> ExamenGenerado { get; set; }
        public DbSet<Administrativo> Administrativo { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<ModuloMateria> ModuloMateria { get; set; }
        public DbSet<AsistenciaEstudianteHeader> AsistenciaEstudianteHeader { get; set; }
        public DbSet<AsistenciaEstudiante> AsistenciaEstudiante { get; set; }
        public DbSet<EstudianteMateria> EstudianteMateria { get; set; }
        public DbSet<TipoAsistencia> TipoAsistencia { get; set; }
        public DbSet<InstructorMateria> InstructorMateria { get; set; }
        public DbSet<ProgramaAnaliticoPdf> ProgramaAnaliticoPdf { get; set; }
        public DbSet<InstructorProgramaAnalitico> InstructorProgramaAnalitico { get; set; }
        public DbSet<RegistroNotaHeader> RegistroNotaHeader { get; set; }
        public DbSet<RegistroNotaEstudianteHeader> RegistroNotaEstudianteHeader { get; set; }
        public DbSet<RegistroNotaEstudiante> RegistroNotaEstudiante { get; set; }
        public DbSet<TipoRegistroNotaEstudiante> TipoRegistroNotaEstudiante { get; set; }
        public DbSet<TipoRegistroNotaHeader> TipoRegistroNotaHeader { get; set; }
        public DbSet<InhabilitacionEstudiante> InhabilitacionEstudiante { get; set; }
        public DbSet<CierreMateria> CierreMateria { get; set; }
        public DbSet<TipoAsistenciaEstudianteHeader> TipoAsistenciaEstudianteHeader { get; set; }
    }
}