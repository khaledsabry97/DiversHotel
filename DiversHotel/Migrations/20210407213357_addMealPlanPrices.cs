using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiversHotel.Migrations
{
    public partial class addMealPlanPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealPlanPrices",
                columns: table => new
                {
                    MealPlanTypeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MealPlanPrices_MealPlans_MealPlanTypeId",
                        column: x => x.MealPlanTypeId,
                        principalTable: "MealPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanPrices_MealPlanTypeId",
                table: "MealPlanPrices",
                column: "MealPlanTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealPlanPrices");
        }
    }
}
