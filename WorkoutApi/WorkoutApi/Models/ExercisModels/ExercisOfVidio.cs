namespace WorkoutApi.Models
{
    public class ExercisOfVidio
    {
        public Guid Id { get; set; }

        public Guid ExercisId { get; set; }
        public Guid VidioId { get; set; }

        public Exercis? Exercis { get; set; }
        public Vidio? Vidio { get; set; }
    }
}
