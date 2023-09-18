using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperVet.Migrations
{
    /// <inheritdoc />
    public partial class M3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Species_BreedsId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_Pets_SpeciesId",
                table: "Species");

            migrationBuilder.RenameColumn(
                name: "SpeciesId",
                table: "Species",
                newName: "PetsId");

            migrationBuilder.RenameIndex(
                name: "IX_Species_SpeciesId",
                table: "Species",
                newName: "IX_Species_PetsId");

            migrationBuilder.RenameColumn(
                name: "BreedsId",
                table: "Breeds",
                newName: "SpeciesId");

            migrationBuilder.RenameIndex(
                name: "IX_Breeds_BreedsId",
                table: "Breeds",
                newName: "IX_Breeds_SpeciesId");

            migrationBuilder.AddColumn<int>(
                name: "BreedsId",
                table: "Species",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeciesId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Species_SpeciesId",
                table: "Breeds",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Pets_PetsId",
                table: "Species",
                column: "PetsId",
                principalTable: "Pets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Species_SpeciesId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_Pets_PetsId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "BreedsId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "SpeciesId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "PetsId",
                table: "Species",
                newName: "SpeciesId");

            migrationBuilder.RenameIndex(
                name: "IX_Species_PetsId",
                table: "Species",
                newName: "IX_Species_SpeciesId");

            migrationBuilder.RenameColumn(
                name: "SpeciesId",
                table: "Breeds",
                newName: "BreedsId");

            migrationBuilder.RenameIndex(
                name: "IX_Breeds_SpeciesId",
                table: "Breeds",
                newName: "IX_Breeds_BreedsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Species_BreedsId",
                table: "Breeds",
                column: "BreedsId",
                principalTable: "Species",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Pets_SpeciesId",
                table: "Species",
                column: "SpeciesId",
                principalTable: "Pets",
                principalColumn: "Id");
        }
    }
}
