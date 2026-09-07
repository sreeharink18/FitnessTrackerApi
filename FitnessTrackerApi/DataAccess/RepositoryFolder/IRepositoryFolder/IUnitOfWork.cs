namespace FitnessTrackerApi.DataAccess.RepositoryFolder.IRepositoryFolder
{
    public interface IUnitOfWork
    {
        IApplicationUserRepository ApplicationUserRepository { get; }
        IWorkoutAreaRepository WorkoutAreaRepository { get; }
        IWorkoutPartRepository WorkoutPartRepository { get; }
        IExerciseRepository ExerciseRepository { get; }
        IWorkoutSessionDayRepository WorkoutSessionDayRepository { get; }
        IExerciseSetRepository ExerciseSetRepository { get; }

        Task Save();
    }
}
