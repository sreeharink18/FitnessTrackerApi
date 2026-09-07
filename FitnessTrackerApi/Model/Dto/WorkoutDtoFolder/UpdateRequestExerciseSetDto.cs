namespace FitnessTrackerApi.Model.Dto.WorkoutDtoFolder
{
    public class UpdateRequestExerciseSetDto
    {
        public Guid ExerciseId { get; set; }

        public int SetNumber { get; set; }

        public decimal? Weight { get; set; }

        public int? Reps { get; set; }

        public TimeSpan? Duration { get; set; }
    }
}
