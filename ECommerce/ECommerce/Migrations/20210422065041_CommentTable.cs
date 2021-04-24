using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class CommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentMaster",
                columns: table => new
                {
                    Coment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentMaster", x => x.Coment_Id);
                    table.ForeignKey(
                        name: "FK_CommentMaster_ProductMaster_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "ProductMaster",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentMaster_UserMaster_User_Id",
                        column: x => x.User_Id,
                        principalTable: "UserMaster",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentMaster_Product_Id",
                table: "CommentMaster",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CommentMaster_User_Id",
                table: "CommentMaster",
                column: "User_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentMaster");
        }
    }
}
