using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VisitorDetails.Migrations
{
    public partial class InitialVersion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    SiteCode = table.Column<string>(maxLength: 20, nullable: false),
                    SiteName = table.Column<string>(maxLength: 100, nullable: true),
                    SiteEncryptedCode = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.SiteCode);
                });

            migrationBuilder.CreateTable(
                name: "SystemSetting",
                columns: table => new
                {
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "VIS_PurposeOfVisit",
                columns: table => new
                {
                    PurposeOfVisitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIS_PurposeOfVisit", x => x.PurposeOfVisitID);
                });

            migrationBuilder.CreateTable(
                name: "VIS_Visitor",
                columns: table => new
                {
                    VisitorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteCode = table.Column<string>(maxLength: 20, nullable: false),
                    Surname = table.Column<string>(maxLength: 15, nullable: false),
                    Forename = table.Column<string>(maxLength: 15, nullable: false),
                    MobileTel = table.Column<string>(maxLength: 15, nullable: false),
                    MobileOptOut = table.Column<bool>(nullable: false),
                    NumberOfGuests = table.Column<int>(nullable: false),
                    PurposeOfVisitID = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LeaveDate = table.Column<DateTime>(nullable: true),
                    IPAddress = table.Column<string>(maxLength: 45, nullable: true),
                    UserAgent = table.Column<string>(nullable: true),
                    SiteCode1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIS_Visitor", x => x.VisitorID);
                    table.ForeignKey(
                        name: "FK_VIS_Visitor_VIS_PurposeOfVisit_PurposeOfVisitID",
                        column: x => x.PurposeOfVisitID,
                        principalTable: "VIS_PurposeOfVisit",
                        principalColumn: "PurposeOfVisitID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VIS_Visitor_Site_SiteCode1",
                        column: x => x.SiteCode1,
                        principalTable: "Site",
                        principalColumn: "SiteCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VIS_Visitor_PurposeOfVisitID",
                table: "VIS_Visitor",
                column: "PurposeOfVisitID");

            migrationBuilder.CreateIndex(
                name: "IX_VIS_Visitor_SiteCode1",
                table: "VIS_Visitor",
                column: "SiteCode1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemSetting");

            migrationBuilder.DropTable(
                name: "VIS_Visitor");

            migrationBuilder.DropTable(
                name: "VIS_PurposeOfVisit");

            migrationBuilder.DropTable(
                name: "Site");
        }
    }
}
