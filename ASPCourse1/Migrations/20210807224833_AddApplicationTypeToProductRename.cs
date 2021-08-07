using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPCourse1.Migrations
{
    public partial class AddApplicationTypeToProductRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.RenameColumn(
                name: "ApplicationId",
                table: "Product",
                newName: "ApplicationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ApplicationId",
                table: "Product",
                newName: "IX_Product_ApplicationTypeId");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.RenameColumn(
                name: "ApplicationTypeId",
                table: "Product",
                newName: "ApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ApplicationTypeId",
                table: "Product",
                newName: "IX_Product_ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ApplicationType_ApplicationId",
                table: "Product",
                column: "ApplicationId",
                principalTable: "ApplicationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
