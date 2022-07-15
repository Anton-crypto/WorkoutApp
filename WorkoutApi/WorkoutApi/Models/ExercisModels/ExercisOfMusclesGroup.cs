namespace WorkoutApi.Models
{
    public class ExercisOfMusclesGroup
    {
        public Guid Id { get; set; }

        public Guid IdMusclesGroup { get; set; }
        public Guid IdExercis { get; set; }

        public MusclesGroup? MusclesGroup { get; set; }
        public Exercis? Exercis { get; set; }
}
}
