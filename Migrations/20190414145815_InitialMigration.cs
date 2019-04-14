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
                    AccessFailedCount = table.Column<int>(nullable: false)
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
                    { 1, 100.20999999999999, 1 },
                    { 28, 81.209999999999994, 3 },
                    { 29, 71.209999999999994, 3 },
                    { 31, 46.609999999999999, 2 },
                    { 32, 69.109999999999999, 3 },
                    { 33, 54.210000000000001, 1 },
                    { 34, 79.609999999999999, 2 },
                    { 35, 91.909999999999997, 3 },
                    { 36, 99.120000000000005, 1 },
                    { 37, 101.91, 2 },
                    { 38, 60.979999999999997, 3 },
                    { 27, 41.560000000000002, 3 },
                    { 39, 71.310000000000002, 1 },
                    { 41, 68.390000000000001, 3 },
                    { 42, 91.540000000000006, 1 },
                    { 43, 71.959999999999994, 2 },
                    { 44, 72.609999999999999, 3 },
                    { 45, 81.609999999999999, 1 },
                    { 46, 76.900000000000006, 2 },
                    { 47, 28.309999999999999, 3 },
                    { 48, 79.370000000000005, 1 },
                    { 49, 61.280000000000001, 2 },
                    { 50, 39.909999999999997, 3 },
                    { 40, 75.909999999999997, 2 },
                    { 26, 69.510000000000005, 3 },
                    { 30, 78.510000000000005, 1 },
                    { 24, 56.210000000000001, 3 },
                    { 2, 81.209999999999994, 1 },
                    { 3, 111.56, 1 },
                    { 4, 131.50999999999999, 1 },
                    { 5, 95.909999999999997, 1 },
                    { 6, 71.209999999999994, 1 },
                    { 7, 78.560000000000002, 1 },
                    { 8, 71.909999999999997, 1 },
                    { 25, 89.560000000000002, 3 },
                    { 10, 90.560000000000002, 1 },
                    { 11, 81.909999999999997, 2 },
                    { 12, 67.909999999999997, 2 },
                    { 9, 87.510000000000005, 1 },
                    { 14, 86.909999999999997, 2 },
                    { 23, 51.210000000000001, 3 },
                    { 13, 89.510000000000005, 2 },
                    { 21, 67.510000000000005, 3 },
                    { 20, 69.909999999999997, 3 },
                    { 22, 81.560000000000002, 3 },
                    { 18, 34.560000000000002, 2 },
                    { 17, 89.510000000000005, 2 },
                    { 16, 78.209999999999994, 2 },
                    { 15, 71.560000000000002, 2 },
                    { 19, 62.210000000000001, 2 }
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
                    { 1, "29035129-c3d2-490b-86de-ab21589ad237", "Role", "User", "user" },
                    { 2, "29035129-c3d2-490b-86de-ab21589ad237", "Role", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 5, 0, "f29a9019-07e2-4429-ac5b-4ec22121563e", "frano.nola@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEMufzOiKeazHOdD2sUP7t88KM3CkAh2QhCvhs16RNuVNGxMc5mmG+Dybrcli6GXQBA==", null, false, "29035129-c3d2-490b-86de-ab21589ad237", false, "frano.nola" },
                    { 6, 0, "ff975a1c-93ab-4ad1-81a3-b9dcfa7309cf", "user@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAENWmUTL3hPUvNv1ZbsDqQK4cFIe2g9IvQYFBcL+j9AqqXxt3LRncouogLx0S+tLVOA==", null, false, "29035129-c3d2-490b-86de-ab21589ad237", false, "user" },
                    { 4, 0, "acaaff1a-6903-4e29-88de-389fa6e3007e", "stipe.brzi@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEIpBd/GCfh/AhcIYmQvkMRdw6C9tRRgGIIriRGFlC2EJNl55F6MDT5m+8NqUV+23+g==", null, false, "29035129-c3d2-490b-86de-ab21589ad237", false, "stipe.brzi" },
                    { 1, 0, "ae24e7da-49e2-4f97-865d-b8c6d2a20176", "tomokulusic@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEIdlsAeeWn9SVi+kVchHZgIrakKdRERO6dEp9aTdQTxi5ghV3PZU0yY2tYqPMQDvgg==", null, false, "29035129-c3d2-490b-86de-ab21589ad237", false, "tomokulusic" },
                    { 2, 0, "ed6fde35-6f50-4ac8-87c5-615499649abc", "petar.kleskovic@enum.hr", false, false, null, null, null, "AQAAAAEAACcQAAAAEAq5v2QQfj8IS5ac5WhoSapVT6D6FGuta/1tS75ezb2E8Q9bAvFBTiHsGUWzgbzVYQ==", null, false, "29035129-c3d2-490b-86de-ab21589ad237", false, "petar.kleskovic" },
                    { 3, 0, "11b293fb-99a7-45a1-87b4-7ed17a005332", "kxl9597@g.rit.edu", false, false, null, null, null, "AQAAAAEAACcQAAAAEO5vuulaOWaiVfclemQ/XuowSvEBBjV2dbitBZ75oU364kRwPLRBbpZBZ0KAh4cseA==", null, false, "29035129-c3d2-490b-86de-ab21589ad237", false, "kxl9597" }
                });

            migrationBuilder.InsertData(
                table: "Water",
                columns: new[] { "Id", "Amount", "TarriffId" },
                values: new object[,]
                {
                    { 49, 84.909999999999997, 1 },
                    { 27, 141.56, 2 },
                    { 28, 113.20999999999999, 2 },
                    { 29, 178.21000000000001, 2 },
                    { 30, 172.91, 2 },
                    { 31, 89.209999999999994, 1 },
                    { 32, 72.909999999999997, 2 },
                    { 33, 17.91, 1 },
                    { 34, 79.120000000000005, 2 },
                    { 35, 68.569999999999993, 1 },
                    { 36, 78.120000000000005, 2 },
                    { 50, 71.670000000000002, 2 },
                    { 37, 56.909999999999997, 1 },
                    { 39, 78.510000000000005, 1 },
                    { 40, 87.209999999999994, 2 },
                    { 41, 83.209999999999994, 1 },
                    { 42, 14.23, 2 },
                    { 43, 98.209999999999994, 1 },
                    { 44, 101.31999999999999, 2 },
                    { 45, 78.319999999999993, 1 },
                    { 46, 80.560000000000002, 2 },
                    { 47, 69.120000000000005, 1 },
                    { 48, 71.450000000000003, 2 },
                    { 26, 69.510000000000005, 2 },
                    { 38, 88.609999999999999, 2 },
                    { 25, 89.560000000000002, 2 },
                    { 23, 231.21000000000001, 2 },
                    { 1, 100.20999999999999, 1 },
                    { 2, 150.21000000000001, 1 },
                    { 3, 111.56, 1 },
                    { 4, 131.50999999999999, 1 },
                    { 5, 95.909999999999997, 1 },
                    { 6, 71.209999999999994, 1 },
                    { 7, 78.560000000000002, 1 },
                    { 8, 222.91, 1 },
                    { 9, 87.510000000000005, 1 },
                    { 10, 90.560000000000002, 1 },
                    { 24, 56.210000000000001, 2 },
                    { 11, 111.91, 1 },
                    { 13, 190.50999999999999, 1 },
                    { 14, 221.91, 1 },
                    { 15, 115.56, 2 },
                    { 16, 78.209999999999994, 2 },
                    { 17, 89.510000000000005, 2 },
                    { 18, 34.560000000000002, 2 },
                    { 19, 120.20999999999999, 2 },
                    { 20, 123.91, 2 },
                    { 21, 167.50999999999999, 2 },
                    { 22, 241.56, 2 },
                    { 12, 135.91, 1 }
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
