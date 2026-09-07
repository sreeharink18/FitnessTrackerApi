using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackerApi.Model
{
    public class ExerciseSet
    {
        public Guid Id { get; set; }

        public Guid WorkoutSessionDayId { get; set; }
        [ForeignKey(nameof(WorkoutSessionDayId))]
        public WorkoutSessionDay WorkoutSessionDay { get; set; }

        public Guid ExerciseId { get; set; }
        [ForeignKey(nameof(ExerciseId))]
        public Exercise Exercise { get; set; }

        public int SetNumber { get; set; }

        public decimal? Weight { get; set; }

        public int? Reps { get; set; }

        public TimeSpan? Duration { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
