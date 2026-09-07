namespace FitnessTrackerApi.Model.Dto.WorkoutDtoFolder
{
    public class UpdateRequestWorkoutSessionDayDto
    {
        public DateTime WorkoutDate { get; set; }

        public DateTime? StartedAt { get; set; }

        public DateTime? EndedAt { get; set; }
    }
}
