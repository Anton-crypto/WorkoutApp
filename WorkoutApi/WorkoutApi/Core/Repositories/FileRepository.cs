using WorkoutApi.Core.IRepositories;
using WorkoutApi.Data;
using Microsoft.EntityFrameworkCore;
using WorkoutApi.Models;

namespace WorkoutApi.Core.Repositories
{
    public class FileRepository : GenericRepository<Models.File>, IFileRepository
    {
        public FileRepository(
            AppDbContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }
    }
}

