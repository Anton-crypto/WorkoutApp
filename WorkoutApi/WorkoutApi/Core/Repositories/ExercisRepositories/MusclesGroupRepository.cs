using WorkoutApi.Core.IRepositories;
using WorkoutApi.Models;
using WorkoutApi.Data;
using Microsoft.EntityFrameworkCore;

namespace WorkoutApi.Core.Repositories
{
    public class MusclesGroupRepository : GenericRepository<MusclesGroup>, IMusclesGroupRepository
    {
        public MusclesGroupRepository(
            AppDbContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }
    }
}

