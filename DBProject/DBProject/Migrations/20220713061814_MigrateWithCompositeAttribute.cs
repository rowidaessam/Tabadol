using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBProject.Migrations
{
    public partial class MigrateWithCompositeAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PersonalInformations");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "PersonalInformations",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "ASSAdress",
                table: "Associations",
                newName: "AssStreet");

            migrationBuilder.RenameColumn(
                name: "AdminName",
                table: "Admins",
                newName: "AdminLName");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PersonalInformations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "PersonalInformations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FName",
                table: "PersonalInformations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LName",
                table: "PersonalInformations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssCity",
                table: "Associations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssCountry",
                table: "Associations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdminFName",
                table: "Admins",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "PersonalInformations");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "PersonalInformations");

            migrationBuilder.DropColumn(
                name: "FName",
                table: "PersonalInformations");

            migrationBuilder.DropColumn(
                name: "LName",
                table: "PersonalInformations");

            migrationBuilder.DropColumn(
                name: "AssCity",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "AssCountry",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "AdminFName",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "PersonalInformations",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "AssStreet",
                table: "Associations",
                newName: "ASSAdress");

            migrationBuilder.RenameColumn(
                name: "AdminLName",
                table: "Admins",
                newName: "AdminName");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PersonalInformations",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }
    }
}
