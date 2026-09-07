using FitnessTrackerApi.Model;

namespace FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder
{
    public interface IWorkoutPartRepository : IRepository<WorkoutPart>
    {
        Task UpdateAsync(WorkoutPart model);
    }
}
