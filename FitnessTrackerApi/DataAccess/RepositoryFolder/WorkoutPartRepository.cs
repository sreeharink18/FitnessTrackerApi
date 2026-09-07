using FitnessTrackerApi.DataAccess.Data;
using FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder;
using FitnessTrackerApi.Model;

namespace FitnessTrackerApi.DataAccess.RepositoryFolder
{
    public class WorkoutPartRepository : Repository<WorkoutPart>, IWorkoutPartRepository
    {
        private ApplicationDbContext _db;
        public WorkoutPartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(WorkoutPart model)
        {
            _db.WorkoutParts.Update(model);
        }
    }
}
