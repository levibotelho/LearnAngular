using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AngularTutorial.Repository
{
    public interface IUnitOfWork
    {
        CloudTable StepTable { get; }
        CloudTable InstructionTable { get; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUnitOfWorkBootstrapper bootstrapper)
        {
            var storageAccount = CloudStorageAccount.Parse(bootstrapper.ConnectionString);
            StepTable = storageAccount.CreateCloudTableClient().GetTableReference(bootstrapper.CourseRepositoryTableName);
        }

        public CloudTable StepTable { get; private set; }
        public CloudTable InstructionTable { get; private set; }
    }
}
