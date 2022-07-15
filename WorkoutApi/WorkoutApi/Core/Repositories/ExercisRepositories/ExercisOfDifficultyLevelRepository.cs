using WorkoutApi.Core.IRepositories;
using WorkoutApi.Models;
using WorkoutApi.Data;
using Microsoft.EntityFrameworkCore;

namespace WorkoutApi.Core.Repositories
{
    public class ExercisOfDifficultyLevelRepository : GenericRepository<ExercisOfDifficultyLevel>, IExercisOfDifficultyLevelRepository
    {
        public ExercisOfDifficultyLevelRepository(
            AppDbContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }
    }
}