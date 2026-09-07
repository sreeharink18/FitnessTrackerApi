namespace FitnessTrackerApi.Model.Dto.WorkoutDtoFolder
{
    public class CreateRequestWorkoutSessionDayDto
    {
        public string UserId { get; set; }
        public DateTime WorkoutDate { get; set; }

        public DateTime? StartedAt { get; set; }

        public DateTime? EndedAt { get; set; }
    }
}
