using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutApi.Migrations
{
    public partial class updateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusclesGroupOfWorkouts");

            migrationBuilder.DropColumn(
                name: "DegreeDifficulty",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "NumberRepetitions",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "NumberSets",
                table: "Workouts");

            migrationBuilder.RenameColumn(
                name: "TimeRelax",
                table: "Workouts",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MusclesGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountSets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeOfRelax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfRepetitions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Imges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vidios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vidios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DifficultyLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExercisId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DifficultyLevels_Exercises_ExercisId",
                        column: x => x.ExercisId,
                        principalTable: "Exercises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExercisOfMusclesGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMusclesGroup = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdExercis = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusclesGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExercisId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisOfMusclesGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExercisOfMusclesGroups_Exercises_ExercisId",
                        column: x => x.ExercisId,
                        principalTable: "Exercises",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExercisOfMusclesGroups_MusclesGroups_MusclesGroupId",
                        column: x => x.MusclesGroupId,
                        principalTable: "MusclesGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkoutOfExercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExercisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutOfExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutOfExercises_Exercises_ExercisId",
                        column: x => x.ExercisId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutOfExercises_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExercisOfImges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExercisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImgId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisOfImges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExercisOfImges_Exercises_ExercisId",
                        column: x => x.ExercisId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercisOfImges_Imges_ImgId",
                        column: x => x.ImgId,
                        principalTable: "Imges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExercisOfVidios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExercisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VidioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisOfVidios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExercisOfVidios_Exercises_ExercisId",
                        column: x => x.ExercisId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercisOfVidios_Vidios_VidioId",
                        column: x => x.VidioId,
                        principalTable: "Vidios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExercisOfDifficultyLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDifficultyLevel = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdExercis = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DifficultyLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExercisId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisOfDifficultyLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExercisOfDifficultyLevels_DifficultyLevels_DifficultyLevelId",
                        column: x => x.DifficultyLevelId,
                        principalTable: "DifficultyLevels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExercisOfDifficultyLevels_Exercises_ExercisId",
                        column: x => x.ExercisId,
                        principalTable: "Exercises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyLevels_ExercisId",
                table: "DifficultyLevels",
                column: "ExercisId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisOfDifficultyLevels_DifficultyLevelId",
                table: "ExercisOfDifficultyLevels",
                column: "DifficultyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisOfDifficultyLevels_ExercisId",
                table: "ExercisOfDifficultyLevels",
                column: "ExercisId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisOfImges_ExercisId",
                table: "ExercisOfImges",
                column: "ExercisId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisOfImges_ImgId",
                table: "ExercisOfImges",
                column: "ImgId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisOfMusclesGroups_ExercisId",
                table: "ExercisOfMusclesGroups",
                column: "ExercisId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisOfMusclesGroups_MusclesGroupId",
                table: "ExercisOfMusclesGroups",
                column: "MusclesGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisOfVidios_ExercisId",
                table: "ExercisOfVidios",
                column: "ExercisId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisOfVidios_VidioId",
                table: "ExercisOfVidios",
                column: "VidioId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutOfExercises_ExercisId",
                table: "WorkoutOfExercises",
                column: "ExercisId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutOfExercises_WorkoutId",
                table: "WorkoutOfExercises",
                column: "WorkoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExercisOfDifficultyLevels");

            migrationBuilder.DropTable(
                name: "ExercisOfImges");

            migrationBuilder.DropTable(
                name: "ExercisOfMusclesGroups");

            migrationBuilder.DropTable(
                name: "ExercisOfVidios");

            migrationBuilder.DropTable(
                name: "WorkoutOfExercises");

            migrationBuilder.DropTable(
                name: "DifficultyLevels");

            migrationBuilder.DropTable(
                name: "Imges");

            migrationBuilder.DropTable(
                name: "Vidios");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Workouts",
                newName: "TimeRelax");

            migrationBuilder.AddColumn<string>(
                name: "DegreeDifficulty",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberRepetitions",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberSets",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MusclesGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MusclesGroupOfWorkouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusclesGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMusclesGroup = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdWorkout = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
    }
}
