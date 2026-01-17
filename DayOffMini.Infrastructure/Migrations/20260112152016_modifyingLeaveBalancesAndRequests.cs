using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DayOffMini.Migrations
{
    /// <inheritdoc />
    public partial class modifyingLeaveBalancesAndRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DaysOffRemaining",
                table: "LeaveBalances",
                newName: "FixedDaysOffBalance");

            migrationBuilder.AddColumn<decimal>(
                name: "DurationInDays",
                table: "LeaveRequests",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInDays",
                table: "LeaveRequests");

            migrationBuilder.RenameColumn(
                name: "FixedDaysOffBalance",
                table: "LeaveBalances",
                newName: "DaysOffRemaining");
        }
    }
}
