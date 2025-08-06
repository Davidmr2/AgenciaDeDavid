using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgenciadeDavid.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    PaisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.PaisID);
                });

            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    DestinoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LugarTuristico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisID = table.Column<int>(type: "int", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.DestinoID);
                    table.ForeignKey(
                        name: "FK_Destinos_Paises_PaisID",
                        column: x => x.PaisID,
                        principalTable: "Paises",
                        principalColumn: "PaisID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    PaisID = table.Column<int>(type: "int", nullable: false),
                    DestinoID = table.Column<int>(type: "int", nullable: false),
                    TourID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tours_Destinos_DestinoID",
                        column: x => x.DestinoID,
                        principalTable: "Destinos",
                        principalColumn: "DestinoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tours_Paises_PaisID",
                        column: x => x.PaisID,
                        principalTable: "Paises",
                        principalColumn: "PaisID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "PaisID", "Ciudad", "Nombre" },
                values: new object[,]
                {
                    { 1, "Santo Domingo", "República Dominicana" },
                    { 2, "Ciudad de México", "México" },
                    { 3, "Washington D.C.", "Estados Unidos" },
                    { 4, "Madrid", "España" },
                    { 5, "París", "Francia" },
                    { 6, "Roma", "Italia" },
                    { 7, "Tokio", "Japón" },
                    { 8, "Brasilia", "Brasil" },
                    { 9, "Bangkok", "Tailandia" },
                    { 10, "El Cairo", "Egipto" },
                    { 11, "Buenos Aires", "Argentina" },
                    { 12, "Ottawa", "Canadá" },
                    { 13, "Berlín", "Alemania" },
                    { 14, "Canberra", "Australia" },
                    { 15, "Pekín", "China" },
                    { 16, "Nueva Delhi", "India" },
                    { 17, "Atenas", "Grecia" },
                    { 18, "Pretoria", "Sudáfrica" },
                    { 19, "Bogotá", "Colombia" },
                    { 20, "Lima", "Perú" }
                });

            migrationBuilder.InsertData(
                table: "Destinos",
                columns: new[] { "DestinoID", "Ciudad", "Duracion", "LugarTuristico", "Nombre", "PaisID" },
                values: new object[,]
                {
                    { 1, "Punta Cana", new TimeSpan(0, 0, 0, 0, 0), "Playa Bávaro", "Punta Cana", 1 },
                    { 2, "Cancún", new TimeSpan(0, 0, 0, 0, 0), "Zona Hotelera", "Cancún", 2 },
                    { 3, "Orlando", new TimeSpan(0, 0, 0, 0, 0), "Disney World", "Orlando", 3 },
                    { 4, "Barcelona", new TimeSpan(0, 0, 0, 0, 0), "Sagrada Familia", "Barcelona", 4 },
                    { 5, "París", new TimeSpan(0, 0, 0, 0, 0), "Torre Eiffel", "París", 5 },
                    { 6, "Roma", new TimeSpan(0, 0, 0, 0, 0), "Coliseo Romano", "Roma", 6 },
                    { 7, "Tokio", new TimeSpan(0, 0, 0, 0, 0), "Shibuya", "Tokio", 7 },
                    { 8, "Río de Janeiro", new TimeSpan(0, 0, 0, 0, 0), "Cristo Redentor", "Río de Janeiro", 8 },
                    { 9, "Bangkok", new TimeSpan(0, 0, 0, 0, 0), "Templo Wat Arun", "Bangkok", 9 },
                    { 10, "El Cairo", new TimeSpan(0, 0, 0, 0, 0), "Pirámides de Giza", "El Cairo", 10 },
                    { 11, "Buenos Aires", new TimeSpan(0, 0, 0, 0, 0), "Barrio La Boca", "Buenos Aires", 11 },
                    { 12, "Toronto", new TimeSpan(0, 0, 0, 0, 0), "Torre CN", "Toronto", 12 },
                    { 13, "Berlín", new TimeSpan(0, 0, 0, 0, 0), "Muro de Berlín", "Berlín", 13 },
                    { 14, "Sídney", new TimeSpan(0, 0, 0, 0, 0), "Ópera de Sídney", "Sídney", 14 },
                    { 15, "Pekín", new TimeSpan(0, 0, 0, 0, 0), "Ciudad Prohibida", "Pekín", 15 },
                    { 16, "Nueva Delhi", new TimeSpan(0, 0, 0, 0, 0), "Templo de Loto", "Nueva Delhi", 16 },
                    { 17, "Atenas", new TimeSpan(0, 0, 0, 0, 0), "Acrópolis", "Atenas", 17 },
                    { 18, "Ciudad del Cabo", new TimeSpan(0, 0, 0, 0, 0), "Montaña de la Mesa", "Ciudad del Cabo", 18 },
                    { 19, "Cartagena", new TimeSpan(0, 0, 0, 0, 0), "Ciudad Amurallada", "Cartagena", 19 },
                    { 20, "Cuzco", new TimeSpan(0, 0, 0, 0, 0), "Machu Picchu", "Cuzco", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "ID", "DestinoID", "FechaInicio", "HoraInicio", "Nombre", "PaisID", "Precio", "TourID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 9, 0, 0, 0), "Tour a Punta Cana", 1, 250.00m, 0 },
                    { 2, 2, new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 30, 0, 0), "Tour a Cancún", 2, 300.00m, 0 },
                    { 3, 3, new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), "Tour a Orlando", 3, 400.00m, 0 },
                    { 4, 4, new DateTime(2025, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 9, 15, 0, 0), "Tour a Barcelona", 4, 350.00m, 0 },
                    { 5, 5, new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 9, 45, 0, 0), "Tour a París", 5, 500.00m, 0 },
                    { 6, 6, new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0), "Tour a Roma", 6, 480.00m, 0 },
                    { 7, 7, new DateTime(2025, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 30, 0, 0), "Tour a Tokio", 7, 650.00m, 0 },
                    { 8, 8, new DateTime(2025, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 9, 0, 0, 0), "Tour a Río de Janeiro", 8, 400.00m, 0 },
                    { 9, 9, new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 45, 0, 0), "Tour a Bangkok", 9, 550.00m, 0 },
                    { 10, 10, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 30, 0, 0), "Tour a El Cairo", 10, 300.00m, 0 },
                    { 11, 11, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 9, 15, 0, 0), "Tour a Buenos Aires", 11, 270.00m, 0 },
                    { 12, 12, new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), "Tour a Toronto", 12, 320.00m, 0 },
                    { 13, 13, new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 9, 45, 0, 0), "Tour a Berlín", 13, 400.00m, 0 },
                    { 14, 14, new DateTime(2025, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0), "Tour a Sídney", 14, 700.00m, 0 },
                    { 15, 15, new DateTime(2025, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 30, 0, 0), "Tour a Pekín", 15, 500.00m, 0 },
                    { 16, 16, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 9, 0, 0, 0), "Tour a Nueva Delhi", 16, 420.00m, 0 },
                    { 17, 17, new DateTime(2025, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 30, 0, 0), "Tour a Atenas", 17, 460.00m, 0 },
                    { 18, 18, new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 30, 0, 0), "Tour a Ciudad del Cabo", 18, 380.00m, 0 },
                    { 19, 19, new DateTime(2025, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 9, 0, 0, 0), "Tour a Cartagena", 19, 260.00m, 0 },
                    { 20, 20, new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), "Tour a Cuzco", 20, 310.00m, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destinos_PaisID",
                table: "Destinos",
                column: "PaisID");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_DestinoID",
                table: "Tours",
                column: "DestinoID");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_PaisID",
                table: "Tours",
                column: "PaisID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Destinos");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
