using WorkoutApi.Core.IRepositories;
using WorkoutApi.Models;
using WorkoutApi.Data;
using Microsoft.EntityFrameworkCore;

namespace WorkoutApi.Core.Repositories
{
    public class WorkoutRepository : GenericRepository<Workout>, IWorkoutRepository
    {
        public WorkoutRepository (
            AppDbContext context,
            ILogger logger
        ) : base (context, logger)
        {

        }

        public override async Task<IEnumerable<Workout>> GetAllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetAll method error", typeof(WorkoutRepository));
                return new List<Workout>();
            }
        }

        public override async Task<bool> UpdateAsync(Workout entity)
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

        public override async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var existingWorkout = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                if(existingWorkout != null)
                {
                    dbSet.Remove(existingWorkout);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} DeleteAsync method error", typeof(WorkoutRepository));
                return false;
            }
        }
    }
}
