using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class CartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartMaster",
                columns: table => new
                {
                    cart_item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                   product_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    cart_item_quantity = table.Column<int>(type: "int", nullable: false),
                   //Product_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartMaster", x => x.cart_item_id);
                    table.ForeignKey(
                        name: "FK_CartMaster_ProductMaster_Product_Id",
                        column: x => x.product_id,
                        principalTable: "ProductMaster",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartMaster_UserMaster_user_id",
                        column: x => x.user_id,
                        principalTable: "UserMaster",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartMaster_Product_Id",
                table: "CartMaster",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CartMaster_user_id",
                table: "CartMaster",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartMaster");
        }
    }
}
