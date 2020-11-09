using Microsoft.EntityFrameworkCore.Migrations;

namespace quiz2.Migrations
{
    public partial class AddRegisNumToCarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegisNum",
                table: "Car",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisNum",
                table: "Car");
        }
    }
}
