using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackerApi.Model
{
    public class Exercise
    {
        public Guid Id { get; set; }

        public Guid WorkoutPartId { get; set; }

        [ForeignKey(nameof(WorkoutPartId))]
        public WorkoutPart WorkoutPart { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
