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
                    UtilityType = table.Column<int>(nullable: false)
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
                    { 30, 172.91, 3 },
                    { 29, 178.21000000000001, 3 },
                    { 28, 113.20999999999999, 3 },
                    { 27, 141.56, 3 },
                    { 26, 69.510000000000005, 3 },
                    { 25, 89.560000000000002, 3 },
                    { 24, 56.210000000000001, 3 },
                    { 23, 231.21000000000001, 3 },
                    { 22, 241.56, 3 },
                    { 21, 167.50999999999999, 3 },
                    { 19, 120.20999999999999, 2 },
                    { 18, 34.560000000000002, 2 },
                    { 17, 89.510000000000005, 2 },
                    { 16, 78.209999999999994, 2 },
                    { 20, 123.91, 3 },
                    { 14, 221.91, 2 },
                    { 2, 150.21000000000001, 1 },
                    { 3, 111.56, 1 },
                    { 15, 115.56, 2 },
                    { 5, 95.909999999999997, 1 },
                    { 6, 71.209999999999994, 1 },
                    { 7, 78.560000000000002, 1 },
                    { 4, 131.50999999999999, 1 },
                    { 9, 87.510000000000005, 1 },
                    { 10, 90.560000000000002, 1 },
                    { 11, 111.91, 2 },
                    { 12, 135.91, 2 },
                    { 13, 190.50999999999999, 2 },
                    { 8, 222.91, 1 }
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
                    { 1, "2b25ff3c-5566-4957-819d-d6babd8fdebc", "Role", "User", "user" },
                    { 2, "2b25ff3c-5566-4957-819d-d6babd8fdebc", "Role", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 5, 0, "e81dccb7-afaa-40f0-8d4a-09e184107b4a", "frano.nola@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEMRWuApGfXhZ4yRdaV/7et4ehUB4vwUINS8tTUCYR7PYJP9FFLBMGo2hsD1l0InYaw==", null, false, "2b25ff3c-5566-4957-819d-d6babd8fdebc", false, null },
                    { 6, 0, "7fc618c7-ea02-4df7-9ff3-9b1907632a67", "user@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEF2cCQ0+9YI1CZsVfCH+QIP2rmvYWK5yeASRaa+qiYxNRrR4ASgMNERQ9r2BClRw2g==", null, false, "2b25ff3c-5566-4957-819d-d6babd8fdebc", false, null },
                    { 4, 0, "0b73c692-5c7c-4442-8c69-124f937384ce", "stipe.brzi@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEJQ8sz4UTte/1rAHGPrbLRBTrvcxPkCGU8zcyk1/H/O164R3FYceIg+th7z0nuApfg==", null, false, "2b25ff3c-5566-4957-819d-d6babd8fdebc", false, null },
                    { 1, 0, "0c43230a-96de-4eae-a6a0-385dc98543a8", "tomokulusic@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEAkdXLhM7X01Z3xSKUwgWjMn4pynb63xcT/zH+vNXyrCOyoScZbn0cTGIDgE+pZ+TA==", null, false, "2b25ff3c-5566-4957-819d-d6babd8fdebc", false, null },
                    { 2, 0, "50f1ebea-6136-4ac1-a633-b6a75f463a25", "petar.kleskovic@enum.hr", false, false, null, null, null, "AQAAAAEAACcQAAAAELZKVPAYqkFfP8rmJWtjldNSV+iw92JPqdl1AnuqAmq03D8WhahfVRHc6ebQbL2m2g==", null, false, "2b25ff3c-5566-4957-819d-d6babd8fdebc", false, null },
                    { 3, 0, "cf3d6459-0c11-4d05-ba01-67c465146469", "kxl9597@g.rit.edu", false, false, null, null, null, "AQAAAAEAACcQAAAAEN6HDL9wjKl5YxDGLAU2K0iIgPhlNRr/oltOSklg9FiyJLyatuWH//8p+XubQUpnKg==", null, false, "2b25ff3c-5566-4957-819d-d6babd8fdebc", false, null }
                });

            migrationBuilder.InsertData(
                table: "Water",
                columns: new[] { "Id", "Amount", "TarriffId" },
                values: new object[,]
                {
                    { 29, 178.21000000000001, 2 },
                    { 28, 113.20999999999999, 2 },
                    { 27, 141.56, 2 },
                    { 26, 69.510000000000005, 2 },
                    { 25, 89.560000000000002, 2 },
                    { 24, 56.210000000000001, 2 },
                    { 16, 78.209999999999994, 2 },
                    { 22, 241.56, 2 },
                    { 21, 167.50999999999999, 2 },
                    { 20, 123.91, 2 },
                    { 19, 120.20999999999999, 2 },
                    { 18, 34.560000000000002, 2 },
                    { 17, 89.510000000000005, 2 },
                    { 30, 172.91, 2 },
                    { 23, 231.21000000000001, 2 },
                    { 15, 115.56, 2 },
                    { 13, 190.50999999999999, 1 },
                    { 12, 135.91, 1 },
                    { 11, 111.91, 1 },
                    { 10, 90.560000000000002, 1 },
                    { 9, 87.510000000000005, 1 },
                    { 8, 222.91, 1 },
                    { 7, 78.560000000000002, 1 },
                    { 6, 71.209999999999994, 1 },
                    { 5, 95.909999999999997, 1 },
                    { 4, 131.50999999999999, 1 },
                    { 3, 111.56, 1 },
                    { 2, 150.21000000000001, 1 },
                    { 1, 100.20999999999999, 1 },
                    { 14, 221.91, 1 }
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
                columns: new[] { "Id", "Amount", "Date", "ElectricityId", "UtilityType", "WaterId" },
                values: new object[,]
                {
                    { 53, 60.810000000000002, new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 23 },
                    { 58, 67.909999999999997, new DateTime(2019, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 28 },
                    { 57, 56.780000000000001, new DateTime(2019, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 27 },
                    { 56, 111.20999999999999, new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 26 },
                    { 31, 78.909999999999997, new DateTime(2019, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1 },
                    { 32, 121.91, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2 },
                    { 33, 111.20999999999999, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3 },
                    { 34, 51.210000000000001, new DateTime(2019, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 4 },
                    { 35, 151.99000000000001, new DateTime(2019, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 5 },
                    { 36, 56.780000000000001, new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 6 },
                    { 37, 41.899999999999999, new DateTime(2019, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 7 },
                    { 38, 78.909999999999997, new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 8 },
                    { 39, 67.909999999999997, new DateTime(2019, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 9 },
                    { 40, 60.810000000000002, new DateTime(2019, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 10 },
                    { 41, 111.20999999999999, new DateTime(2019, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 11 },
                    { 42, 87.219999999999999, new DateTime(2019, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 12 },
                    { 55, 67.909999999999997, new DateTime(2019, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 25 },
                    { 44, 41.890000000000001, new DateTime(2019, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 14 },
                    { 45, 67.909999999999997, new DateTime(2019, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 15 },
                    { 46, 111.20999999999999, new DateTime(2019, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 16 },
                    { 47, 56.780000000000001, new DateTime(2019, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 17 },
                    { 48, 41.899999999999999, new DateTime(2019, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 18 },
                    { 49, 78.909999999999997, new DateTime(2019, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 19 },
                    { 50, 67.909999999999997, new DateTime(2019, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 20 },
                    { 51, 41.890000000000001, new DateTime(2019, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 21 },
                    { 52, 56.780000000000001, new DateTime(2019, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 22 },
                    { 54, 78.909999999999997, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 24 },
                    { 43, 78.909999999999997, new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 13 },
                    { 1, 53.210000000000001, new DateTime(2019, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, null },
                    { 30, 41.890000000000001, new DateTime(2019, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 2, null },
                    { 2, 43.210000000000001, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, null },
                    { 3, 65.109999999999999, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, null },
                    { 4, 112.20999999999999, new DateTime(2019, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, null },
                    { 5, 156.91, new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, null },
                    { 6, 157.11000000000001, new DateTime(2019, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, null },
                    { 7, 87.909999999999997, new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 2, null },
                    { 8, 56.509999999999998, new DateTime(2019, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 2, null },
                    { 9, 51.210000000000001, new DateTime(2019, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, null },
                    { 10, 78.900000000000006, new DateTime(2019, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2, null },
                    { 11, 11.210000000000001, new DateTime(2019, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 2, null },
                    { 12, 56.880000000000003, new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 2, null },
                    { 13, 51.560000000000002, new DateTime(2019, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 2, null },
                    { 14, 78.909999999999997, new DateTime(2019, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 2, null },
                    { 59, 111.20999999999999, new DateTime(2019, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 29 },
                    { 15, 111.20999999999999, new DateTime(2019, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2, null },
                    { 17, 67.909999999999997, new DateTime(2019, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 2, null },
                    { 18, 41.890000000000001, new DateTime(2019, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 2, null },
                    { 19, 60.810000000000002, new DateTime(2019, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 2, null },
                    { 20, 111.20999999999999, new DateTime(2019, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 2, null },
                    { 21, 41.899999999999999, new DateTime(2019, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 2, null },
                    { 22, 78.909999999999997, new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 2, null },
                    { 23, 56.780000000000001, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 2, null },
                    { 24, 67.909999999999997, new DateTime(2019, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 2, null },
                    { 25, 151.99000000000001, new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 2, null },
                    { 26, 111.20999999999999, new DateTime(2019, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 2, null },
                    { 27, 56.780000000000001, new DateTime(2019, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 2, null },
                    { 28, 51.210000000000001, new DateTime(2019, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 2, null },
                    { 29, 67.909999999999997, new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 2, null },
                    { 16, 56.780000000000001, new DateTime(2019, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 2, null },
                    { 60, 111.20999999999999, new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 30 }
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
