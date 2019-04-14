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
                    { 1, "48cf8164-fc1e-4e64-97e5-fb40ddff2f90", "Role", "User", "user" },
                    { 2, "48cf8164-fc1e-4e64-97e5-fb40ddff2f90", "Role", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 5, 0, "f426c221-2b33-4ffc-b34f-2ad20febc8db", "frano.nola@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEMdocCWb/yQotrSReZahyi+Ca2+EacOVeBlaw+26KFJ9q5Oj8CBUbDvAGNiwp1j+bg==", null, false, "48cf8164-fc1e-4e64-97e5-fb40ddff2f90", false, "frano.nola" },
                    { 6, 0, "3ca4aebc-f69a-4332-98e4-bb726c985609", "user@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEKJE+6iTCpd6BhDfzkaI/g9TTapCCergqVR3kedC9VT7BwY+HCM+Vgyr4Nccv1z4ww==", null, false, "48cf8164-fc1e-4e64-97e5-fb40ddff2f90", false, "user" },
                    { 4, 0, "b9939038-9b90-48f5-874d-d0c76b5bb3ef", "stipe.brzi@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEApbO4kuUjJMu79fzcwpVqz83NrdhhRzNcYXOfrYNW7Rh8UDWCie0zg9x6pDypAebA==", null, false, "48cf8164-fc1e-4e64-97e5-fb40ddff2f90", false, "stipe.brzi" },
                    { 1, 0, "a02b162f-dc26-4d68-8672-a3855070d5d5", "tomokulusic@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEMbsbx3BM32lMYNS5ej331Ykukfv33YzJ0iemze+Tk/XLOzze8WFxGN/Y/HS6PXwmA==", null, false, "48cf8164-fc1e-4e64-97e5-fb40ddff2f90", false, "tomokulusic" },
                    { 2, 0, "d1984356-6a41-4c2e-9aa8-c6d294b0f26e", "petar.kleskovic@enum.hr", false, false, null, null, null, "AQAAAAEAACcQAAAAENUS5LxErbzSJ35NJQkWV6r5reW8XTjgiayM8h7Vfo4/xydNQs6MDB9cFs9WsO6dFA==", null, false, "48cf8164-fc1e-4e64-97e5-fb40ddff2f90", false, "petar.kleskovic" },
                    { 3, 0, "3fa80a05-ad5d-48c0-a4b8-aeaa309d4cc8", "kxl9597@g.rit.edu", false, false, null, null, null, "AQAAAAEAACcQAAAAEMKG7K4Xy4ex7SC/E6OMeNY8d7AbW7aYdnTvB7s5yNzDcGjEbJaZn1AVnNY+spR0tg==", null, false, "48cf8164-fc1e-4e64-97e5-fb40ddff2f90", false, "kxl9597" }
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
                columns: new[] { "Id", "Amount", "Date", "ElectricityId", "SmartHouseCityRegion", "UserId", "UtilityType", "WaterId" },
                values: new object[,]
                {
                    { 53, 60.810000000000002, new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 0, 1, 23 },
                    { 58, 67.909999999999997, new DateTime(2019, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0, 1, 28 },
                    { 57, 56.780000000000001, new DateTime(2019, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0, 1, 27 },
                    { 56, 111.20999999999999, new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 0, 1, 26 },
                    { 31, 78.909999999999997, new DateTime(2019, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 0, 1, 1 },
                    { 32, 121.91, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 0, 1, 2 },
                    { 33, 111.20999999999999, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 0, 1, 3 },
                    { 34, 51.210000000000001, new DateTime(2019, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 0, 1, 4 },
                    { 35, 151.99000000000001, new DateTime(2019, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 0, 1, 5 },
                    { 36, 56.780000000000001, new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 0, 1, 6 },
                    { 37, 41.899999999999999, new DateTime(2019, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 0, 1, 7 },
                    { 38, 78.909999999999997, new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 0, 1, 8 },
                    { 39, 67.909999999999997, new DateTime(2019, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 0, 1, 9 },
                    { 40, 60.810000000000002, new DateTime(2019, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0, 1, 10 },
                    { 41, 111.20999999999999, new DateTime(2019, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0, 1, 11 },
                    { 42, 87.219999999999999, new DateTime(2019, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0, 1, 12 },
                    { 55, 67.909999999999997, new DateTime(2019, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 0, 1, 25 },
                    { 44, 41.890000000000001, new DateTime(2019, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 0, 1, 14 },
                    { 45, 67.909999999999997, new DateTime(2019, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 0, 1, 15 },
                    { 46, 111.20999999999999, new DateTime(2019, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 0, 1, 16 },
                    { 47, 56.780000000000001, new DateTime(2019, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 0, 1, 17 },
                    { 48, 41.899999999999999, new DateTime(2019, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 0, 1, 18 },
                    { 49, 78.909999999999997, new DateTime(2019, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 0, 1, 19 },
                    { 50, 67.909999999999997, new DateTime(2019, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 0, 1, 20 },
                    { 51, 41.890000000000001, new DateTime(2019, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 0, 1, 21 },
                    { 52, 56.780000000000001, new DateTime(2019, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 0, 1, 22 },
                    { 54, 78.909999999999997, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 0, 1, 24 },
                    { 43, 78.909999999999997, new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 0, 1, 13 },
                    { 1, 53.210000000000001, new DateTime(2019, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 0, 2, null },
                    { 30, 41.890000000000001, new DateTime(2019, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 4, 0, 2, null },
                    { 2, 43.210000000000001, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 0, 2, null },
                    { 3, 65.109999999999999, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 0, 2, null },
                    { 4, 112.20999999999999, new DateTime(2019, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 8, 0, 2, null },
                    { 5, 156.91, new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 8, 0, 2, null },
                    { 6, 157.11000000000001, new DateTime(2019, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 8, 0, 2, null },
                    { 7, 87.909999999999997, new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 6, 0, 2, null },
                    { 8, 56.509999999999998, new DateTime(2019, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 6, 0, 2, null },
                    { 9, 51.210000000000001, new DateTime(2019, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 6, 0, 2, null },
                    { 10, 78.900000000000006, new DateTime(2019, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 3, 0, 2, null },
                    { 11, 11.210000000000001, new DateTime(2019, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 3, 0, 2, null },
                    { 12, 56.880000000000003, new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 3, 0, 2, null },
                    { 13, 51.560000000000002, new DateTime(2019, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 2, 0, 2, null },
                    { 14, 78.909999999999997, new DateTime(2019, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 2, 0, 2, null },
                    { 59, 111.20999999999999, new DateTime(2019, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0, 1, 29 },
                    { 15, 111.20999999999999, new DateTime(2019, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2, 0, 2, null },
                    { 17, 67.909999999999997, new DateTime(2019, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 7, 0, 2, null },
                    { 18, 41.890000000000001, new DateTime(2019, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 7, 0, 2, null },
                    { 19, 60.810000000000002, new DateTime(2019, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 5, 0, 2, null },
                    { 20, 111.20999999999999, new DateTime(2019, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 5, 0, 2, null },
                    { 21, 41.899999999999999, new DateTime(2019, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 5, 0, 2, null },
                    { 22, 78.909999999999997, new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 5, 0, 2, null },
                    { 23, 56.780000000000001, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 5, 0, 2, null },
                    { 24, 67.909999999999997, new DateTime(2019, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, 0, 2, null },
                    { 25, 151.99000000000001, new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 4, 0, 2, null },
                    { 26, 111.20999999999999, new DateTime(2019, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 4, 0, 2, null },
                    { 27, 56.780000000000001, new DateTime(2019, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 4, 0, 2, null },
                    { 28, 51.210000000000001, new DateTime(2019, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 4, 0, 2, null },
                    { 29, 67.909999999999997, new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 4, 0, 2, null },
                    { 16, 56.780000000000001, new DateTime(2019, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 7, 0, 2, null },
                    { 60, 111.20999999999999, new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0, 1, 30 }
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
