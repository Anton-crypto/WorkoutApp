namespace WorkoutApi.Models
{
    public class Workout
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Img { get; set; }
        public string? NumberSets { get; set; }
        public string? TimeRelax { get; set; }
        public string? NumberRepetitions { get; set; }
        public string? DegreeDifficulty { get; set; }

        public List<MusclesGroupOfWorkout>? MusclesGroupOfWorkouts { get; set; }
    }
}
