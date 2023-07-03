using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceCMS_API.Migrations
{
    /// <inheritdoc />
    public partial class UnnecessaryMeasurementSetInAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_MeasurementSets_MeasurementSetId",
                table: "Attributes");

            migrationBuilder.AlterColumn<int>(
                name: "MeasurementSetId",
                table: "Attributes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_MeasurementSets_MeasurementSetId",
                table: "Attributes",
                column: "MeasurementSetId",
                principalTable: "MeasurementSets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_MeasurementSets_MeasurementSetId",
                table: "Attributes");

            migrationBuilder.AlterColumn<int>(
                name: "MeasurementSetId",
                table: "Attributes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_MeasurementSets_MeasurementSetId",
                table: "Attributes",
                column: "MeasurementSetId",
                principalTable: "MeasurementSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
