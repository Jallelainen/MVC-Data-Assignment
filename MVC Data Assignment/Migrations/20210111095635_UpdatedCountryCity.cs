using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Data_Assignment.Migrations
{
    public partial class UpdatedCountryCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "PeopleList");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "PeopleList",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CountryList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CityList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CountryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityList_CountryList_CountryID",
                        column: x => x.CountryID,
                        principalTable: "CountryList",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleList_CityId",
                table: "PeopleList",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityList_CountryID",
                table: "CityList",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleList_CityList_CityId",
                table: "PeopleList",
                column: "CityId",
                principalTable: "CityList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeopleList_CityList_CityId",
                table: "PeopleList");

            migrationBuilder.DropTable(
                name: "CityList");

            migrationBuilder.DropTable(
                name: "CountryList");

            migrationBuilder.DropIndex(
                name: "IX_PeopleList_CityId",
                table: "PeopleList");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "PeopleList");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PeopleList",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
