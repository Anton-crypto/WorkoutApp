namespace WorkoutApi.Models
{
    public class MusclesGroupOfWorkout
    {
        public Guid Id { get; set; }
        public Guid IdMusclesGroup { get; set; }
        public Guid IdWorkout { get; set; }

        public MusclesGroup MusclesGroup { get; set; }
        public Workout Workout { get; set; }
    }
}
