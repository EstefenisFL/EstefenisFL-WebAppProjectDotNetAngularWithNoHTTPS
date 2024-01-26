using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectWebData.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDependencyInOrderDTOToItemDTOCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderDTOId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Option",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_OrderDTOId",
                table: "Produtos",
                column: "OrderDTOId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pedidos_OrderDTOId",
                table: "Produtos",
                column: "OrderDTOId",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pedidos_OrderDTOId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_OrderDTOId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "OrderDTOId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Option",
                table: "Clientes");
        }
    }
}
