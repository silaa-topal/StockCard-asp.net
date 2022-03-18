using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StokKartiProjesi.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stoklar",
                columns: table => new
                {
                    StokID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StokNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StokAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StokBarkod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StokAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KDV = table.Column<float>(type: "real", nullable: false),
                    Fiyat1 = table.Column<float>(type: "real", nullable: false),
                    Fiyat2 = table.Column<float>(type: "real", nullable: false),
                    Fiyat3 = table.Column<float>(type: "real", nullable: false),
                    Fiyat4 = table.Column<float>(type: "real", nullable: false),
                    Fiyat5 = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoklar", x => x.StokID);
                });

            migrationBuilder.CreateTable(
                name: "Satislar",
                columns: table => new
                {
                    SatisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StokID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IslemTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    BirimFiyatı = table.Column<int>(type: "int", nullable: false),
                    ToplamFiyat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satislar", x => x.SatisID);
                    table.ForeignKey(
                        name: "FK_Satislar_Stoklar_StokID",
                        column: x => x.StokID,
                        principalTable: "Stoklar",
                        principalColumn: "StokID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Satislar_StokID",
                table: "Satislar",
                column: "StokID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Satislar");

            migrationBuilder.DropTable(
                name: "Stoklar");
        }
    }
}
