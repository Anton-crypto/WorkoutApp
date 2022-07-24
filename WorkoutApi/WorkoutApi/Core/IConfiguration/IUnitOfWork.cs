using WorkoutApi.Core.IRepositories;

namespace WorkoutApi.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IWorkoutRepository Workouts { get; }
        IWorkoutOfExercisRepository WorkoutOfExercises { get; }

        IExercisRepository Exercises { get; }
        IExercisOfFileRepository ExercisOfFiles { get; } 

        IExercisOfMusclesGroupRepository ExercisOfMusclesGroups { get; }
        IExercisOfDifficultyLevelRepository ExercisOfDifficultyLevels { get; }

        IMusclesGroupRepository MusclesGroups { get; }
        IDifficultyLevelRepository DifficultyLevels { get; }

        IFileRepository Files { get; }

        Task CompleteAsync();
    }
}
