using FitnessTrackerApi.Model;

namespace FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder
{
    public interface IExerciseSetRepository : IRepository<ExerciseSet>
    {
        Task UpdateAsync(ExerciseSet model);
    }
}
