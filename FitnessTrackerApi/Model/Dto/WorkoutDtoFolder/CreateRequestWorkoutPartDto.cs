namespace FitnessTrackerApi.Model.Dto.WorkoutDtoFolder
{
    public class CreateRequestWorkoutPartDto
    {
        public Guid WorkoutAreaId { get; set; }
        public Guid? ParentPartId { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
