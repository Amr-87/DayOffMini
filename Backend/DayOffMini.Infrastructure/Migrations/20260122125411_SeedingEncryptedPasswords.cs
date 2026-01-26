using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DayOffMini.Migrations
{
    /// <inheritdoc />
    public partial class SeedingEncryptedPasswords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$ze1.ANcBDNd3JeiszbxXm.DUaGD8aHVo.U0IArbXCle0NgFUe/cMq");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$SgFz/Vihqbwx4TRv3DIg5u1spJkYg.9voSzAaScIa3.Ao77H809n2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "Amr@123");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "Yasser@123");
        }
    }
}
