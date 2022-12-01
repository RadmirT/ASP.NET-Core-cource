using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeApplication.Migrations
{
    public partial class ExtraRecipeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPescetarian",
                table: "Recipes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPescetarian",
                table: "Recipes");
        }
    }
}
