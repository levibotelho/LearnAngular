using System;
using System.Collections.Generic;
using AngularTutorial.Entities;
using Microsoft.WindowsAzure.Storage.Table;

namespace AngularTutorial.Repository
{
    public interface ICourseRepository
    {
        IEnumerable<Step> GetAllInPartition(string partitionKey);
        Step Get(string partitionKey, string rowKey);
        IEnumerable<TableEntityIndex> GetTableListing();
        void AddStep(Step step);
    }

    public class CourseRepository : ICourseRepository
    {
        readonly CloudTable _table;

        public CourseRepository(IUnitOfWork unitOfWork)
        {
            _table = unitOfWork.CourseTable;
        }

        public IEnumerable<Step> GetAllInPartition(string partitionKey)
        {
            return _table.CreateQuery<Step>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));
        }

        public Step Get(string partitionKey, string rowKey)
        {
            return (Step) _table.Execute(TableOperation.Retrieve(partitionKey, rowKey)).Result;
        }

        public IEnumerable<TableEntityIndex> GetTableListing()
        {
            var query = new TableQuery().Select(new[] { "PartitionKey", "RowKey" });
            return _table.ExecuteQuery(query, (key, rowKey, timestamp, properties, etag) => new TableEntityIndex(key, rowKey));
        }

        public void AddStep(Step step)
        {
            _table.Execute(TableOperation.Insert(step));
        }
    }
}