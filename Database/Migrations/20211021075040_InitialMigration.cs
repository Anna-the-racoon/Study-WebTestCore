using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo.Securities.Security");

            migrationBuilder.EnsureSchema(
                name: "dbo.Securities.Users");

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

            migrationBuilder.CreateTable(
                name: "Security",
                schema: "dbo.Securities.Users",
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
                    table.PrimaryKey("PK_Security", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Security_Security_SecurityId",
                        column: x => x.SecurityId,
                        principalSchema: "dbo.Securities.Security",
                        principalTable: "Security",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Security_SecurityId",
                schema: "dbo.Securities.Users",
                table: "Security",
                column: "SecurityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Security",
                schema: "dbo.Securities.Users");

            migrationBuilder.DropTable(
                name: "Security",
                schema: "dbo.Securities.Security");
        }
    }
}
