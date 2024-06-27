using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class datainit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: false),
                    CreaateBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalRoom = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Users_CreateBy",
                        column: x => x.CreateBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Users_CreateBy",
                        column: x => x.CreateBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    RefreshTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpriedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.RefreshTokenId);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelImages_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: false),
                    CategoryTourId = table.Column<int>(type: "int", nullable: false),
                    StartDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    TotalDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tours_CategoryTours_CategoryTourId",
                        column: x => x.CategoryTourId,
                        principalTable: "CategoryTours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tours_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tours_Users_CreateBy",
                        column: x => x.CreateBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalBill = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourDetails",
                columns: table => new
                {
                    TourId = table.Column<int>(type: "int", nullable: false),
                    TotalSlot = table.Column<int>(type: "int", nullable: false),
                    AvailableSlot = table.Column<int>(type: "int", nullable: false),
                    DepartureLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transportation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    PricePerPerson = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourDetails", x => x.TourId);
                    table.ForeignKey(
                        name: "FK_TourDetails_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourImages_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TourLocations_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourGuides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGuides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourGuides_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CategoryTours",
                columns: new[] { "Id", "CreaateBy", "CreatedAt", "ModifyBy", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1990), 0, "Adventure Tours", "Active", new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1991) },
                    { 2, 0, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1993), 0, "Cultural Tours", "Active", new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1994) },
                    { 3, 0, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1996), 0, "Beach Vacations", "Active", new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1996) },
                    { 4, 0, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1998), 0, "City Breaks", "Active", new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1999) }
                });

            migrationBuilder.InsertData(
                table: "TourGuides",
                columns: new[] { "Id", "CreateBy", "CreatedAt", "Email", "Fullname", "ModifyBy", "Phone", "Status", "TicketId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1752), "john@example.com", "John Doe", 0, "1112223333", "Available", null, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1754) },
                    { 2, 0, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1758), "jane@example.com", "Jane Smith", 0, "4445556666", "Available", null, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1759) },
                    { 3, 0, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1761), "mike@example.com", "Mike Johnson", 0, "7778889999", "Busy", null, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1761) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DoB", "Email", "Fullname", "Password", "Phone", "Role", "Status", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, "123 Admin St", new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(853), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin User", "admin123", "1234567890", "Admin", "Active", new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(871), "admin" },
                    { 2, "456 User Ave", new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(889), new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", "Regular User", "user123", "9876543210", "User", "Active", new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(890), "user1" },
                    { 3, "789 Guide Rd", new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(893), new DateTime(1988, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "guide1@example.com", "Tour Guide", "guide123", "5555555555", "Guide", "Active", new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(894), "guide1" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CreateBy", "CreatedAt", "Description", "ModifyBy", "Name", "Status", "TotalRoom", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "1 Champs-Élysées, Paris", 1, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1889), "5-star hotel in the heart of Paris", 0, "Luxury Paris Hotel", "Open", 200, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1890) },
                    { 2, "1-1-1 Shibuya, Tokyo", 1, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1895), "Modern hotel with a view of Tokyo skyline", 0, "Tokyo Skyline Hotel", "Open", 300, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1896) },
                    { 3, "5th Avenue, New York", 1, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1898), "Iconic New York hotel", 0, "New York Plaza", "Open", 400, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1899) }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "CreateBy", "CreatedAt", "Description", "ModifyBy", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Paris, France", 1, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1495), "City of Love", 0, "Paris", "Active", new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1498) },
                    { 2, "Tokyo, Japan", 1, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1505), "Vibrant Metropolis", 0, "Tokyo", "Active", new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1505) },
                    { 3, "New York, USA", 1, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1507), "The Big Apple", 0, "New York", "Active", new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1508) }
                });

            migrationBuilder.InsertData(
                table: "HotelImages",
                columns: new[] { "Id", "HotelId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://example.com/paris_hotel.jpg" },
                    { 2, 2, "https://example.com/tokyo_hotel.jpg" },
                    { 3, 3, "https://example.com/nyc" }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "CategoryTourId", "CreateBy", "CreatedAt", "Description", "HotelId", "ModifyBy", "Name", "Price", "StartDay", "Status", "TotalDay", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1560), "Explore the iconic Eiffel Tower", 1, 0, "Eiffel Tower Adventure", 100.0, new DateTime(2024, 7, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1563), "Available", "1", new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1562) },
                    { 2, 2, 1, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1575), "Taste the best sushi in Tokyo", 2, 0, "Tokyo Sushi Experience", 150.0, new DateTime(2024, 8, 10, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1576), "Available", "2", new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1575) },
                    { 3, 3, 1, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1578), "Enjoy a Broadway musical in New York", 3, 0, "NYC Broadway Show", 200.0, new DateTime(2024, 8, 25, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1579), "Available", "3", new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1579) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CreatedAt", "Status", "TourId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1701), "Confirmed", 1, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1707), 2 },
                    { 2, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1708), "Pending", 2, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1709), 2 },
                    { 3, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1711), "Confirmed", 3, new DateTime(2024, 6, 26, 20, 26, 43, 888, DateTimeKind.Local).AddTicks(1712), 3 }
                });

            migrationBuilder.InsertData(
                table: "TourImages",
                columns: new[] { "Id", "TourId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://example.com/eiffel.jpg" },
                    { 2, 2, "https://example.com/sushi.jpg" },
                    { 3, 3, "https://example.com/broadway.jpg" }
                });

            migrationBuilder.InsertData(
                table: "TourLocations",
                columns: new[] { "Id", "LocationId", "Status", "TourId" },
                values: new object[,]
                {
                    { 1, 1, "ACTIVE", 1 },
                    { 2, 2, "ACTIVE", 2 },
                    { 3, 3, "ACTIVE", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TourId",
                table: "Bookings",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelImages_HotelId",
                table: "HotelImages",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CreateBy",
                table: "Hotels",
                column: "CreateBy");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CreateBy",
                table: "Locations",
                column: "CreateBy");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TourId",
                table: "Ticket",
                column: "TourId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TourGuides_TicketId",
                table: "TourGuides",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TourImages_TourId",
                table: "TourImages",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TourLocations_LocationId",
                table: "TourLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TourLocations_TourId",
                table: "TourLocations",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_CategoryTourId",
                table: "Tours",
                column: "CategoryTourId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_CreateBy",
                table: "Tours",
                column: "CreateBy");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_HotelId",
                table: "Tours",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "HotelImages");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "TourDetails");

            migrationBuilder.DropTable(
                name: "TourGuides");

            migrationBuilder.DropTable(
                name: "TourImages");

            migrationBuilder.DropTable(
                name: "TourLocations");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "CategoryTours");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
