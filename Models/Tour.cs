using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaDeDavid.Models
{
	public class Tour
	{
		public int ID { get; set; }

		[Required(ErrorMessage = "El nombre del tour es obligatorio.")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "El precio es obligatorio.")]
		[Column(TypeName = "decimal(10,2)")]
		public decimal Precio { get; set; }

		[Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
		[DataType(DataType.Date)]
		public DateTime FechaInicio { get; set; }

		[Required(ErrorMessage = "La hora de inicio es obligatoria.")]
		[DataType(DataType.Time)]
		public TimeSpan HoraInicio { get; set; }

		// Relaciones
		[Required]
		public int PaisID { get; set; }
		public Pais Pais { get; set; }

		[Required]
		public int DestinoID { get; set; }
		public Destino Destino { get; set; }

		// Cálculos automáticos (no se mapean a base de datos)
		[NotMapped]
		public decimal ITBIS => Precio * 0.18M;

		[NotMapped]
		public TimeSpan Duracion => Destino?.Duracion ?? TimeSpan.Zero;

		[NotMapped]
		public DateTime FechaFin => FechaInicio.Date + HoraInicio + Duracion;

		[NotMapped]
		public string Estado => DateTime.Now < FechaFin ? "Vigente" : "Finalizado";

		public int TourID { get; internal set; }
	}
}
