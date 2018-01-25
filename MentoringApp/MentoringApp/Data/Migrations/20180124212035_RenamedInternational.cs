using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MentoringApp.Data.Migrations
{
    public partial class RenamedInternational : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsInternationalOrExchange",
                table: "Mentee",
                newName: "IsInternational");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsInternational",
                table: "Mentee",
                newName: "IsInternationalOrExchange");
        }
    }
}
