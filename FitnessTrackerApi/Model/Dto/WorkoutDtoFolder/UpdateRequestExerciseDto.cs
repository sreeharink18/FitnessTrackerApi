namespace FitnessTrackerApi.Model.Dto.WorkoutDtoFolder
{
    public class UpdateRequestExerciseDto
    {
        public Guid WorkoutPartId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? UpdatedAt { get; set; }
    }
}
