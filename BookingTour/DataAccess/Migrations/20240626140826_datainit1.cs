using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class datainit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "HotelImages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7728), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7729) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7731), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7731) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7733), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7733) });

            migrationBuilder.UpdateData(
                table: "CategoryTours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7884), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7889) });

            migrationBuilder.UpdateData(
                table: "CategoryTours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7892), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7893) });

            migrationBuilder.UpdateData(
                table: "CategoryTours",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7894), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7895) });

            migrationBuilder.UpdateData(
                table: "CategoryTours",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7896), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7897) });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7817), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7818) });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7820), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7821) });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7822), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7823) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7510), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7513) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7516), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7517) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7518), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7519) });

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7768), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7769) });

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7772), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7773) });

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7774), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7775) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDay", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7560), new DateTime(2024, 7, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7563), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7562) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartDay", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7572), new DateTime(2024, 8, 10, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7574), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7573) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StartDay", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7577), new DateTime(2024, 8, 25, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7578), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7578) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(6988), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7001) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7009), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7013), new DateTime(2024, 6, 26, 21, 8, 24, 488, DateTimeKind.Local).AddTicks(7014) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "HotelImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1701), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1707) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1708), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1709) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1711), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1712) });

            migrationBuilder.UpdateData(
                table: "CategoryTours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1990), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1991) });

            migrationBuilder.UpdateData(
                table: "CategoryTours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1993), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1994) });

            migrationBuilder.UpdateData(
                table: "CategoryTours",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1996), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1996) });

            migrationBuilder.UpdateData(
                table: "CategoryTours",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1998), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1999) });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1889), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1890) });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1895), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1896) });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1898), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1899) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1495), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1498) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1505), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1505) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1507), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1508) });

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1752), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1754) });

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1758), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1759) });

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1761), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1761) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDay", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1560), new DateTime(2024, 7, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1563), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1562) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartDay", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1575), new DateTime(2024, 8, 10, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1576), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1575) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StartDay", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1578), new DateTime(2024, 8, 25, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1579), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1579) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(853), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(871) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(889), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(893), new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(894) });
        }
    }
}
