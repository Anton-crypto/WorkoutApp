using WorkoutApi.Core.IRepositories;

namespace WorkoutApi.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IWorkoutRepository Workouts { get; }
        IWorkoutOfExercisRepository WorkoutOfExercises { get; }

        IExercisRepository Exercises { get; }
        IExercisOfImgRepository ExercisOfImges { get; }
        IExercisOfVidioRepository ExercisOfVidios { get; }
        IExercisOfMusclesGroupRepository ExercisOfMusclesGroups { get; }
        IExercisOfDifficultyLevelRepository ExercisOfDifficultyLevels { get; }

        IMusclesGroupRepository MusclesGroups { get; }
        IDifficultyLevelRepository DifficultyLevels { get; }

        IImgRepository Imges { get; }
        IVidioRepository Vidios { get; }

        Task CompleteAsync();
    }
}
