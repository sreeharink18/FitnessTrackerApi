using FitnessTrackerApi.Model;

namespace FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        Task UpdateAsync(ApplicationUser model);
    }
}
