using WorkoutApi.Core.IRepositories;
using WorkoutApi.Models;
using WorkoutApi.Data;
using Microsoft.EntityFrameworkCore;

namespace WorkoutApi.Core.Repositories
{
    public class ExercisOfVidioRepository : GenericRepository<ExercisOfVidio>, IExercisOfVidioRepository
    {
        public ExercisOfVidioRepository(
            AppDbContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }
    }
}