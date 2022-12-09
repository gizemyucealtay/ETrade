using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETrade.Dal.Migrations
{
    public partial class basketmaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "BasketMaster",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "BasketMaster");
        }
    }
}
