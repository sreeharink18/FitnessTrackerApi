using FitnessTrackerApi.Model;

namespace FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder
{
    public interface IWorkoutSessionDayRepository : IRepository<WorkoutSessionDay>
    {
        Task UpdateAsync(WorkoutSessionDay model);
    }
}
