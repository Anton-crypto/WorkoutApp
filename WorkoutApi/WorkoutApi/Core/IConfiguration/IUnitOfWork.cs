using WorkoutApi.Core.IRepositories;

namespace WorkoutApi.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IWorkoutRepository Workouts { get; }
        IMusclesGroupRepository MusclesGroups { get; }
        IMusclesGroupOfWorkoutRepository MusclesGroupOfWorkouts { get; }

        Task CompleteAsync();
    }
}
