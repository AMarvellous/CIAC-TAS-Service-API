using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CIAC_TAS_Service.Domain.General;

namespace CIAC_TAS_Service.Domain.ASA
{
	public class ExamenGenerado
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int GrupoId { get; set; }
		public Guid ExamenGeneradoGuid { get; set; }
		public DateTime Fecha { get; set; }
		public int NumeroPregunta { get; set; }
		public string PreguntaTexto { get; set; }
		public int NumeroOpcion { get; set; }
		public string OpcionTexto { get; set; }

		[ForeignKey(nameof(GrupoId))]
		public virtual Grupo Grupos { get; set; }
	}
}
