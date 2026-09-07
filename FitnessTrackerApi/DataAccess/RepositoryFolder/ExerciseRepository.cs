using FitnessTrackerApi.DataAccess.Data;
using FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder;
using FitnessTrackerApi.Model;

namespace FitnessTrackerApi.DataAccess.RepositoryFolder
{
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        private ApplicationDbContext _db;
        public ExerciseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(Exercise model)
        {
            _db.Exercises.Update(model);
        }
    }
}
