using System.Collections.Generic;
using AngularTutorial.Entities;
using Microsoft.WindowsAzure.Storage.Table;

namespace AngularTutorial.Repository
{
    public interface IStepRepository : ITableStorageRepositoryBase<Step>
    {
        IEnumerable<Step> GetAllInPartition(string partitionKey);
        IEnumerable<TableEntityIndex> GetTableListing();
    }

    public class StepRepository : TableStorageRepositoryBase<Step>, IStepRepository
    {
        public StepRepository(IUnitOfWork unitOfWork)
            :base(unitOfWork.StepTable)
        {
        }

        public IEnumerable<Step> GetAllInPartition(string partitionKey)
        {
            return Table.CreateQuery<Step>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));
        }

        public IEnumerable<TableEntityIndex> GetTableListing()
        {
            var query = new TableQuery().Select(new[] { "PartitionKey", "RowKey" });
            return Table.ExecuteQuery(query, (key, rowKey, timestamp, properties, etag) => new TableEntityIndex(key, rowKey));
        }
    }
}