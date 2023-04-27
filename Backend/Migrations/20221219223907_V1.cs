using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Primer.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nepoznate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nepoznate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Osobine",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vrednost = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osobine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Podrucja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podrucja", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ptice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ptice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NepoznataPticaOsobina",
                columns: table => new
                {
                    NepoznataID = table.Column<int>(type: "int", nullable: false),
                    OsobineID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NepoznataPticaOsobina", x => new { x.NepoznataID, x.OsobineID });
                    table.ForeignKey(
                        name: "FK_NepoznataPticaOsobina_Nepoznate_NepoznataID",
                        column: x => x.NepoznataID,
                        principalTable: "Nepoznate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NepoznataPticaOsobina_Osobine_OsobineID",
                        column: x => x.OsobineID,
                        principalTable: "Osobine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OsobinaPtica",
                columns: table => new
                {
                    OsobineID = table.Column<int>(type: "int", nullable: false),
                    PticaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsobinaPtica", x => new { x.OsobineID, x.PticaID });
                    table.ForeignKey(
                        name: "FK_OsobinaPtica_Osobine_OsobineID",
                        column: x => x.OsobineID,
                        principalTable: "Osobine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OsobinaPtica_Ptice_PticaID",
                        column: x => x.PticaID,
                        principalTable: "Ptice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vidjenja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Vreme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PticaID = table.Column<int>(type: "int", nullable: true),
                    PodrucjeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vidjenja", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vidjenja_Podrucja_PodrucjeID",
                        column: x => x.PodrucjeID,
                        principalTable: "Podrucja",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Vidjenja_Ptice_PticaID",
                        column: x => x.PticaID,
                        principalTable: "Ptice",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NepoznataPticaOsobina_OsobineID",
                table: "NepoznataPticaOsobina",
                column: "OsobineID");

            migrationBuilder.CreateIndex(
                name: "IX_OsobinaPtica_PticaID",
                table: "OsobinaPtica",
                column: "PticaID");

            migrationBuilder.CreateIndex(
                name: "IX_Vidjenja_PodrucjeID",
                table: "Vidjenja",
                column: "PodrucjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Vidjenja_PticaID",
                table: "Vidjenja",
                column: "PticaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NepoznataPticaOsobina");

            migrationBuilder.DropTable(
                name: "OsobinaPtica");

            migrationBuilder.DropTable(
                name: "Vidjenja");

            migrationBuilder.DropTable(
                name: "Nepoznate");

            migrationBuilder.DropTable(
                name: "Osobine");

            migrationBuilder.DropTable(
                name: "Podrucja");

            migrationBuilder.DropTable(
                name: "Ptice");
        }
    }
}
