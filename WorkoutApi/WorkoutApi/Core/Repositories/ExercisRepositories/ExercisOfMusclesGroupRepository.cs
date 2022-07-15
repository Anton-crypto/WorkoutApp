using WorkoutApi.Core.IRepositories;
using WorkoutApi.Models;
using WorkoutApi.Data;
using Microsoft.EntityFrameworkCore;

namespace WorkoutApi.Core.Repositories
{
    public class ExercisOfMusclesGroupRepository : GenericRepository<ExercisOfMusclesGroup>, IExercisOfMusclesGroupRepository
    {
        public ExercisOfMusclesGroupRepository(
            AppDbContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }
    }
}
