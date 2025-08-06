using Microsoft.EntityFrameworkCore;
using AgenciaDeDavid.Models;
using System;

namespace AgenciaDeDavid.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Pais> Paises { get; set; }
		public DbSet<Destino> Destinos { get; set; }
		public DbSet<Tour> Tours { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Seed Países con ciudad capital
			modelBuilder.Entity<Pais>().HasData(
				new Pais { PaisID = 1, Nombre = "República Dominicana", Ciudad = "Santo Domingo" },
				new Pais { PaisID = 2, Nombre = "México", Ciudad = "Ciudad de México" },
				new Pais { PaisID = 3, Nombre = "Estados Unidos", Ciudad = "Washington D.C." },
				new Pais { PaisID = 4, Nombre = "España", Ciudad = "Madrid" },
				new Pais { PaisID = 5, Nombre = "Francia", Ciudad = "París" },
				new Pais { PaisID = 6, Nombre = "Italia", Ciudad = "Roma" },
				new Pais { PaisID = 7, Nombre = "Japón", Ciudad = "Tokio" },
				new Pais { PaisID = 8, Nombre = "Brasil", Ciudad = "Brasilia" },
				new Pais { PaisID = 9, Nombre = "Tailandia", Ciudad = "Bangkok" },
				new Pais { PaisID = 10, Nombre = "Egipto", Ciudad = "El Cairo" },
				new Pais { PaisID = 11, Nombre = "Argentina", Ciudad = "Buenos Aires" },
				new Pais { PaisID = 12, Nombre = "Canadá", Ciudad = "Ottawa" },
				new Pais { PaisID = 13, Nombre = "Alemania", Ciudad = "Berlín" },
				new Pais { PaisID = 14, Nombre = "Australia", Ciudad = "Canberra" },
				new Pais { PaisID = 15, Nombre = "China", Ciudad = "Pekín" },
				new Pais { PaisID = 16, Nombre = "India", Ciudad = "Nueva Delhi" },
				new Pais { PaisID = 17, Nombre = "Grecia", Ciudad = "Atenas" },
				new Pais { PaisID = 18, Nombre = "Sudáfrica", Ciudad = "Pretoria" },
				new Pais { PaisID = 19, Nombre = "Colombia", Ciudad = "Bogotá" },
				new Pais { PaisID = 20, Nombre = "Perú", Ciudad = "Lima" }
			);

			// Seed Destinos con ciudad y lugar turístico
			modelBuilder.Entity<Destino>().HasData(
				new Destino { DestinoID = 1, Nombre = "Punta Cana", Ciudad = "Punta Cana", LugarTuristico = "Playa Bávaro", PaisID = 1 },
				new Destino { DestinoID = 2, Nombre = "Cancún", Ciudad = "Cancún", LugarTuristico = "Zona Hotelera", PaisID = 2 },
				new Destino { DestinoID = 3, Nombre = "Orlando", Ciudad = "Orlando", LugarTuristico = "Disney World", PaisID = 3 },
				new Destino { DestinoID = 4, Nombre = "Barcelona", Ciudad = "Barcelona", LugarTuristico = "Sagrada Familia", PaisID = 4 },
				new Destino { DestinoID = 5, Nombre = "París", Ciudad = "París", LugarTuristico = "Torre Eiffel", PaisID = 5 },
				new Destino { DestinoID = 6, Nombre = "Roma", Ciudad = "Roma", LugarTuristico = "Coliseo Romano", PaisID = 6 },
				new Destino { DestinoID = 7, Nombre = "Tokio", Ciudad = "Tokio", LugarTuristico = "Shibuya", PaisID = 7 },
				new Destino { DestinoID = 8, Nombre = "Río de Janeiro", Ciudad = "Río de Janeiro", LugarTuristico = "Cristo Redentor", PaisID = 8 },
				new Destino { DestinoID = 9, Nombre = "Bangkok", Ciudad = "Bangkok", LugarTuristico = "Templo Wat Arun", PaisID = 9 },
				new Destino { DestinoID = 10, Nombre = "El Cairo", Ciudad = "El Cairo", LugarTuristico = "Pirámides de Giza", PaisID = 10 },
				new Destino { DestinoID = 11, Nombre = "Buenos Aires", Ciudad = "Buenos Aires", LugarTuristico = "Barrio La Boca", PaisID = 11 },
				new Destino { DestinoID = 12, Nombre = "Toronto", Ciudad = "Toronto", LugarTuristico = "Torre CN", PaisID = 12 },
				new Destino { DestinoID = 13, Nombre = "Berlín", Ciudad = "Berlín", LugarTuristico = "Muro de Berlín", PaisID = 13 },
				new Destino { DestinoID = 14, Nombre = "Sídney", Ciudad = "Sídney", LugarTuristico = "Ópera de Sídney", PaisID = 14 },
				new Destino { DestinoID = 15, Nombre = "Pekín", Ciudad = "Pekín", LugarTuristico = "Ciudad Prohibida", PaisID = 15 },
				new Destino { DestinoID = 16, Nombre = "Nueva Delhi", Ciudad = "Nueva Delhi", LugarTuristico = "Templo de Loto", PaisID = 16 },
				new Destino { DestinoID = 17, Nombre = "Atenas", Ciudad = "Atenas", LugarTuristico = "Acrópolis", PaisID = 17 },
				new Destino { DestinoID = 18, Nombre = "Ciudad del Cabo", Ciudad = "Ciudad del Cabo", LugarTuristico = "Montaña de la Mesa", PaisID = 18 },
				new Destino { DestinoID = 19, Nombre = "Cartagena", Ciudad = "Cartagena", LugarTuristico = "Ciudad Amurallada", PaisID = 19 },
				new Destino { DestinoID = 20, Nombre = "Cuzco", Ciudad = "Cuzco", LugarTuristico = "Machu Picchu", PaisID = 20 }
			);

			// Seed Tours con referencias correctas
			modelBuilder.Entity<Tour>().HasData(
				new Tour { ID = 1, Nombre = "Tour a Punta Cana", Precio = 250.00M, FechaInicio = new DateTime(2025, 8, 10), HoraInicio = new TimeSpan(9, 0, 0), PaisID = 1, DestinoID = 1 },
				new Tour { ID = 2, Nombre = "Tour a Cancún", Precio = 300.00M, FechaInicio = new DateTime(2025, 8, 11), HoraInicio = new TimeSpan(8, 30, 0), PaisID = 2, DestinoID = 2 },
				new Tour { ID = 3, Nombre = "Tour a Orlando", Precio = 400.00M, FechaInicio = new DateTime(2025, 8, 12), HoraInicio = new TimeSpan(10, 0, 0), PaisID = 3, DestinoID = 3 },
				new Tour { ID = 4, Nombre = "Tour a Barcelona", Precio = 350.00M, FechaInicio = new DateTime(2025, 8, 13), HoraInicio = new TimeSpan(9, 15, 0), PaisID = 4, DestinoID = 4 },
				new Tour { ID = 5, Nombre = "Tour a París", Precio = 500.00M, FechaInicio = new DateTime(2025, 8, 14), HoraInicio = new TimeSpan(9, 45, 0), PaisID = 5, DestinoID = 5 },
				new Tour { ID = 6, Nombre = "Tour a Roma", Precio = 480.00M, FechaInicio = new DateTime(2025, 8, 15), HoraInicio = new TimeSpan(8, 0, 0), PaisID = 6, DestinoID = 6 },
				new Tour { ID = 7, Nombre = "Tour a Tokio", Precio = 650.00M, FechaInicio = new DateTime(2025, 8, 16), HoraInicio = new TimeSpan(10, 30, 0), PaisID = 7, DestinoID = 7 },
				new Tour { ID = 8, Nombre = "Tour a Río de Janeiro", Precio = 400.00M, FechaInicio = new DateTime(2025, 8, 17), HoraInicio = new TimeSpan(9, 0, 0), PaisID = 8, DestinoID = 8 },
				new Tour { ID = 9, Nombre = "Tour a Bangkok", Precio = 550.00M, FechaInicio = new DateTime(2025, 8, 18), HoraInicio = new TimeSpan(7, 45, 0), PaisID = 9, DestinoID = 9 },
				new Tour { ID = 10, Nombre = "Tour a El Cairo", Precio = 300.00M, FechaInicio = new DateTime(2025, 8, 19), HoraInicio = new TimeSpan(8, 30, 0), PaisID = 10, DestinoID = 10 },
				new Tour { ID = 11, Nombre = "Tour a Buenos Aires", Precio = 270.00M, FechaInicio = new DateTime(2025, 8, 20), HoraInicio = new TimeSpan(9, 15, 0), PaisID = 11, DestinoID = 11 },
				new Tour { ID = 12, Nombre = "Tour a Toronto", Precio = 320.00M, FechaInicio = new DateTime(2025, 8, 21), HoraInicio = new TimeSpan(10, 0, 0), PaisID = 12, DestinoID = 12 },
				new Tour { ID = 13, Nombre = "Tour a Berlín", Precio = 400.00M, FechaInicio = new DateTime(2025, 8, 22), HoraInicio = new TimeSpan(9, 45, 0), PaisID = 13, DestinoID = 13 },
				new Tour { ID = 14, Nombre = "Tour a Sídney", Precio = 700.00M, FechaInicio = new DateTime(2025, 8, 23), HoraInicio = new TimeSpan(8, 0, 0), PaisID = 14, DestinoID = 14 },
				new Tour { ID = 15, Nombre = "Tour a Pekín", Precio = 500.00M, FechaInicio = new DateTime(2025, 8, 24), HoraInicio = new TimeSpan(10, 30, 0), PaisID = 15, DestinoID = 15 },
				new Tour { ID = 16, Nombre = "Tour a Nueva Delhi", Precio = 420.00M, FechaInicio = new DateTime(2025, 8, 25), HoraInicio = new TimeSpan(9, 0, 0), PaisID = 16, DestinoID = 16 },
				new Tour { ID = 17, Nombre = "Tour a Atenas", Precio = 460.00M, FechaInicio = new DateTime(2025, 8, 26), HoraInicio = new TimeSpan(7, 30, 0), PaisID = 17, DestinoID = 17 },
				new Tour { ID = 18, Nombre = "Tour a Ciudad del Cabo", Precio = 380.00M, FechaInicio = new DateTime(2025, 8, 27), HoraInicio = new TimeSpan(8, 30, 0), PaisID = 18, DestinoID = 18 },
				new Tour { ID = 19, Nombre = "Tour a Cartagena", Precio = 260.00M, FechaInicio = new DateTime(2025, 8, 28), HoraInicio = new TimeSpan(9, 0, 0), PaisID = 19, DestinoID = 19 },
				new Tour { ID = 20, Nombre = "Tour a Cuzco", Precio = 310.00M, FechaInicio = new DateTime(2025, 8, 29), HoraInicio = new TimeSpan(10, 0, 0), PaisID = 20, DestinoID = 20 }
			);

			// Configurar precisión del decimal para Precio en Tour
			modelBuilder.Entity<Tour>()
				.Property(t => t.Precio)
				.HasColumnType("decimal(10,2)");

			// Restricciones de eliminaciones para Tour
			modelBuilder.Entity<Tour>()
				.HasOne(t => t.Pais)
				.WithMany(p => p.Tours)
				.HasForeignKey(t => t.PaisID)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Tour>()
				.HasOne(t => t.Destino)
				.WithMany(d => d.Tours)
				.HasForeignKey(t => t.DestinoID)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
