using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Landmark = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.DestinationId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "DestinationId", "City", "Country", "Landmark" },
                values: new object[] { 1, "Portland, Oregon", "United State", "Portland Sign" });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "DestinationId", "City", "Country", "Landmark" },
                values: new object[] { 2, "Burlington, Vermont", "United State", "Lake Champlain" });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "DestinationId", "City", "Country", "Landmark" },
                values: new object[] { 3, "Big Sur, California", "United State", "Big Sur" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "DestinationId", "Rating", "Remarks" },
                values: new object[,]
                {
                    { 1, 1, 6, "It rains too much." },
                    { 2, 2, 10, "The trees are beautiful in the fall!" },
                    { 3, 3, 9, "I've never seen a better sunset." },
                    { 4, 1, 8, "Some amazing food in this city!" },
                    { 5, 1, 7, "The people don't understand sarcasm." },
                    { 6, 2, 9, "I'd raise a family here." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_DestinationId",
                table: "Reviews",
                column: "DestinationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Destinations");
        }
    }
}
