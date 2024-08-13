using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstitucionMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class PVMSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "profesoresViewModels",
                columns: table => new
                {
                    ProfesorViewModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    Asignatura_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profesoresViewModels", x => x.ProfesorViewModelId);
                });

            migrationBuilder.InsertData(
                table: "profesoresViewModels",
                columns: new[] { "ProfesorViewModelId", "Asignatura_Id", "ProfesorId" },
                values: new object[] { 1, 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "profesoresViewModels");
        }
    }
}
