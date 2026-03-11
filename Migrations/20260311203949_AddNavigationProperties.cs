using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationStelovanjeBaze.Migrations
{
    /// <inheritdoc />
    public partial class AddNavigationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UpisNaPredmet_PredmetId",
                table: "UpisNaPredmet",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_UpisNaPredmet_StudentId",
                table: "UpisNaPredmet",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UpisNaPredmet_Predmet_PredmetId",
                table: "UpisNaPredmet",
                column: "PredmetId",
                principalTable: "Predmet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UpisNaPredmet_Student_StudentId",
                table: "UpisNaPredmet",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "BrojIndeksa",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpisNaPredmet_Predmet_PredmetId",
                table: "UpisNaPredmet");

            migrationBuilder.DropForeignKey(
                name: "FK_UpisNaPredmet_Student_StudentId",
                table: "UpisNaPredmet");

            migrationBuilder.DropIndex(
                name: "IX_UpisNaPredmet_PredmetId",
                table: "UpisNaPredmet");

            migrationBuilder.DropIndex(
                name: "IX_UpisNaPredmet_StudentId",
                table: "UpisNaPredmet");
        }
    }
}
