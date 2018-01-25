using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MentoringApp.Data.Migrations
{
    public partial class SlimmedMentees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allergies",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "ArriveInCanada",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "ConnectWithPeersPriority",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "ConnectWithUpperYearsPriority",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "DietaryRequirements",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "GainProgramInfoPriority",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "InternationalStudentOrientation",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "IsWoman",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "LearnCampusServicesPriority",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "LearnExpectationsPriority",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "MtpsOrientation",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "NaspProgram",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "NaspRegisterDate",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "WillAttendIgnite",
                table: "Mentee");

            migrationBuilder.RenameColumn(
                name: "PrevInstitution",
                table: "Mentee",
                newName: "IsExchange");

            migrationBuilder.AlterColumn<string>(
                name: "IsTransfer",
                table: "Mentee",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IsPathways",
                table: "Mentee",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IsMature",
                table: "Mentee",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IsIndigenous",
                table: "Mentee",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IsGrad",
                table: "Mentee",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IsFirstGen",
                table: "Mentee",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CanContact",
                table: "Mentee",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsExchange",
                table: "Mentee",
                newName: "PrevInstitution");

            migrationBuilder.AlterColumn<bool>(
                name: "IsTransfer",
                table: "Mentee",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPathways",
                table: "Mentee",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsMature",
                table: "Mentee",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsIndigenous",
                table: "Mentee",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsGrad",
                table: "Mentee",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsFirstGen",
                table: "Mentee",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CanContact",
                table: "Mentee",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Allergies",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ArriveInCanada",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConnectWithPeersPriority",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConnectWithUpperYearsPriority",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DietaryRequirements",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GainProgramInfoPriority",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InternationalStudentOrientation",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsWoman",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LearnCampusServicesPriority",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LearnExpectationsPriority",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MtpsOrientation",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NaspProgram",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NaspRegisterDate",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WillAttendIgnite",
                table: "Mentee",
                nullable: true);
        }
    }
}
