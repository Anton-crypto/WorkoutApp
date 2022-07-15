using Microsoft.EntityFrameworkCore;
using WorkoutApi.Models;
using WorkoutApi.Models.WorkoutModels;

namespace WorkoutApi.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Workout> Workouts { get; set; }
        public virtual DbSet<WorkoutOfExercis> WorkoutOfExercises { get; set; }


        public virtual DbSet<Exercis> Exercises { get; set; }
        public virtual DbSet<ExercisOfImg> ExercisOfImges { get; set; }
        public virtual DbSet<ExercisOfFile> ExercisOfVidios { get; set; }
        public virtual DbSet<ExercisOfMusclesGroup> ExercisOfMusclesGroups { get; set; }
        public virtual DbSet<ExercisOfDifficultyLevel> ExercisOfDifficultyLevels { get; set; }

        public virtual DbSet<MusclesGroup> MusclesGroups { get; set; }
        public virtual DbSet<DifficultyLevel> DifficultyLevels { get; set; }

        public virtual DbSet<Img> Imges { get; set; }
        public virtual DbSet<Vidio> Vidios { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
