using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Jobssait.Migrations
{
    public partial class AddApplyenceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Applyence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    UseerId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applyence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applyence_AspNetUsers_UseerId",
                        column: x => x.UseerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                       name: "FK_Applyence_Posts_PostId",
                       column: x => x.PostId,
                       principalTable: "Posts",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
                name: "IX_Applyence_UseerId",
                table: "Applyence",
                column: "UseerId");
            migrationBuilder.CreateIndex(
              name: "IX_Applyence_PostId",
              table: "Applyence",
              column: "PostId");
            /*
                migrationBuilder.AddColumn<int>(
                    name: "PostId",
                    table: "Applyence",
                    type: "int",
                    nullable: true,
                    defaultValue: 0);

                migrationBuilder.AddForeignKey(
                    name: "FK_Applyence_Posts_PostId",
                    table: "Applyence",
                    column: "PostId",
                    principalTable: "Posts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);

                migrationBuilder.CreateIndex(
                   name: "IX_Applyence_PostId",
                   table: "Applyence",
                   column: "PostId");

            */
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Applyence");
            /*
            migrationBuilder.DropForeignKey(
                name: "FK_Applyence_Posts_PostId",
                table: "Applyence");

            migrationBuilder.DropIndex(
                name: "IX_Applyence_PostId",
                table: "Applyence");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Applyence");
            */
            
        }
    }
}
