namespace FitnessTrackerApi.Model.Dto.WorkoutDtoFolder
{
    public class UpdateRequestWorkoutPartDto
    {
        public Guid? ParentPartId { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime? UpdatedAt { get; set; }
    }
}
