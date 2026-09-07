using FitnessTrackerApi.DataAccess.Data;
using FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder;
using FitnessTrackerApi.Model;

namespace FitnessTrackerApi.DataAccess.RepositoryFolder
{
    public class WorkoutSessionDayRepository : Repository<WorkoutSessionDay>, IWorkoutSessionDayRepository
    {
        private ApplicationDbContext _db;
        public WorkoutSessionDayRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(WorkoutSessionDay model)
        {
            _db.WorkoutSessionDays.Update(model);
        }
    }
}
