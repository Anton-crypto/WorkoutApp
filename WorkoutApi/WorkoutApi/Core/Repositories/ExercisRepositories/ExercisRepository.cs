using WorkoutApi.Core.IRepositories;
using WorkoutApi.Models;
using WorkoutApi.Data;
using Microsoft.EntityFrameworkCore;

namespace WorkoutApi.Core.Repositories
{
    public class ExercisRepository : GenericRepository<Exercis>, IExercisRepository
    {
        public ExercisRepository(
            AppDbContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }

        public override async Task<bool> AddAsync(Exercis entity)
        {
            var existingWorkout = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

            if (existingWorkout == null)
            {
                return await AddAsync(entity);
            }

            try
            {
                dbSet.Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} UpdateAsync method error", typeof(WorkoutRepository));
                return false;
            }
        }
    }
}

