using FitnessTrackerApi.Model;

namespace FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder
{
    public interface IWorkoutAreaRepository : IRepository<WorkoutArea>
    {
        Task UpdateAsync(WorkoutArea model);
    }
}
