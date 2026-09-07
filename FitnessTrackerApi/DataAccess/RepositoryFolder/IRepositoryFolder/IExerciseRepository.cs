using FitnessTrackerApi.Model;

namespace FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder
{
    public interface IExerciseRepository : IRepository<Exercise>
    {
        Task UpdateAsync(Exercise model);
    }
}
