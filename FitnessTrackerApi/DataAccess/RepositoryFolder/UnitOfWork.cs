using FitnessTrackerApi.DataAccess.Data;
using FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder;

namespace FitnessTrackerApi.DataAccess.RepositoryFolder
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IApplicationUserRepository ApplicationUserRepository { get; private set; }
        public IWorkoutSessionDayRepository WorkoutSessionDayRepository { get; private set; }
        public IWorkoutAreaRepository WorkoutAreaRepository { get; private set; }
        public IWorkoutPartRepository WorkoutPartRepository { get; private set; }
        public IExerciseRepository ExerciseRepository { get; private set; }
        public IExerciseSetRepository ExerciseSetRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUserRepository = new ApplicationUserRepository(_db);
            WorkoutSessionDayRepository = new WorkoutSessionDayRepository(_db);
            WorkoutAreaRepository = new WorkoutAreaRepository(_db);
            WorkoutPartRepository = new WorkoutPartRepository(_db);
            ExerciseRepository = new ExerciseRepository(_db);
            ExerciseSetRepository = new ExerciseSetRepository(_db);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
