#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "Employees",
            table => new
            {
                Id = table.Column<Guid>("uuid", nullable: false),
                Name = table.Column<string>("character varying(200)", maxLength: 200, nullable: false),
                Email = table.Column<string>("character varying(120)", maxLength: 120, nullable: false),
                IsActive = table.Column<bool>("boolean", nullable: false),
                IsDeleted = table.Column<bool>("boolean", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Employees", x => x.Id); });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "Employees");
    }
}