using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaterialManagement.web.Migrations
{
    public partial class VendorTypRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PanNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TinNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    EccNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    RegistrationType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SalesTaxNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CSTNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ServiceTaxNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    BlackListStatus = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MulRegistrationType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    VAT_No = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    GST_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aadhaar_No = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendors_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendors_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_CreatedById",
                table: "Vendors",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_ModifiedById",
                table: "Vendors",
                column: "ModifiedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
