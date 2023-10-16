using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData
                (
                table: "Roles",
                schema: "Security",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "Admin", "Admin".ToUpper(), Guid.NewGuid().ToString() }
                );
            migrationBuilder.InsertData
               (
               table: "Roles",
               schema: "Security",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
               values: new object[] { Guid.NewGuid().ToString(), "Teacher", "Teacher".ToUpper(), Guid.NewGuid().ToString() }
               );
            migrationBuilder.InsertData
              (
              table: "Roles",
              schema: "Security",
              columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
              values: new object[] { Guid.NewGuid().ToString(), "Student", "student".ToUpper(), Guid.NewGuid().ToString() }
              );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [Security].[Roles]");
        }
    }
}
