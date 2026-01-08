using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaVeterinaria.Migrations
{
    /// <inheritdoc />
    public partial class MakeCodiceFiscaleNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnagraficheAnimali_Proprietari_CodiceFiscale",
                table: "AnagraficheAnimali");

            migrationBuilder.AlterColumn<string>(
                name: "CodiceFiscale",
                table: "AnagraficheAnimali",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AddForeignKey(
                name: "FK_AnagraficheAnimali_Proprietari_CodiceFiscale",
                table: "AnagraficheAnimali",
                column: "CodiceFiscale",
                principalTable: "Proprietari",
                principalColumn: "CodiceFiscale");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnagraficheAnimali_Proprietari_CodiceFiscale",
                table: "AnagraficheAnimali");

            migrationBuilder.AlterColumn<string>(
                name: "CodiceFiscale",
                table: "AnagraficheAnimali",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AnagraficheAnimali_Proprietari_CodiceFiscale",
                table: "AnagraficheAnimali",
                column: "CodiceFiscale",
                principalTable: "Proprietari",
                principalColumn: "CodiceFiscale",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
