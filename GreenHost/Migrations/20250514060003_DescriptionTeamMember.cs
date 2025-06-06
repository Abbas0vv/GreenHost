﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenHost.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionTeamMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TeamMembers");
        }
    }
}
