using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHMS.Migrations
{
    /// <inheritdoc />
    public partial class AddingFieldsToTestResults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "NormalMax",
                table: "TestResults",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NormalMin",
                table: "TestResults",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TestName",
                table: "TestResults",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "TestResults",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "TestResults",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalMax",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "NormalMin",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "TestName",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "TestResults");
        }
    }
}
