using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameZone.Migrations
{
    /// <inheritdoc />
    public partial class roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8bee2d3c-4f71-4909-93a2-4c98a0a4ba53", "259a385b-2195-4d54-9432-4a04dd6b9ef7", "User", "user" },
                    { "a75a0d6f-ca09-4045-8bc5-350a987bad10", "154cf855-7a15-4013-b85c-76e6f8ad2900", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bee2d3c-4f71-4909-93a2-4c98a0a4ba53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a75a0d6f-ca09-4045-8bc5-350a987bad10");
        }
    }
}
