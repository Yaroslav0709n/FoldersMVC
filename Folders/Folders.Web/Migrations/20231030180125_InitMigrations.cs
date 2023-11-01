using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Folders.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCatalogId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Catalogs",
                columns: new[] { "Id", "Name", "ParentCatalogId" },
                values: new object[,]
                {
                    { new Guid("0194445f-828f-44e0-b042-084322ba396d"), "Grafic Products", new Guid("f79deddb-43e2-47ec-9457-9327cde636e4") },
                    { new Guid("0cda4ae2-536a-429a-a8de-86099059dbb5"), "Resources", new Guid("f79deddb-43e2-47ec-9457-9327cde636e4") },
                    { new Guid("319b2571-12f2-44b5-a958-4966ccfa1c87"), "Process", new Guid("0194445f-828f-44e0-b042-084322ba396d") },
                    { new Guid("7018b137-bf6b-424d-a8a9-a010618616e3"), "Secondary Source", new Guid("0cda4ae2-536a-429a-a8de-86099059dbb5") },
                    { new Guid("9228ddfd-5399-4175-8374-eb34073a20b3"), "Evidence", new Guid("f79deddb-43e2-47ec-9457-9327cde636e4") },
                    { new Guid("d27cf983-9ef0-479d-b670-d76267215b9c"), "Primary Source", new Guid("0cda4ae2-536a-429a-a8de-86099059dbb5") },
                    { new Guid("f79deddb-43e2-47ec-9457-9327cde636e4"), "Creating Digital Images", null },
                    { new Guid("f9003b53-9ff6-441b-8f4a-9302b062911c"), "Final Product", new Guid("0194445f-828f-44e0-b042-084322ba396d") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalogs");
        }
    }
}
