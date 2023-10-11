using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperVet.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PetsId",
                table: "Breed",
                newName: "PetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PetId",
                table: "Breed",
                newName: "PetsId");
        }
    }
}
