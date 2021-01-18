using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Data_Assignment.Migrations
{
    public partial class setupManyToManyModelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeopleList_Languages_LanguageId",
                table: "PeopleList");

            migrationBuilder.DropIndex(
                name: "IX_PeopleList_LanguageId",
                table: "PeopleList");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "PeopleList");

            migrationBuilder.CreateTable(
                name: "PersonLanguage",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLanguage", x => new { x.PersonId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_PersonLanguage_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLanguage_PeopleList_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PeopleList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguage_LanguageId",
                table: "PersonLanguage",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLanguage");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "PeopleList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PeopleList_LanguageId",
                table: "PeopleList",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleList_Languages_LanguageId",
                table: "PeopleList",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
