using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgenciaDeDavid.Models
{
	public class Pais
	{
		internal readonly object ID;

		[Key]
		public int PaisID { get; set; } // Clave primaria

		[Required(ErrorMessage = "El campo Nombre es obligatorio.")]
		[StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
		public string Nombre { get; set; }

		// Relación: Un país tiene muchos tours
		public ICollection<Tour> Tours { get; set; } = new List<Tour>();
		public string Ciudad { get; internal set; }
		//public string Ciudad { get; set; }
	}
}
