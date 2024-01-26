using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectWebData.Migrations
{
    /// <inheritdoc />
    public partial class AddRegistrationNumberColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "Clientes",
                type: "VARCHAR(14)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Clientes");
        }
    }
}
