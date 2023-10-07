using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial2_PersonaNature.Migrations
{
    /// <inheritdoc />
    public partial class MyDataBaseFirthcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NaturalPerson",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthYear = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPerson", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPerson_FullName",
                table: "NaturalPerson",
                column: "FullName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NaturalPerson");
        }
    }
}
