
namespace AngularTutorial.Entities
{
    public struct TableEntityIndex
    {
        public readonly string PartitionKey;
        public readonly string RowKey;

        public TableEntityIndex(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }
    }
}
