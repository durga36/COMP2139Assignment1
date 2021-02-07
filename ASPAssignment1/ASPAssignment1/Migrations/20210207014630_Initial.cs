using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPAssignment1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Tournament Master" },
                    { 2, "League Scheduler" },
                    { 3, "League Scheduler Deluxe" },
                    { 4, "Draft Manager" },
                    { 5, "Team Manager" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Code", "Name", "Price", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, 1, "TRNY10", "Tournament Master 1.0", "$4.99", "12/1/2015" },
                    { 6, 1, "TRNY20", "Tournament Master 2.0", "$5.99", "2/15/2018" },
                    { 2, 2, "LEAG10", "League Scheduler 1.0", "$4.99", "5/1/2016" },
                    { 3, 3, "LEAGD10", "League Scheduler Deluxe 1.0", "$7.99", "8/1/2016" },
                    { 4, 4, "DRAFT10", "Draft Manager 1.0", "$4.99", "2/1/2017" },
                    { 7, 4, "DRAFT20", "Draft Manager 2.0", "$5.99", "7/15/2019" },
                    { 5, 5, "TEAM10", "Team Manager 1.0", "$4.99", "5/1/2017" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
