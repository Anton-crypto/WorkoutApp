using Microsoft.EntityFrameworkCore;
using WorkoutApi.Models;

namespace WorkoutApi.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Workout> Workouts { get; set; }
        public virtual DbSet<MusclesGroup> MusclesGroups { get; set; }
        public virtual DbSet<MusclesGroupOfWorkout> MusclesGroupOfWorkouts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
