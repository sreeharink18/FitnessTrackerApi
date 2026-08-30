using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackerApi.Model
{
    public class WorkoutSessionDay
    {
        public Guid Id { get; set; }

        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public ApplicationUser ApplicationUser { get; set; }

        // Date selected by the user for the workout
        public DateTime WorkoutDate { get; set; }

        public DateTime? StartedAt { get; set; }

        public DateTime? EndedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
