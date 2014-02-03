using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AngularTutorial.Entities;
using Microsoft.WindowsAzure.Storage.Table;

namespace AngularTutorial.Repository
{
    public interface ICourseRepository
    {
        TableOfContents TableOfContents { get; }
        IEnumerable<Step> GetModule(string name);
        void AddStep(Step step);
    }

    public class CourseRepository : ICourseRepository
    {
        readonly CloudTable _table;
        static TableOfContents _tableOfContents;

        public CourseRepository(CloudTableClient tableClient, string tableName)
        {
            _table = tableClient.GetTableReference(tableName);
        }

        public TableOfContents TableOfContents
        {
            get { return _tableOfContents ?? (_tableOfContents = GenerateTableOfContents()); }
        }
        
        public IEnumerable<Step> GetModule(string name)
        {
            var query = _table.CreateQuery<Step>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, name));
            return _table.ExecuteQuery(query);
        }

        public void AddStep(Step step)
        {
            _table.Execute(TableOperation.Insert(step));
        }
        
        TableOfContents GenerateTableOfContents()
        {
            var query = _table.CreateQuery<DynamicTableEntity>().Select(new[] {"PartitionKey", "RowKey"});
            var steps = _table.ExecuteQuery(query, (key, rowKey, timestamp, properties, etag) => new KeyValuePair<string, string>(key, rowKey));
            return new TableOfContents(steps);
        }
    }
}