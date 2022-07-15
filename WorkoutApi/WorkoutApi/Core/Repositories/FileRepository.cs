using WorkoutApi.Core.IRepositories;
using WorkoutApi.Data;
using Microsoft.EntityFrameworkCore;
using WorkoutApi.Models;

namespace WorkoutApi.Core.Repositories
{
    public class ImgRepository : GenericRepository<Img>, IImgRepository
    {
        public ImgRepository(
            AppDbContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }
    }
}

