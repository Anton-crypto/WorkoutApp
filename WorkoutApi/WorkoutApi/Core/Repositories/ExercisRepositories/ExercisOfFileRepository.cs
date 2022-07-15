using WorkoutApi.Core.IRepositories;
using WorkoutApi.Models;
using WorkoutApi.Data;
using Microsoft.EntityFrameworkCore;

namespace WorkoutApi.Core.Repositories
{
    public class ExercisOfFileRepository : GenericRepository<ExercisOfImg>, IExercisOfImgRepository
    {
        public ExercisOfFileRepository(
            AppDbContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }
    }
}