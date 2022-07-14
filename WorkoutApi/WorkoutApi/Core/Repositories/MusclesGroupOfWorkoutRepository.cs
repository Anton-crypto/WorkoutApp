using WorkoutApi.Core.IRepositories;
using WorkoutApi.Models;
using WorkoutApi.Data;
using Microsoft.EntityFrameworkCore;

namespace WorkoutApi.Core.Repositories
{
    public class MusclesGroupOfWorkoutRepository : GenericRepository<MusclesGroupOfWorkout>, IMusclesGroupOfWorkoutRepository
    {
        public MusclesGroupOfWorkoutRepository(
            AppDbContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }
    }
}
