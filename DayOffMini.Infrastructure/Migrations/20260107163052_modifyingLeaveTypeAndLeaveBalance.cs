using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DayOffMini.Migrations
{
    /// <inheritdoc />
    public partial class modifyingLeaveTypeAndLeaveBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "TotalDaysRemaining",
            //    table: "LeaveBalances");

            migrationBuilder.AlterColumn<decimal>(
                name: "DaysOffBalance",
                table: "LeaveTypes",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                table: "LeaveTypes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "DaysOffRemaining",
                table: "LeaveBalances",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "DaysOffBalance", "IsDefault", "Name" },
                values: new object[,]
                {
                    { 1, 14m, true, "Schedual" },
                    { 2, 7m, true, "Casual" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "DaysOffBalance",
                table: "LeaveTypes");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "LeaveTypes");

            migrationBuilder.DropColumn(
                name: "DaysOffRemaining",
                table: "LeaveBalances");

            migrationBuilder.AddColumn<int>(
                name: "TotalDaysRemaining",
                table: "LeaveBalances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
