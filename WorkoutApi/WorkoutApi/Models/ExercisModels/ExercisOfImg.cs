namespace WorkoutApi.Models
{
    public class ExercisOfImg
    {
        public Guid Id { get; set; }

        public Guid ExercisId { get; set; }
        public Guid ImgId { get; set; }

        public Exercis? Exercis { get; set; }
        public Img? Img { get; set; }

    }
}
