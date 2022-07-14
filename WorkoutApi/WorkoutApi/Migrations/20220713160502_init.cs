using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MusclesGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusclesGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberSets = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeRelax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberRepetitions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeDifficulty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusclesGroupOfWorkouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMusclesGroup = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdWorkout = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusclesGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusclesGroupOfWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusclesGroupOfWorkouts_MusclesGroups_MusclesGroupId",
                        column: x => x.MusclesGroupId,
                        principalTable: "MusclesGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusclesGroupOfWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusclesGroupOfWorkouts_MusclesGroupId",
                table: "MusclesGroupOfWorkouts",
                column: "MusclesGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MusclesGroupOfWorkouts_WorkoutId",
                table: "MusclesGroupOfWorkouts",
                column: "WorkoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusclesGroupOfWorkouts");

            migrationBuilder.DropTable(
                name: "MusclesGroups");

            migrationBuilder.DropTable(
                name: "Workouts");
        }
    }
}
