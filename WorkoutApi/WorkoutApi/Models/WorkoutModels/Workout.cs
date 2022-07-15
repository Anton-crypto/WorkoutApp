namespace WorkoutApi.Models.WorkoutModels
{
    public class Workout
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public List<WorkoutOfExercis>? WorkoutOfExercises { get; set; }
    }
}
