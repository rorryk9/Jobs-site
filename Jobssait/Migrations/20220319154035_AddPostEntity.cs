using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Jobssait.Migrations
{
    public partial class AddPostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          /*  migrationBuilder.DropColumn(
                name: "UserName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "AspNetUsers",
                newName: "UserName");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Userusername",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
          */

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    UseerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UseerId",
                        column: x => x.UseerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UseerId",
                table: "Posts",
                column: "UseerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

         /*
            migrationBuilder.DropColumn(
                name: "Userusername",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AspNetUsers",
                newName: "username");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true);
         */
        }
    }
}
