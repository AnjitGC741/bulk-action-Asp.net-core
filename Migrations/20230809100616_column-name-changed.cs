using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bulkAction.Migrations
{
    /// <inheritdoc />
    public partial class columnnamechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isSelected",
                table: "products",
                newName: "isChecked");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isChecked",
                table: "products",
                newName: "isSelected");
        }
    }
}
