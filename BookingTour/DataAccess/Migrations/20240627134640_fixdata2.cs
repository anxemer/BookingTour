using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fixdata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "TourImages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ModifyBy",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AmoutPeople",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2334), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2335) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2336), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2337) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2367), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2367) });

            migrationBuilder.UpdateData(
                table: "CategoryTours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2466), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2467) });

            migrationBuilder.UpdateData(
                table: "CategoryTours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2468), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2469) });

            migrationBuilder.UpdateData(
                table: "CategoryTours",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2470), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2470) });

            migrationBuilder.UpdateData(
                table: "CategoryTours",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2471), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2472) });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2420), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2420) });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2423), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2423) });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2425), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2425) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2217), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2218) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2220), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2221) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2222), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2222) });

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2392), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2393) });

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2395), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2395) });

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2396), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2397) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDay", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2250), new DateTime(2024, 7, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2251), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2250) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartDay", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2258), new DateTime(2024, 8, 11, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2259), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2259) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StartDay", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2261), new DateTime(2024, 8, 26, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2262), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2262) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2001), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2013) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2018), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2019) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2021), new DateTime(2024, 6, 27, 20, 46, 37, 870, DateTimeKind.Local).AddTicks(2022) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmoutPeople",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Ticket");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "TourImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifyBy",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
