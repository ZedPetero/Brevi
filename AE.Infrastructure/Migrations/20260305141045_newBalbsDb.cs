using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newBalbsDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Birthday",
                table: "Teachers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Subject",
                table: "Teachers",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Teachers");
        }
    }
}
