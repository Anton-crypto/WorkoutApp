namespace WorkoutApi.Models.ViewModels
{
    public class ExercisView
    {
        public Guid Id { get; set; }

        public string? Name { get; set; } // Название упражнения
        public string? CountSets { get; set; } // Количество подходов
        public string? TimeOfRelax { get; set; } // Время отдыха
        public string? NumberOfRepetitions { get; set; } // Количество повторений

        public Guid? DifficultyLevelId { get; set; } // Уровень сложности
        public Guid? MusclesGroupId { get; set; }

        public List<File>? Files { get; set; }
    }
}
