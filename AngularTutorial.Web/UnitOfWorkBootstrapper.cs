using AngularTutorial.Repository;

namespace AngularTutorial.Web
{
    public class UnitOfWorkBootstrapper : IUnitOfWorkBootstrapper
    {
        public string ConnectionString { get { return ConfigurationFacade.StorageConnectionString; } }
        public string CourseRepositoryTableName { get { return ConfigurationFacade.CourseRepositoryTableName; } }
    }
}