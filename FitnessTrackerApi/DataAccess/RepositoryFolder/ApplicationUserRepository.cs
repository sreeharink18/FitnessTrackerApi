using FitnessTrackerApi.DataAccess.Data;
using FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder;
using FitnessTrackerApi.Model;

namespace FitnessTrackerApi.DataAccess.RepositoryFolder
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(ApplicationUser model)
        {
            _db.ApplicationUsers.Update(model);
        }
    }
}
