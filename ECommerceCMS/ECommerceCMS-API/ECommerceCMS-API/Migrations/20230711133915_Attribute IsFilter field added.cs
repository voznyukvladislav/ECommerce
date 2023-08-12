using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceCMS_API.Migrations
{
    /// <inheritdoc />
    public partial class AttributeIsFilterfieldadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFilter",
                table: "Attributes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFilter",
                table: "Attributes");
        }
    }
}
