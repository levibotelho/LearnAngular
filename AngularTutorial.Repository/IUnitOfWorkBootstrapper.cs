namespace AngularTutorial.Repository
{
    public interface IUnitOfWorkBootstrapper
    {
        string ConnectionString { get; }
        string CourseRepositoryTableName { get; }
    }
}
