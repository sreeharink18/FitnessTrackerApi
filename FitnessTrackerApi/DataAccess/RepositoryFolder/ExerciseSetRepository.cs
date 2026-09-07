using FitnessTrackerApi.DataAccess.Data;
using FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder;
using FitnessTrackerApi.Model;

namespace FitnessTrackerApi.DataAccess.RepositoryFolder
{
    public class ExerciseSetRepository : Repository<ExerciseSet>, IExerciseSetRepository
    {
        private ApplicationDbContext _db;
        public ExerciseSetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(ExerciseSet model)
        {
            _db.ExerciseSets.Update(model);
        }
    }
}
