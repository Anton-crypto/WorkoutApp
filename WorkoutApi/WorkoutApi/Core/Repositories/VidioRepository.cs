using WorkoutApi.Core.IRepositories;
using WorkoutApi.Data;
using Microsoft.EntityFrameworkCore;
using WorkoutApi.Models;

namespace WorkoutApi.Core.Repositories
{
    public class VidioRepository : GenericRepository<Vidio>, IVidioRepository
    {
        public VidioRepository(
            AppDbContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }
    }
}

