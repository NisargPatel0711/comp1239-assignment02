using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GBCSporting_CoderHuskies.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Technician",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technician", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    CountryId = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    IncidentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    TechnicianId = table.Column<int>(nullable: true),
                    DateOpened = table.Column<DateTime>(nullable: true),
                    DateClosed = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.IncidentId);
                    table.ForeignKey(
                        name: "FK_Incident_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incident_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incident_Technician_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technician",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { "AUS", "Australia" },
                    { "GBR", "United Kingdom of Great Britain and Northern Ireland" },
                    { "ARE", "United Arab Emirates" },
                    { "IND", "India" },
                    { "FRA", "France" },
                    { "USA", "United States of America" },
                    { "CHN", "China" },
                    { "CAN", "Canada" },
                    { "BRA", "Brazil" },
                    { "EGY", "Egypt" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Code", "Date", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "TRNY10", new DateTime(2015, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trournament Master 1.0", 4.9900000000000002 },
                    { 2, "LEAG10", new DateTime(2016, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "League Scheduler 1.0", 4.9900000000000002 },
                    { 3, "DRAFT10", new DateTime(2017, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Draft Manager 1.0", 5.9900000000000002 },
                    { 4, "TEAM10", new DateTime(2015, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Team Manager 1.0", 7.9900000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Technician",
                columns: new[] { "TechnicianId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 4, "alison@sportspro.com", "Alison Diaz", "902-456-7890" },
                    { 1, "jasonc@sportspro.com", "Jason Chang", "416-987-6543" },
                    { 2, "csenior@sportspro.com", "Chris Senior", "647-123-4567" },
                    { 3, "johnmc@sportspro.com", "John McDonald", "902-456-7890" },
                    { 5, "gfiori@sportspro.com", "Gina Fiori", "902-456-7890" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address", "City", "CountryId", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1, "5 Concord Place", "North York", "CAN", "ksmith98@gmail.com", "Kevin", "Smith", null, "M16 8J9", "Ontario" },
                    { 3, "145 Queens street", "Toronto", "CAN", "jacob1758@gmail.com", "Jacob", "Rogers", "416-321-4567", "M25 8F7", "Ontario" },
                    { 5, "2616 Mason Heights", "Mississauga", "CAN", "stuartj007@gmail.com", "John", "Stuart", null, "L5B 2S2", "Ontario" },
                    { 2, "A-501 Nirman Tower", "Ahmedabad", "IND", null, "Jerry", "Patel", "9727243403", "380005", "Gujarat" },
                    { 4, "698 Flash Avenue", "New York", "USA", null, "Bruce", "Wayne", null, "NY 10024", "New York" }
                });

            migrationBuilder.InsertData(
                table: "Incident",
                columns: new[] { "IncidentId", "CustomerId", "DateClosed", "DateOpened", "Description", "ProductId", "TechnicianId", "Title" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2021, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gives Error while importing data from CSV file.", 1, 3, "Error importing data" },
                    { 4, 3, new DateTime(2020, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Installer launches and immidiately", 3, 2, "Could Not Install" },
                    { 1, 2, new DateTime(2021, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giving error while accepting terms and condition", 2, 5, "Could Not Install" },
                    { 3, 4, new DateTime(2021, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gives error on launching saying - 'Cannot Connect To Database'", 4, 1, "Error launching program" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CountryId",
                table: "Customer",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_CustomerId",
                table: "Incident",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_ProductId",
                table: "Incident",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_TechnicianId",
                table: "Incident",
                column: "TechnicianId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Technician");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
