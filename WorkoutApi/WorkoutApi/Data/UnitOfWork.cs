using WorkoutApi.Core.IConfiguration;
using WorkoutApi.Core.IRepositories;
using WorkoutApi.Core.Repositories;

namespace WorkoutApi.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IWorkoutRepository Workouts { get; set; }
        public IMusclesGroupRepository MusclesGroups { get; set; }
        public IMusclesGroupOfWorkoutRepository MusclesGroupOfWorkouts { get; set; }

        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(
            AppDbContext context,
            ILoggerFactory logger
        )
        {
            _context = context;
            _logger = logger.CreateLogger("logs");

            Workouts = new WorkoutRepository(_context, _logger);
            MusclesGroups = new MusclesGroupRepository(_context, _logger);
            MusclesGroupOfWorkouts = new MusclesGroupOfWorkoutRepository(_context, _logger);
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}
