using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EstateAgency.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientName = table.Column<string>(maxLength: 50, nullable: false),
                    ContactPerson = table.Column<string>(maxLength: 50, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    EstateArea = table.Column<double>(nullable: false),
                    EstateType = table.Column<string>(nullable: false),
                    OtherRequirements = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 25, nullable: false),
                    RentPrice = table.Column<decimal>(nullable: true),
                    SalePrice = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adress = table.Column<string>(nullable: false),
                    ClientStatus = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: true),
                    UNP = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    Surname = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Treaty",
                columns: table => new
                {
                    Area = table.Column<double>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    TotalRentPrice = table.Column<decimal>(nullable: true),
                    TotalSalePrice = table.Column<decimal>(nullable: true),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    SignDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treaty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client_Treaty",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false),
                    TreatyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Treaty", x => new { x.ClientID, x.TreatyID });
                    table.ForeignKey(
                        name: "FK_Client_Treaty_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_Treaty_Treaty_TreatyID",
                        column: x => x.TreatyID,
                        principalTable: "Treaty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adress = table.Column<string>(nullable: false),
                    Area = table.Column<double>(nullable: false),
                    ClientID = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ImageThumbURL = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    InventoryNumber = table.Column<string>(nullable: false),
                    LongDescription = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SaleStatus = table.Column<bool>(nullable: false),
                    SaleTreatyID1 = table.Column<int>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Wall = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    PerSquareMeterRentPrice = table.Column<decimal>(nullable: true),
                    SalePrice = table.Column<decimal>(nullable: true),
                    SaleTreatyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Estate_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estate_Treaty_SaleTreatyID1",
                        column: x => x.SaleTreatyID1,
                        principalTable: "Treaty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estate_Treaty_SaleTreatyID",
                        column: x => x.SaleTreatyID,
                        principalTable: "Treaty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentEstate_Lease",
                columns: table => new
                {
                    EstateID = table.Column<int>(nullable: false),
                    LeaseID = table.Column<int>(nullable: false),
                    RentEstateID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentEstate_Lease", x => new { x.EstateID, x.LeaseID });
                    table.ForeignKey(
                        name: "FK_RentEstate_Lease_Estate_EstateID",
                        column: x => x.EstateID,
                        principalTable: "Estate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentEstate_Lease_Treaty_LeaseID",
                        column: x => x.LeaseID,
                        principalTable: "Treaty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentEstate_Lease_Estate_RentEstateID",
                        column: x => x.RentEstateID,
                        principalTable: "Estate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_Treaty_TreatyID",
                table: "Client_Treaty",
                column: "TreatyID");

            migrationBuilder.CreateIndex(
                name: "IX_Estate_ClientID",
                table: "Estate",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Estate_SaleTreatyID1",
                table: "Estate",
                column: "SaleTreatyID1");

            migrationBuilder.CreateIndex(
                name: "IX_Estate_SaleTreatyID",
                table: "Estate",
                column: "SaleTreatyID");

            migrationBuilder.CreateIndex(
                name: "IX_RentEstate_Lease_LeaseID",
                table: "RentEstate_Lease",
                column: "LeaseID");

            migrationBuilder.CreateIndex(
                name: "IX_RentEstate_Lease_RentEstateID",
                table: "RentEstate_Lease",
                column: "RentEstateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "Client_Treaty");

            migrationBuilder.DropTable(
                name: "RentEstate_Lease");

            migrationBuilder.DropTable(
                name: "Estate");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Treaty");
        }
    }
}
