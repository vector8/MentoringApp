using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MentoringApp.Data.Migrations
{
    public partial class StudentMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Student_MentorID",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_MentorID",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "MentorID",
                table: "Match");

            migrationBuilder.AddColumn<int>(
                name: "MatchID",
                table: "Student",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_MatchID",
                table: "Student",
                column: "MatchID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Match_MatchID",
                table: "Student",
                column: "MatchID",
                principalTable: "Match",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Match_MatchID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_MatchID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "MatchID",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "MentorID",
                table: "Match",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Match_MentorID",
                table: "Match",
                column: "MentorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Student_MentorID",
                table: "Match",
                column: "MentorID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
