using Microsoft.WindowsAzure.Storage;

namespace AngularTutorial.Repository
{
    public interface IUnitOfWork
    {
        ICourseRepository CourseRepository { get; }
    }

    public class UnitOfWork
    {
        public UnitOfWork(IUnitOfWorkBootstrapper bootstrapper)
        {
            var storageAccount = CloudStorageAccount.Parse(bootstrapper.ConnectionString);
            CourseRepository = new CourseRepository(storageAccount.CreateCloudTableClient(), bootstrapper.CourseRepositoryTableName);
        }

        public ICourseRepository CourseRepository { get; private set; }
    }
}
