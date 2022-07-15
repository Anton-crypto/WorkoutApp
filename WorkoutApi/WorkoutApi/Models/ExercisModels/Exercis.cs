namespace WorkoutApi.Models
{
    public class Exercis
    {
        public Guid Id { get; set; }

        public string? Name { get; set; } // Название упражнения
        public string? CountSets { get; set; } // Количество подходов
        public string? TimeOfRelax { get; set; } // Время отдыха
        public string? NumberOfRepetitions { get; set; } // Количество повторений
        public string? DifficultyLevel { get; set; } // Уровень сложности

        public List<ExercisOfFile>? File { get; set; }
        public List<ExercisOfMusclesGroup>? MusclesGroupOfWorkouts { get; set; }
        public List<DifficultyLevel>? DifficultyLevels { get; set; }
    }
}
