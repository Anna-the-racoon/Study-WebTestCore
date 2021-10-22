using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class Migration001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Security_Security_SecurityId",
                schema: "dbo.Securities.Users",
                table: "Security");

            migrationBuilder.DropTable(
                name: "Security",
                schema: "dbo.Securities.Security");

            migrationBuilder.DropIndex(
                name: "IX_Security_SecurityId",
                schema: "dbo.Securities.Users",
                table: "Security");

            migrationBuilder.DropColumn(
                name: "Age",
                schema: "dbo.Securities.Users",
                table: "Security");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo.Securities.Users",
                table: "Security");

            migrationBuilder.DropColumn(
                name: "SecurityId",
                schema: "dbo.Securities.Users",
                table: "Security");

            migrationBuilder.EnsureSchema(
                name: "dbo.Securities");

            migrationBuilder.RenameTable(
                name: "Security",
                schema: "dbo.Securities.Users",
                newName: "Security",
                newSchema: "dbo.Securities");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                schema: "dbo.Securities",
                table: "Security",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "dbo.Securities",
                table: "Security",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo.Securities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    SecurityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Security_SecurityId",
                        column: x => x.SecurityId,
                        principalSchema: "dbo.Securities",
                        principalTable: "Security",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SecurityId",
                schema: "dbo.Securities",
                table: "Users",
                column: "SecurityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo.Securities");

            migrationBuilder.DropColumn(
                name: "Login",
                schema: "dbo.Securities",
                table: "Security");

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "dbo.Securities",
                table: "Security");

            migrationBuilder.EnsureSchema(
                name: "dbo.Securities.Security");

            migrationBuilder.EnsureSchema(
                name: "dbo.Securities.Users");

            migrationBuilder.RenameTable(
                name: "Security",
                schema: "dbo.Securities",
                newName: "Security",
                newSchema: "dbo.Securities.Users");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                schema: "dbo.Securities.Users",
                table: "Security",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo.Securities.Users",
                table: "Security",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SecurityId",
                schema: "dbo.Securities.Users",
                table: "Security",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Security",
                schema: "dbo.Securities.Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Security_SecurityId",
                schema: "dbo.Securities.Users",
                table: "Security",
                column: "SecurityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Security_Security_SecurityId",
                schema: "dbo.Securities.Users",
                table: "Security",
                column: "SecurityId",
                principalSchema: "dbo.Securities.Security",
                principalTable: "Security",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
