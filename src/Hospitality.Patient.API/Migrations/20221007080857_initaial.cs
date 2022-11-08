using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospitality.Patient.API.Migrations
{
    public partial class initaial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    HospitalPatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientPesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsInsured = table.Column<bool>(type: "bit", nullable: false),
                    IdOfSelectedDoctor = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.HospitalPatientId);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "HospitalPatientId", "Address", "BirthDate", "Email", "IdOfSelectedDoctor", "IsInsured", "PatientName", "PatientPesel", "PatientSurname", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Wrzosowa", new DateTime(1999, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "aniela.nowak@proton.me", new Guid("00000000-0000-0000-0000-000000000000"), true, "Aniela", "99112234543", "Nowak", "213769420" },
                    { 2, "Jaworowa", new DateTime(1998, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ania.okrasa@proton.me", new Guid("00000000-0000-0000-0000-000000000000"), true, "Ania", "98112234543", "Okrasa", "123456456" },
                    { 3, "Fiołkowa", new DateTime(1997, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "michal.jakos@proton.me", new Guid("00000000-0000-0000-0000-000000000000"), true, "Michał", "97112234543", "Jakos", "456789123" },
                    { 4, "Jaworowa", new DateTime(1998, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "michal.jakos@proton.me", new Guid("00000000-0000-0000-0000-000000000000"), false, "Olaf", "98122255543", "Olal", "999456456" },
                    { 5, "Fiołkowa", new DateTime(1997, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ania.okrasa@proton.me", new Guid("00000000-0000-0000-0000-000000000000"), true, "Dawid", "97102233343", "Jac", "458889123" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
