using Microsoft.EntityFrameworkCore.Migrations;

namespace DiversHotel.Migrations
{
    public partial class updateKeyless : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RoomPrices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MealPlanPrices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomPrices",
                table: "RoomPrices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealPlanPrices",
                table: "MealPlanPrices",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomPrices",
                table: "RoomPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealPlanPrices",
                table: "MealPlanPrices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RoomPrices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MealPlanPrices");
        }
    }
}
