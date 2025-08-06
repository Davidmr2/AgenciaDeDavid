using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaDeDavid.Models
{
	public class Destino
	{
		private string ciudad = string.Empty;

		[Key]
		public int DestinoID { get; set; }

		[Required(ErrorMessage = "El nombre es obligatorio")]
		[StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
		public string Nombre { get; set; }
		private string ciudad1;

		

		public string GetCiudad()
		{
			return ciudad1;
		}

		public void SetCiudad(string value)
		{
			ciudad1 = value;
		}



		public string LugarTuristico { get; set; }



		// Clave foránea
		[Required(ErrorMessage = "El país es obligatorio")]
		[ForeignKey("Pais")]
		public int PaisID { get; set; }
		public string Ciudad { get; set; }
		// Navegación hacia país
		public Pais Pais { get; set; }

		// Relación con los tours
		public ICollection<Tour> Tours { get; set; }
		[Required]
		
		[Display(Name = "Duración")]
		public TimeSpan Duracion { get; set; }

	}
}
