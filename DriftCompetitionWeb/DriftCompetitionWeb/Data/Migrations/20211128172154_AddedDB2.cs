using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DriftCompetitionWeb.Data.Migrations
{
    public partial class AddedDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarID);
                    table.ForeignKey(
                        name: "FK_Cars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    CompetitionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Requirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrizePool = table.Column<float>(type: "real", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StagesNumber = table.Column<int>(type: "int", nullable: false),
                    IsOver = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.CompetitionID);
                });

            migrationBuilder.CreateTable(
                name: "DriftCompetitionRoles",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriftCompetitionRoles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "CarNumbers",
                columns: table => new
                {
                    CarNumberID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarNumbers", x => x.CarNumberID);
                    table.ForeignKey(
                        name: "FK_CarNumbers_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionResults",
                columns: table => new
                {
                    CompetitionResultID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompetitionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NumberOfCompletedStages = table.Column<int>(type: "int", nullable: false),
                    ResultGrade = table.Column<float>(type: "real", nullable: false),
                    ResultPlace = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionResults", x => x.CompetitionResultID);
                    table.ForeignKey(
                        name: "FK_CompetitionResults_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompetitionResults_Competitions_CompetitionID",
                        column: x => x.CompetitionID,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    StageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompetitionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegistrationStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOver = table.Column<bool>(type: "bit", nullable: false),
                    ViewPrice = table.Column<float>(type: "real", nullable: false),
                    ParticipationPrice = table.Column<float>(type: "real", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.StageID);
                    table.ForeignKey(
                        name: "FK_Stages_Competitions_CompetitionID",
                        column: x => x.CompetitionID,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    RaceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StageID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IndexInOlympicSystemp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.RaceID);
                    table.ForeignKey(
                        name: "FK_Races_Stages_StageID",
                        column: x => x.StageID,
                        principalTable: "Stages",
                        principalColumn: "StageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StageResults",
                columns: table => new
                {
                    StageResultID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StageID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CarNumberID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResultPlace = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageResults", x => x.StageResultID);
                    table.ForeignKey(
                        name: "FK_StageResults_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StageResults_CarNumbers_CarNumberID",
                        column: x => x.CarNumberID,
                        principalTable: "CarNumbers",
                        principalColumn: "CarNumberID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StageResults_Stages_StageID",
                        column: x => x.StageID,
                        principalTable: "Stages",
                        principalColumn: "StageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersToRoles",
                columns: table => new
                {
                    UserToRoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StageID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersToRoles", x => x.UserToRoleID);
                    table.ForeignKey(
                        name: "FK_UsersToRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersToRoles_DriftCompetitionRoles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "DriftCompetitionRoles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersToRoles_Stages_StageID",
                        column: x => x.StageID,
                        principalTable: "Stages",
                        principalColumn: "StageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RaceResults",
                columns: table => new
                {
                    RaceResultID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RaceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CarNumberID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuccessfullyEnded = table.Column<bool>(type: "bit", nullable: false),
                    AngleGrade = table.Column<float>(type: "real", nullable: false),
                    StyleGrade = table.Column<float>(type: "real", nullable: false),
                    TrajectoryGrade = table.Column<float>(type: "real", nullable: false),
                    ResultPlace = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceResults", x => x.RaceResultID);
                    table.ForeignKey(
                        name: "FK_RaceResults_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaceResults_CarNumbers_CarNumberID",
                        column: x => x.CarNumberID,
                        principalTable: "CarNumbers",
                        principalColumn: "CarNumberID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaceResults_Races_RaceID",
                        column: x => x.RaceID,
                        principalTable: "Races",
                        principalColumn: "RaceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarNumbers_CarID",
                table: "CarNumbers",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionResults_CompetitionID",
                table: "CompetitionResults",
                column: "CompetitionID");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionResults_UserId",
                table: "CompetitionResults",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_CarNumberID",
                table: "RaceResults",
                column: "CarNumberID");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_RaceID",
                table: "RaceResults",
                column: "RaceID");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_UserId",
                table: "RaceResults",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_StageID",
                table: "Races",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_StageResults_CarNumberID",
                table: "StageResults",
                column: "CarNumberID");

            migrationBuilder.CreateIndex(
                name: "IX_StageResults_StageID",
                table: "StageResults",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_StageResults_UserId",
                table: "StageResults",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_CompetitionID",
                table: "Stages",
                column: "CompetitionID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersToRoles_RoleID",
                table: "UsersToRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersToRoles_StageID",
                table: "UsersToRoles",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersToRoles_UserId",
                table: "UsersToRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionResults");

            migrationBuilder.DropTable(
                name: "RaceResults");

            migrationBuilder.DropTable(
                name: "StageResults");

            migrationBuilder.DropTable(
                name: "UsersToRoles");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "CarNumbers");

            migrationBuilder.DropTable(
                name: "DriftCompetitionRoles");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "AspNetUsers");
        }
    }
}
