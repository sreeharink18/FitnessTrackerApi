using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackerApi.Model
{
    public class WorkoutPart
    {
        public Guid Id { get; set; }

        public Guid WorkoutAreaId { get; set; }
        [ForeignKey(nameof(WorkoutAreaId))]
        public WorkoutArea WorkoutArea { get; set; }

        // Null means this is a main part
        public Guid? ParentPartId { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

    }
}
