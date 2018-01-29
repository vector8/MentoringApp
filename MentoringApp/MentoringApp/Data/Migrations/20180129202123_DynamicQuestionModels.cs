using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MentoringApp.Data.Migrations
{
    public partial class DynamicQuestionModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Mentor");

            migrationBuilder.DropColumn(
                name: "AppreciatesNature",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "CanContact",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "CountryOfOrigin",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "DoesWhatTheyWant",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "EnjoysDiscovering",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "GenderIdentity",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "HandlesStressWell",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "HelpsOthers",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "IsAthletic",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "IsCheerful",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "IsExchange",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "IsFirstGen",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "IsGrad",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "IsIndigenous",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "IsInternational",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "IsMature",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "IsPathways",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "IsTransfer",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "KeepsRoomTidy",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "Languages",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "LivesInHarmony",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "MeetOtherStudents21",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "MeetOtherStudentsClasses",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "MeetOtherStudentsClubs",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "MeetOtherStudentsCommute",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "MeetOtherStudentsFirstGen",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "MeetOtherStudentsInFaculty",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "MeetOtherStudentsIndigenous",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "MeetOtherStudentsInt",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "MeetOtherStudentsOffCampus",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "MeetOtherStudentsOnCampus",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "MeetOtherStudentsTransfer",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "MeetsResponsibilities",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "NeedsQuietTime",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "QuickToTrust",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "RacialIdentity",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "RespectsTraditions",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "SexualOrientation",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "Thoughtful",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "UnderstandScienceMath",
                table: "Mentee");

            migrationBuilder.DropColumn(
                name: "WorksHard",
                table: "Mentee");

            migrationBuilder.AddColumn<string>(
                name: "StudentNumber",
                table: "Mentor",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentNumber",
                table: "Mentor");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Mentor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppreciatesNature",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanContact",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryOfOrigin",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoesWhatTheyWant",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnjoysDiscovering",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenderIdentity",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HandlesStressWell",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HelpsOthers",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsAthletic",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsCheerful",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsExchange",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsFirstGen",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsGrad",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsIndigenous",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsInternational",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsMature",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsPathways",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsReserved",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsTransfer",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeepsRoomTidy",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Languages",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LivesInHarmony",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetOtherStudents21",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetOtherStudentsClasses",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetOtherStudentsClubs",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetOtherStudentsCommute",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetOtherStudentsFirstGen",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetOtherStudentsInFaculty",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetOtherStudentsIndigenous",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetOtherStudentsInt",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetOtherStudentsOffCampus",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetOtherStudentsOnCampus",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetOtherStudentsTransfer",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetsResponsibilities",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NeedsQuietTime",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuickToTrust",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RacialIdentity",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RespectsTraditions",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SexualOrientation",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thoughtful",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnderstandScienceMath",
                table: "Mentee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorksHard",
                table: "Mentee",
                nullable: true);
        }
    }
}
