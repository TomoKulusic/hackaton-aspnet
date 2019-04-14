using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace smart_housing_aspnet.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Electricity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    TarriffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electricity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityTariff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ElectricityTariffEnum = table.Column<int>(nullable: false),
                    OneTarrif = table.Column<double>(nullable: true),
                    HighTarrif = table.Column<double>(nullable: true),
                    LowTarrif = table.Column<double>(nullable: true),
                    SupplyFee = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityTariff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Water",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    TarriffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Water", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterTariff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WaterTariffEnum = table.Column<int>(nullable: false),
                    Tariff = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterTariff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WaterId = table.Column<int>(nullable: true),
                    ElectricityId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    SmartHouseCityRegion = table.Column<int>(nullable: false),
                    UtilityType = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilities_Electricity_ElectricityId",
                        column: x => x.ElectricityId,
                        principalTable: "Electricity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Utilities_Water_WaterId",
                        column: x => x.WaterId,
                        principalTable: "Water",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Electricity",
                columns: new[] { "Id", "Amount", "TarriffId" },
                values: new object[,]
                {
                    { 1, 8.2100000000000009, 1 },
                    { 28, 8.6899999999999995, 3 },
                    { 29, 7.2699999999999996, 3 },
                    { 31, 7.6900000000000004, 2 },
                    { 32, 9.1099999999999994, 3 },
                    { 33, 10.869999999999999, 1 },
                    { 34, 7.9100000000000001, 2 },
                    { 35, 9.0099999999999998, 3 },
                    { 36, 9.1199999999999992, 1 },
                    { 37, 10.06, 2 },
                    { 38, 6.9800000000000004, 3 },
                    { 27, 11.56, 3 },
                    { 39, 7.3200000000000003, 1 },
                    { 41, 8.8900000000000006, 3 },
                    { 42, 9.3399999999999999, 1 },
                    { 43, 7.96, 2 },
                    { 44, 7.6100000000000003, 3 },
                    { 45, 8.6099999999999994, 1 },
                    { 46, 7.9000000000000004, 2 },
                    { 47, 8.3100000000000005, 3 },
                    { 48, 9.3699999999999992, 1 },
                    { 49, 10.279999999999999, 2 },
                    { 50, 9.4900000000000002, 3 },
                    { 40, 7.3099999999999996, 2 },
                    { 26, 9.5099999999999998, 3 },
                    { 30, 8.3100000000000005, 1 },
                    { 24, 6.21, 3 },
                    { 2, 8.9100000000000001, 1 },
                    { 3, 10.359999999999999, 1 },
                    { 4, 9.5099999999999998, 1 },
                    { 5, 9.9100000000000001, 1 },
                    { 6, 7.21, 1 },
                    { 7, 7.5599999999999996, 1 },
                    { 8, 7.9100000000000001, 1 },
                    { 25, 8.5600000000000005, 3 },
                    { 10, 9.5600000000000005, 1 },
                    { 11, 8.9100000000000001, 2 },
                    { 12, 6.9100000000000001, 2 },
                    { 9, 8.5099999999999998, 1 },
                    { 14, 8.9100000000000001, 2 },
                    { 23, 7.21, 3 },
                    { 13, 8.5099999999999998, 2 },
                    { 21, 6.5099999999999998, 3 },
                    { 20, 6.9100000000000001, 3 },
                    { 22, 8.5600000000000005, 3 },
                    { 18, 3.5600000000000001, 2 },
                    { 17, 8.5099999999999998, 2 },
                    { 16, 7.21, 2 },
                    { 15, 7.5599999999999996, 2 },
                    { 19, 6.21, 2 }
                });

            migrationBuilder.InsertData(
                table: "ElectricityTariff",
                columns: new[] { "Id", "ElectricityTariffEnum", "HighTarrif", "LowTarrif", "OneTarrif", "SupplyFee" },
                values: new object[,]
                {
                    { 1, 1, null, null, 0.22, 10.0 },
                    { 2, 2, 0.12, 0.23999999999999999, null, 10.0 },
                    { 3, 3, 0.080000000000000002, 0.16, null, 41.299999999999997 },
                    { 4, 4, null, null, 0.13, 5.7999999999999998 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "96c90590-2b46-4580-826f-a0dda13be6f4", "Role", "User", "user" },
                    { 2, "96c90590-2b46-4580-826f-a0dda13be6f4", "Role", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 5, 0, "19d5bf5c-cd03-4e47-a470-22073f076b25", "frano.nola@gmail.com", false, "Nola", false, null, "Frano", null, null, "AQAAAAEAACcQAAAAEMja3Hvpz03jeAUI0QUcHFUxIdtXWq+T30bijfH5a4TUpgZkXd0qRKJ8BzerjOZ9ZQ==", null, false, "96c90590-2b46-4580-826f-a0dda13be6f4", false, "frano.nola" },
                    { 6, 0, "2543b476-2eb4-4d69-a276-9745ff347018", "user@gmail.com", false, "User", false, null, "User", null, null, "AQAAAAEAACcQAAAAEJMCj6bMd8GhZbS7RNL+43LlOJo0IfY79qRVB6P4fxaXfMT8eAgJ7JYnrpKIcqz+Yw==", null, false, "96c90590-2b46-4580-826f-a0dda13be6f4", false, "user" },
                    { 4, 0, "b419c457-9580-4503-b595-17819f74c60a", "stipe.brzi@gmail.com", false, "Brzica", false, null, "Stjepan", null, null, "AQAAAAEAACcQAAAAEIZeJ5bbSXsDJqDj+5vZn3e78Vz03FFNR+FDQwA3fCEcP3rHgibXx++LerDgH7AaRQ==", null, false, "96c90590-2b46-4580-826f-a0dda13be6f4", false, "stipe.brzi" },
                    { 1, 0, "5598d4b3-00b5-4c92-b78e-f97294cf75cc", "tomokulusic@gmail.com", false, "Kulusic", false, null, "Tomislav", null, null, "AQAAAAEAACcQAAAAEHj/UeLVYx8rYkAxpdYRgxO3YT3BOBwzsyaKk4PxneA5tx1Wshlhif+arIJ79JsTqQ==", null, false, "96c90590-2b46-4580-826f-a0dda13be6f4", false, "tomokulusic" },
                    { 2, 0, "58403128-074c-44d2-8438-7f9d04d5fae9", "petar.kleskovic@enum.hr", false, "Kleskovic", false, null, "Petar", null, null, "AQAAAAEAACcQAAAAEAqI7G1pQeQ/2sSunvu+V/8rJkRvyyhUxjYukozlsB3I+XwjxGz7ZWgtpBBxPJcJkA==", null, false, "96c90590-2b46-4580-826f-a0dda13be6f4", false, "petar.kleskovic" },
                    { 3, 0, "85a4f629-3dd5-4520-a503-fab3415d7f05", "kxl9597@g.rit.edu", false, "Lucijanovic", false, null, "Klara", null, null, "AQAAAAEAACcQAAAAEDZLjSj+efHv21VCUrif6qSPXHjP3df3yj8r6OlMF7AQUqX6lw8mr6Ile33wCyOgHg==", null, false, "96c90590-2b46-4580-826f-a0dda13be6f4", false, "kxl9597" }
                });

            migrationBuilder.InsertData(
                table: "Water",
                columns: new[] { "Id", "Amount", "TarriffId" },
                values: new object[,]
                {
                    { 49, 0.23000000000000001, 1 },
                    { 27, 0.35999999999999999, 2 },
                    { 28, 0.20999999999999999, 2 },
                    { 29, 0.31, 2 },
                    { 30, 0.17999999999999999, 2 },
                    { 31, 0.28000000000000003, 1 },
                    { 32, 0.31, 2 },
                    { 33, 0.20999999999999999, 1 },
                    { 34, 0.12, 2 },
                    { 35, 0.17000000000000001, 1 },
                    { 36, 0.22, 2 },
                    { 50, 0.17000000000000001, 2 },
                    { 37, 0.14999999999999999, 1 },
                    { 39, 0.28999999999999998, 1 },
                    { 40, 0.20999999999999999, 2 },
                    { 41, 0.22, 1 },
                    { 42, 0.23000000000000001, 2 },
                    { 43, 0.20999999999999999, 1 },
                    { 44, 0.32000000000000001, 2 },
                    { 45, 0.32000000000000001, 1 },
                    { 46, 0.25, 2 },
                    { 47, 0.14999999999999999, 1 },
                    { 48, 0.28000000000000003, 2 },
                    { 26, 0.14000000000000001, 2 },
                    { 38, 0.12, 2 },
                    { 25, 0.16, 2 },
                    { 23, 0.20999999999999999, 2 },
                    { 1, 0.20999999999999999, 1 },
                    { 2, 0.22, 1 },
                    { 3, 0.35999999999999999, 1 },
                    { 4, 0.31, 1 },
                    { 5, 0.23000000000000001, 1 },
                    { 6, 0.26000000000000001, 1 },
                    { 7, 0.16, 1 },
                    { 8, 0.20999999999999999, 1 },
                    { 9, 0.31, 1 },
                    { 10, 0.16, 1 },
                    { 24, 0.27000000000000002, 2 },
                    { 11, 0.11, 1 },
                    { 13, 0.13, 1 },
                    { 14, 0.31, 1 },
                    { 15, 0.26000000000000001, 2 },
                    { 16, 0.20999999999999999, 2 },
                    { 17, 0.19, 2 },
                    { 18, 0.20000000000000001, 2 },
                    { 19, 0.17000000000000001, 2 },
                    { 20, 0.27000000000000002, 2 },
                    { 21, 0.23000000000000001, 2 },
                    { 22, 0.26000000000000001, 2 },
                    { 12, 0.91000000000000003, 1 }
                });

            migrationBuilder.InsertData(
                table: "WaterTariff",
                columns: new[] { "Id", "Tariff", "WaterTariffEnum" },
                values: new object[,]
                {
                    { 1, 11.949999999999999, 1 },
                    { 2, 20.93, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId", "Discriminator", "Id" },
                values: new object[,]
                {
                    { 3, 2, "UserRole", 3 },
                    { 2, 2, "UserRole", 2 },
                    { 1, 2, "UserRole", 1 },
                    { 6, 1, "UserRole", 6 },
                    { 5, 2, "UserRole", 5 },
                    { 4, 2, "UserRole", 4 }
                });

            migrationBuilder.InsertData(
                table: "Utilities",
                columns: new[] { "Id", "Amount", "Date", "ElectricityId", "SmartHouseCityRegion", "UserId", "UtilityType", "WaterId" },
                values: new object[,]
                {
                    { 76, 96.209999999999994, new DateTime(2019, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 0, 1, 38 },
                    { 45, 67.909999999999997, new DateTime(2019, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 0, 1, 15 },
                    { 44, 41.890000000000001, new DateTime(2019, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 0, 1, 14 },
                    { 43, 78.909999999999997, new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 0, 1, 13 },
                    { 42, 87.219999999999999, new DateTime(2019, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0, 1, 12 },
                    { 41, 111.20999999999999, new DateTime(2019, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0, 1, 11 },
                    { 40, 60.810000000000002, new DateTime(2019, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0, 1, 10 },
                    { 39, 67.909999999999997, new DateTime(2019, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 0, 1, 9 },
                    { 38, 78.909999999999997, new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 0, 1, 8 },
                    { 46, 111.20999999999999, new DateTime(2019, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 0, 1, 16 },
                    { 37, 41.899999999999999, new DateTime(2019, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 0, 1, 7 },
                    { 35, 151.99000000000001, new DateTime(2019, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 0, 1, 5 },
                    { 34, 51.210000000000001, new DateTime(2019, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 0, 1, 4 },
                    { 33, 111.20999999999999, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 0, 1, 3 },
                    { 32, 121.91, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 0, 1, 2 },
                    { 31, 78.909999999999997, new DateTime(2019, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 0, 1, 1 },
                    { 82, 81.269999999999996, new DateTime(2019, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0, 1, 41 },
                    { 84, 68.920000000000002, new DateTime(2019, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 0, 1, 42 },
                    { 86, 69.819999999999993, new DateTime(2019, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 0, 1, 43 },
                    { 36, 56.780000000000001, new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 0, 1, 6 },
                    { 78, 85.920000000000002, new DateTime(2019, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 0, 1, 39 },
                    { 47, 56.780000000000001, new DateTime(2019, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 0, 1, 17 },
                    { 49, 78.909999999999997, new DateTime(2019, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 0, 1, 19 },
                    { 74, 86.569999999999993, new DateTime(2019, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0, 1, 37 },
                    { 72, 95.209999999999994, new DateTime(2019, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0, 1, 36 },
                    { 70, 49.210000000000001, new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 0, 1, 35 },
                    { 68, 81.209999999999994, new DateTime(2019, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 0, 1, 34 },
                    { 66, 89.010000000000005, new DateTime(2019, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0, 1, 33 },
                    { 64, 71.890000000000001, new DateTime(2019, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0, 1, 32 },
                    { 62, 90.709999999999994, new DateTime(2019, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 0, 1, 31 },
                    { 60, 81.980000000000004, new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0, 1, 30 },
                    { 48, 41.899999999999999, new DateTime(2019, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 0, 1, 18 },
                    { 59, 71.209999999999994, new DateTime(2019, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0, 1, 29 },
                    { 57, 56.780000000000001, new DateTime(2019, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0, 1, 27 },
                    { 56, 111.20999999999999, new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 0, 1, 26 },
                    { 55, 67.909999999999997, new DateTime(2019, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 0, 1, 25 },
                    { 54, 78.909999999999997, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 0, 1, 24 },
                    { 53, 60.810000000000002, new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 0, 1, 23 },
                    { 52, 56.780000000000001, new DateTime(2019, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 0, 1, 22 },
                    { 51, 41.890000000000001, new DateTime(2019, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 0, 1, 21 },
                    { 80, 85.709999999999994, new DateTime(2019, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0, 1, 40 },
                    { 58, 67.909999999999997, new DateTime(2019, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0, 1, 28 },
                    { 50, 67.909999999999997, new DateTime(2019, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 0, 1, 20 },
                    { 1, 53.210000000000001, new DateTime(2019, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 0, 2, null },
                    { 89, 72.890000000000001, new DateTime(2019, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 7, 0, 2, null },
                    { 20, 111.20999999999999, new DateTime(2019, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 5, 0, 2, null },
                    { 19, 60.810000000000002, new DateTime(2019, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 5, 0, 2, null },
                    { 18, 41.890000000000001, new DateTime(2019, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 7, 0, 2, null },
                    { 17, 67.909999999999997, new DateTime(2019, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 7, 0, 2, null },
                    { 16, 56.780000000000001, new DateTime(2019, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 7, 0, 2, null },
                    { 15, 111.20999999999999, new DateTime(2019, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2, 0, 2, null },
                    { 14, 78.909999999999997, new DateTime(2019, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 2, 0, 2, null },
                    { 13, 51.560000000000002, new DateTime(2019, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 2, 0, 2, null },
                    { 12, 56.880000000000003, new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 3, 0, 2, null },
                    { 11, 11.210000000000001, new DateTime(2019, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 3, 0, 2, null },
                    { 10, 78.900000000000006, new DateTime(2019, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 3, 0, 2, null },
                    { 9, 51.210000000000001, new DateTime(2019, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 6, 0, 2, null },
                    { 8, 56.509999999999998, new DateTime(2019, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 6, 0, 2, null },
                    { 7, 87.909999999999997, new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 6, 0, 2, null },
                    { 6, 157.11000000000001, new DateTime(2019, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 8, 0, 2, null },
                    { 5, 156.91, new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 8, 0, 2, null },
                    { 4, 112.20999999999999, new DateTime(2019, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 8, 0, 2, null },
                    { 3, 65.109999999999999, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 0, 2, null },
                    { 2, 43.210000000000001, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 0, 2, null },
                    { 21, 41.899999999999999, new DateTime(2019, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 5, 0, 2, null },
                    { 22, 78.909999999999997, new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 5, 0, 2, null },
                    { 23, 56.780000000000001, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 5, 0, 2, null },
                    { 24, 67.909999999999997, new DateTime(2019, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, 0, 2, null },
                    { 87, 71.799999999999997, new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 6, 0, 2, null },
                    { 85, 96.650000000000006, new DateTime(2019, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 1, 0, 2, null },
                    { 83, 85.790000000000006, new DateTime(2019, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, 5, 0, 2, null },
                    { 81, 78.689999999999998, new DateTime(2019, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, 7, 0, 2, null },
                    { 79, 81.930000000000007, new DateTime(2019, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 6, 0, 2, null },
                    { 77, 61.82, new DateTime(2019, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 1, 0, 2, null },
                    { 75, 71.930000000000007, new DateTime(2019, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 5, 0, 2, null },
                    { 73, 72.310000000000002, new DateTime(2019, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 7, 0, 2, null },
                    { 71, 59.609999999999999, new DateTime(2019, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, 6, 0, 2, null },
                    { 88, 61.719999999999999, new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0, 1, 44 },
                    { 69, 71.849999999999994, new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, 1, 0, 2, null },
                    { 65, 92.609999999999999, new DateTime(2019, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 7, 0, 2, null },
                    { 63, 61.719999999999999, new DateTime(2019, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 6, 0, 2, null },
                    { 61, 91.719999999999999, new DateTime(2019, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 1, 0, 2, null },
                    { 30, 41.890000000000001, new DateTime(2019, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 4, 0, 2, null },
                    { 29, 67.909999999999997, new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 4, 0, 2, null },
                    { 28, 51.210000000000001, new DateTime(2019, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 4, 0, 2, null },
                    { 27, 56.780000000000001, new DateTime(2019, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 4, 0, 2, null },
                    { 26, 111.20999999999999, new DateTime(2019, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 4, 0, 2, null },
                    { 25, 151.99000000000001, new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 4, 0, 2, null },
                    { 67, 71.510000000000005, new DateTime(2019, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 5, 0, 2, null },
                    { 90, 86.319999999999993, new DateTime(2019, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 0, 1, 45 }
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilities_ElectricityId",
                table: "Utilities",
                column: "ElectricityId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilities_WaterId",
                table: "Utilities",
                column: "WaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricityTariff");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Utilities");

            migrationBuilder.DropTable(
                name: "WaterTariff");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Electricity");

            migrationBuilder.DropTable(
                name: "Water");
        }
    }
}
