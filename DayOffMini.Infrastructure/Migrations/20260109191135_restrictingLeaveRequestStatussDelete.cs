using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DayOffMini.Migrations
{
    /// <inheritdoc />
    public partial class restrictingLeaveRequestStatussDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_LeaveRequestStatuses_LeaveRequestStatusId",
                table: "LeaveRequests");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_LeaveRequestStatuses_LeaveRequestStatusId",
                table: "LeaveRequests",
                column: "LeaveRequestStatusId",
                principalTable: "LeaveRequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_LeaveRequestStatuses_LeaveRequestStatusId",
                table: "LeaveRequests");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_LeaveRequestStatuses_LeaveRequestStatusId",
                table: "LeaveRequests",
                column: "LeaveRequestStatusId",
                principalTable: "LeaveRequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
