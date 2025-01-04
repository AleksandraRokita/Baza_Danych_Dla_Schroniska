using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektC.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migracja2Zwierze : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lokacja",
                columns: table => new
                {
                    id_lokacji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lokacja = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacja", x => x.id_lokacji);
                });

            migrationBuilder.CreateTable(
                name: "Pracownik",
                columns: table => new
                {
                    id_pracownika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownik", x => x.id_pracownika);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownik",
                columns: table => new
                {
                    id_uzytkownika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imie = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    nazwisko = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownik", x => x.id_uzytkownika);
                });

            migrationBuilder.CreateTable(
                name: "Zwierze",
                columns: table => new
                {
                    id_zwierzecia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gatunek = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    imie = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    rasa = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    wiek = table.Column<int>(type: "int", nullable: true),
                    waga = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    id_lokacji = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zwierze", x => x.id_zwierzecia);
                    table.ForeignKey(
                        name: "FK_Zwierze_Lokacja_id_lokacji",
                        column: x => x.id_lokacji,
                        principalTable: "Lokacja",
                        principalColumn: "id_lokacji");
                });

            migrationBuilder.CreateTable(
                name: "Adopcja",
                columns: table => new
                {
                    id_adopcji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_zwierzecia = table.Column<int>(type: "int", nullable: false),
                    id_uzytkownika = table.Column<int>(type: "int", nullable: false),
                    id_pracownika = table.Column<int>(type: "int", nullable: false),
                    status_adopcji = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    data_rozpoczecia_adopcji = table.Column<DateOnly>(type: "date", nullable: false),
                    data_zakonczenia_adopcji = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adopcja", x => x.id_adopcji);
                    table.ForeignKey(
                        name: "FK_Adopcja_Pracownik_id_pracownika",
                        column: x => x.id_pracownika,
                        principalTable: "Pracownik",
                        principalColumn: "id_pracownika",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adopcja_Uzytkownik_id_uzytkownika",
                        column: x => x.id_uzytkownika,
                        principalTable: "Uzytkownik",
                        principalColumn: "id_uzytkownika",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adopcja_Zwierze_id_zwierzecia",
                        column: x => x.id_zwierzecia,
                        principalTable: "Zwierze",
                        principalColumn: "id_zwierzecia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adopcja_id_pracownika",
                table: "Adopcja",
                column: "id_pracownika");

            migrationBuilder.CreateIndex(
                name: "IX_Adopcja_id_uzytkownika",
                table: "Adopcja",
                column: "id_uzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_Adopcja_id_zwierzecia",
                table: "Adopcja",
                column: "id_zwierzecia");

            migrationBuilder.CreateIndex(
                name: "IX_Zwierze_id_lokacji",
                table: "Zwierze",
                column: "id_lokacji");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adopcja");

            migrationBuilder.DropTable(
                name: "Pracownik");

            migrationBuilder.DropTable(
                name: "Uzytkownik");

            migrationBuilder.DropTable(
                name: "Zwierze");

            migrationBuilder.DropTable(
                name: "Lokacja");
        }
    }
}
