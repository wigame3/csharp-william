using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Empleados.Data.Migrations
{
    public partial class addtablesempeladosyareas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubAreas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubAreas_Areas_Id",
                        column: x => x.Id,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellidos = table.Column<string>(maxLength: 100, nullable: false),
                    Documento = table.Column<string>(maxLength: 20, nullable: false),
                    Id_Sub_Area = table.Column<int>(nullable: false),
                    Nombres = table.Column<string>(maxLength: 100, nullable: false),
                    Tipo_documento = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleado_SubAreas_Id_Sub_Area",
                        column: x => x.Id_Sub_Area,
                        principalTable: "SubAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Id_Sub_Area",
                table: "Empleado",
                column: "Id_Sub_Area");

            migrationBuilder.CreateIndex(
                name: "IX_SubAreas_Id",
                table: "SubAreas",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "SubAreas");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
