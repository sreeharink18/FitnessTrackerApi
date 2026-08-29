namespace FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder
{
    public interface IUnitOfWork
    {
        IApplicationUserRepository ApplicationUserRepository { get; }

        void Save();
    }
}
