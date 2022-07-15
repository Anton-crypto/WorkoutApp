namespace WorkoutApi.Models.WorkoutModels
{
    public class WorkoutOfExercis
    {
        public Guid Id { get; set; }

        public Guid WorkoutId { get; set; }
        public Guid ExercisId { get; set; }

        public Workout? Workout { get; set; }
        public Exercis? Exercis { get; set; }
    }
}
