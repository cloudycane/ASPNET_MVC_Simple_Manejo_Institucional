using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstitucionMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    Asignatura_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Asignatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modulos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.Asignatura_Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Curso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matricula_Id = table.Column<int>(type: "int", nullable: false),
                    Asignatura_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    EstudianteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Fecha_Nacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo_Electronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ultimo_Estudio_Realizado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.EstudianteId);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    MatriculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Matricula = table.Column<DateOnly>(type: "date", nullable: false),
                    Estudiante_Id = table.Column<int>(type: "int", nullable: false),
                    Asignatura_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.MatriculaId);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    ProfesorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo_Electronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Num_Telefono = table.Column<int>(type: "int", nullable: false),
                    Tarjeta_Credito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Asignatura_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.ProfesorId);
                });

            migrationBuilder.InsertData(
                table: "Asignaturas",
                columns: new[] { "Asignatura_Id", "Descripcion", "Modulos", "Nombre_Asignatura" },
                values: new object[] { 1, "Lorem ipsum", "Lorem ipsum", "Lengua Castellana Y Literatura" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Asignatura_Id", "Matricula_Id", "Nombre_Curso" },
                values: new object[] { 1, 1, 1, "1 ESO" });

            migrationBuilder.InsertData(
                table: "Estudiantes",
                columns: new[] { "EstudianteId", "Apellidos", "Correo_Electronico", "Direccion", "Edad", "Fecha_Nacimiento", "Nombre", "Ultimo_Estudio_Realizado" },
                values: new object[] { 1, "Dela Cruz", "Juan23@hotmail.com", "Avenida Berry, Oviedo, City", 16, new DateOnly(2008, 12, 12), "Juan", "3 Eso" });

            migrationBuilder.InsertData(
                table: "Matriculas",
                columns: new[] { "MatriculaId", "Asignatura_Id", "Estudiante_Id", "Fecha_Matricula" },
                values: new object[] { 1, 1, 1, new DateOnly(2024, 8, 12) });

            migrationBuilder.InsertData(
                table: "Profesores",
                columns: new[] { "ProfesorId", "Apellidos", "Asignatura_Id", "Correo_Electronico", "Direccion", "Nombre", "Num_Telefono", "Tarjeta_Credito" },
                values: new object[] { 1, "Dela Rosa", 1, "juana23@gmail.com", "Calle Rosal Oviedo City", "Juana", 603147973, "4548812049400004" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignaturas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Profesores");
        }
    }
}
