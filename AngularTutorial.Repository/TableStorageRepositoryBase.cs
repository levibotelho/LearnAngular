using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace AngularTutorial.Repository
{
    public interface ITableStorageRepositoryBase<T>
    {
        void Add(T entity);
        T Get(string partitionKey, string rowKey);
    }

    public abstract class TableStorageRepositoryBase<T> : ITableStorageRepositoryBase<T>
        where T : ITableEntity
    {
        protected readonly CloudTable Table;

        protected TableStorageRepositoryBase(CloudTable table)
        {
            Table = table;
        }

        public void Add(T entity)
        {
            Table.Execute(TableOperation.Insert(entity));
        }

        public T Get(string partitionKey, string rowKey)
        {
            var result = Table.Execute(TableOperation.Retrieve<T>(partitionKey, rowKey)).Result;
            if (result != null)
                return (T)result;
            throw new InvalidOperationException(
                string.Format("Entity with partition key {0} and row key {1} does not exist in the specified table.", partitionKey, rowKey));
        }
    }
}
