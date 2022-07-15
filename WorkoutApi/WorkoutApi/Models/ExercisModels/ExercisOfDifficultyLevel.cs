namespace WorkoutApi.Models
{
    public class ExercisOfDifficultyLevel
    {
        public Guid Id { get; set; }

        public Guid IdDifficultyLevel { get; set; }
        public Guid IdExercis { get; set; }

        public DifficultyLevel? DifficultyLevel { get; set; }
        public Exercis? Exercis { get; set; }
    }
}
