using FitnessTrackerApi.DataAccess.Data;
using FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder;

namespace FitnessTrackerApi.DataAccess.RepositoryFolder
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IApplicationUserRepository ApplicationUserRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUserRepository = new ApplicationUserRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
