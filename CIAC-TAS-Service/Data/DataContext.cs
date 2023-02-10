using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain.Menu;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Data
{
    public class DataContext : IdentityDbContext
    {
        //dotnet ef migrations add "Added_UserId_InPosts" ---Command
        //dotnet ef database update ---Command
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

            builder.Entity<RespuestasAsaConsolidado>()
                .HasKey(r => new { r.Id, r.LoteRespuestasId });



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


            //Script para llenar las preguntasAsa
            //INSERT INTO[CIAC_TAS_DEV].[dbo].[PreguntaAsa]
            //(NumeroPregunta, Pregunta, GrupoPreguntaAsaId, EstadoPreguntaAsaId, Ruta)
            //Select ASAPregunta.NroPregunta, ASAPregunta.Pregunta,
            // CAST(
            //  CASE
            //     WHEN ASAPregunta.GrupoPregunta = 'AIRFRAME'
            //         THEN 1
            //     WHEN ASAPregunta.GrupoPregunta = 'GENERAL'

            //        THEN 2
            //     ELSE 3
            //  END AS bit) as GrupoPreguntaId,
            //  1 as EstadoPreguntaAsaId, '' as Ruta
            //From[PROSIANAdministrador2018].[dbo].[ASAPregunta] AS ASAPregunta;



            //            INSERT INTO[CIAC_TAS_DEV].[dbo].[PreguntaAsaOpcion]
            //Select ASAPreguntaRespuesta.Opcion, ASAPreguntaRespuesta.Respuesta, ASAPreguntaRespuesta.Correcto, PreguntaAsa.Id as PreguntaAsaId
            //From[PROSIANAdministrador2018].[dbo].[ASAPreguntaRespuesta] AS ASAPreguntaRespuesta
            //JOIN[CIAC_TAS_DEV].[dbo].[PreguntaAsa] ON ASAPreguntaRespuesta.NroPregunta = PreguntaAsa.NumeroPregunta;


            //RoleId need to be changed depends on what was generated
            //Insert INTO MenuModulosWeb
            //(RoleId, Nombre, Estilo)
            //VALUES
            //(, 'Usuarios', 'fa-users'),
            //(, 'Estudiantes', 'fa-book'),
            //(, 'ASA', 'fa-list'),
            //(para el estudiante, 'ASA', 'fa-list');

            // Submodulos, check the ModuloId
            //Insert INTO MenuSubModulosWeb
            //(ModuloId, Nombre, Pagina, Estilo)
            //VALUES
            //(, 'Usuarios Lista', '/Usuario/Usuarios', ''),
            //(, 'Estudiantes Lista', '/Estudiante/Estudiantes', ''),
            //(, 'ASA Configuracion', '/ASA/Configuracion', ''),
            //(, 'ASA Pregunta', '/ASA/PreguntasAsa', '')
            //(, 'Cuestionario ASA', '/ASA/CuestionarioASA', '');
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
    }
}