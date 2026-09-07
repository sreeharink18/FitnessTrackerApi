using FitnessTrackerApi.DataAccess.Data;
using FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder;
using FitnessTrackerApi.Model;

namespace FitnessTrackerApi.DataAccess.RepositoryFolder
{
    public class WorkoutAreaRepository : Repository<WorkoutArea>, IWorkoutAreaRepository
    {
        private ApplicationDbContext _db;
        public WorkoutAreaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(WorkoutArea model)
        {
            _db.WorkoutAreas.Update(model);
        }
    }
}
