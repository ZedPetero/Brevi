using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class anotherDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Teachers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Teachers");
        }
    }
}
