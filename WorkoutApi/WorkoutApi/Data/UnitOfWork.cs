using WorkoutApi.Core.IConfiguration;
using WorkoutApi.Core.IRepositories;
using WorkoutApi.Core.Repositories;

namespace WorkoutApi.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IWorkoutRepository Workouts { get; }
        public IWorkoutOfExercisRepository WorkoutOfExercises { get; }

        public IExercisRepository Exercises { get; }
        public IExercisOfFileRepository ExercisOfFiles { get; }

        public IExercisOfMusclesGroupRepository ExercisOfMusclesGroups { get; }
        public IExercisOfDifficultyLevelRepository ExercisOfDifficultyLevels { get; }

        public IMusclesGroupRepository MusclesGroups { get; }
        public IDifficultyLevelRepository DifficultyLevels { get; }

        public IFileRepository Files { get; }


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
            WorkoutOfExercises = new WorkoutOfExercisRepository(_context, _logger);

            Exercises = new ExercisRepository(_context, _logger);
            ExercisOfFiles = new ExercisOfFileRepository(_context, _logger);

            ExercisOfMusclesGroups = new ExercisOfMusclesGroupRepository(_context, _logger);
            ExercisOfDifficultyLevels = new ExercisOfDifficultyLevelRepository(_context, _logger);

            MusclesGroups = new MusclesGroupRepository(_context, _logger);
            DifficultyLevels = new DifficultyLevelRepository(_context, _logger);

            Files = new FileRepository(_context, _logger);
        }

        public async Task CompleteAsync() { await _context.SaveChangesAsync(); }
        public async void Dispose() { await _context.DisposeAsync(); }
    }
}
