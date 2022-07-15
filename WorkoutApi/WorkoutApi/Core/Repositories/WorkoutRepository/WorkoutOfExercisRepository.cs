using WorkoutApi.Core.IRepositories;
using WorkoutApi.Data;
using Microsoft.EntityFrameworkCore;
using WorkoutApi.Models.WorkoutModels;

namespace WorkoutApi.Core.Repositories
{
    public class WorkoutOfExercisRepository : GenericRepository<WorkoutOfExercis>, IWorkoutOfExercisRepository
    {
        public WorkoutOfExercisRepository(
            AppDbContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }
    }
}

