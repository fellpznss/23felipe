using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class Autor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Autorid",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Autorid",
                table: "Posts",
                column: "Autorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Usuarios_Autorid",
                table: "Posts",
                column: "Autorid",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Usuarios_Autorid",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_Autorid",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Autorid",
                table: "Posts");
        }
    }
}
