using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospitality.Examination.Persistance.Migrations
{
    public partial class initaial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExaminationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Duration = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Examinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExaminationTypeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examinations_ExaminationTypes_ExaminationTypeId",
                        column: x => x.ExaminationTypeId,
                        principalTable: "ExaminationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExaminationTypes",
                columns: new[] { "Id", "Duration", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 80000000L, "Biochemia krwi", 1234.99 },
                    { 2, 100000000L, "USG serca", 1001.99 },
                    { 3, 70000000L, "RTG głowy", 900.99000000000001 },
                    { 4, 60000000L, "RTG celowane na ząb obrotnika", 1234.99 },
                    { 5, 60000000L, "RTG styczne czaszki", 500.0 },
                    { 6, 60000000L, "Leczenie kanałowe zębów", 550.0 },
                    { 7, 80000000L, "Badanie kału na pasożyty", 900.0 },
                    { 8, 100000000L, "Cytologia płynna", 700.0 },
                    { 9, 70000000L, "Kolonoskopia", 2500.0 },
                    { 10, 60000000L, "Gastroskopia", 1500.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_ExaminationTypeId",
                table: "Examinations",
                column: "ExaminationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropTable(
                name: "ExaminationTypes");
        }
    }
}
