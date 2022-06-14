using Microsoft.EntityFrameworkCore.Migrations;

namespace CardFile.DAL.Migrations
{
    public partial class CardFileDBchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Materials_Id",
                table: "Reactions");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reactions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TextId",
                table: "Reactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_TextId",
                table: "Reactions",
                column: "TextId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Materials_TextId",
                table: "Reactions",
                column: "TextId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Materials_TextId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_TextId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "TextId",
                table: "Reactions");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Materials_Id",
                table: "Reactions",
                column: "Id",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
