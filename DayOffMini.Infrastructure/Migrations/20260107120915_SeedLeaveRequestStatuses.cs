using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DayOffMini.Migrations
{
    /// <inheritdoc />
    public partial class SeedLeaveRequestStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveRequestStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Approved" },
                    { 3, "Rejected" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveRequestStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveRequestStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeaveRequestStatuses",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
