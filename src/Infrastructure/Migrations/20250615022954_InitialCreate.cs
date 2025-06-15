using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Astrologers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Astrologers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AstrologerSettings",
                columns: table => new
                {
                    AstrologerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    HouseSystem = table.Column<string>(type: "TEXT", nullable: false),
                    SectionOrderRule = table.Column<string>(type: "TEXT", nullable: false),
                    DeduplicateAspect = table.Column<bool>(type: "INTEGER", nullable: false),
                    DefaultBgImagePath = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AstrologerSettings", x => x.AstrologerId);
                });

            migrationBuilder.CreateTable(
                name: "BirthInfos",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BirthTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    Lat = table.Column<decimal>(type: "TEXT", nullable: false),
                    Lon = table.Column<decimal>(type: "TEXT", nullable: false),
                    TimeZone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthInfos", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "ChartAspects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChartDataId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AspectType = table.Column<string>(type: "TEXT", nullable: false),
                    BodyA = table.Column<string>(type: "TEXT", nullable: false),
                    BodyB = table.Column<string>(type: "TEXT", nullable: false),
                    Orb = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartAspects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChartData",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlanetPositions = table.Column<string>(type: "TEXT", nullable: false),
                    HouseCusps = table.Column<string>(type: "TEXT", nullable: false),
                    CalculatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartData", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "ChartHouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChartDataId = table.Column<Guid>(type: "TEXT", nullable: false),
                    HouseNo = table.Column<int>(type: "INTEGER", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartHouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChartImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChartDataId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    BlobUrl = table.Column<string>(type: "TEXT", nullable: true),
                    WidthPx = table.Column<int>(type: "INTEGER", nullable: false),
                    HeightPx = table.Column<int>(type: "INTEGER", nullable: false),
                    Dpi = table.Column<int>(type: "INTEGER", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AstrologerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interpretations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AstrologerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConditionKey = table.Column<string>(type: "TEXT", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interpretations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReportType = table.Column<string>(type: "TEXT", nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportSections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReportId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SectionKind = table.Column<string>(type: "TEXT", nullable: false),
                    Heading = table.Column<string>(type: "TEXT", nullable: true),
                    ShowHeading = table.Column<bool>(type: "INTEGER", nullable: false),
                    BackgroundImagePath = table.Column<string>(type: "TEXT", nullable: true),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SyncJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AstrologerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    JobType = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ErrorMsg = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncJobs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interpretations_ConditionKey",
                table: "Interpretations",
                column: "ConditionKey");

            migrationBuilder.CreateIndex(
                name: "IX_ReportSections_ReportId_SortOrder",
                table: "ReportSections",
                columns: new[] { "ReportId", "SortOrder" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Astrologers");

            migrationBuilder.DropTable(
                name: "AstrologerSettings");

            migrationBuilder.DropTable(
                name: "BirthInfos");

            migrationBuilder.DropTable(
                name: "ChartAspects");

            migrationBuilder.DropTable(
                name: "ChartData");

            migrationBuilder.DropTable(
                name: "ChartHouses");

            migrationBuilder.DropTable(
                name: "ChartImages");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Interpretations");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "ReportSections");

            migrationBuilder.DropTable(
                name: "SyncJobs");
        }
    }
}
