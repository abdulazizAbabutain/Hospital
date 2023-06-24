using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameArabic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEnglish = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameArabic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEnglish = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionArabic = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    DescriptionEnglish = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModifyDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeleteDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeactivatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastDeactivateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastActivateeDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_EntityStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "EntityStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameArabic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEnglish = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionArabic = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    DescriptionEnglish = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModifyDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeleteDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeactivatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastDeactivateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastActivateeDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePosition_EntityStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "EntityStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EntityStatus",
                columns: new[] { "Id", "NameArabic", "NameEnglish" },
                values: new object[,]
                {
                    { 1, "فعال", "Active" },
                    { 2, "معطل", "Deactivate" },
                    { 3, "محذوف", "Deleted" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_StatusId",
                table: "Department",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePosition_StatusId",
                table: "EmployeePosition",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "EmployeePosition");

            migrationBuilder.DropTable(
                name: "EntityStatus");
        }
    }
}
