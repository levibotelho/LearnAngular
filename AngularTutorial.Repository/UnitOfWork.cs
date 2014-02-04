using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AngularTutorial.Repository
{
    public interface IUnitOfWork
    {
        CloudTable CourseTable { get; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUnitOfWorkBootstrapper bootstrapper)
        {
            var storageAccount = CloudStorageAccount.Parse(bootstrapper.ConnectionString);
            CourseTable = storageAccount.CreateCloudTableClient().GetTableReference(bootstrapper.CourseRepositoryTableName);
        }

        public CloudTable CourseTable { get; private set; }
    }
}
