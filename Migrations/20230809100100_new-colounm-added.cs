﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bulkAction.Migrations
{
    /// <inheritdoc />
    public partial class newcolounmadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isSelected",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSelected",
                table: "products");
        }
    }
}
