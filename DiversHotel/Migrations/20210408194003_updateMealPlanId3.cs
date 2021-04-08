using Microsoft.EntityFrameworkCore.Migrations;

namespace DiversHotel.Migrations
{
    public partial class updateMealPlanId3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlanPrices_MealPlans_MealPlanTypeId",
                table: "MealPlanPrices");

            migrationBuilder.DropIndex(
                name: "IX_MealPlanPrices_MealPlanTypeId",
                table: "MealPlanPrices");

            migrationBuilder.DropColumn(
                name: "MealPlanTypeId",
                table: "MealPlanPrices");

            migrationBuilder.AddColumn<int>(
                name: "MealPlanId",
                table: "MealPlanPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanPrices_MealPlanId",
                table: "MealPlanPrices",
                column: "MealPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlanPrices_MealPlans_MealPlanId",
                table: "MealPlanPrices",
                column: "MealPlanId",
                principalTable: "MealPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlanPrices_MealPlans_MealPlanId",
                table: "MealPlanPrices");

            migrationBuilder.DropIndex(
                name: "IX_MealPlanPrices_MealPlanId",
                table: "MealPlanPrices");

            migrationBuilder.DropColumn(
                name: "MealPlanId",
                table: "MealPlanPrices");

            migrationBuilder.AddColumn<int>(
                name: "MealPlanTypeId",
                table: "MealPlanPrices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanPrices_MealPlanTypeId",
                table: "MealPlanPrices",
                column: "MealPlanTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlanPrices_MealPlans_MealPlanTypeId",
                table: "MealPlanPrices",
                column: "MealPlanTypeId",
                principalTable: "MealPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
