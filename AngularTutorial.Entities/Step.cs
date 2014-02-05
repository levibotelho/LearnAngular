using Microsoft.WindowsAzure.Storage.Table;

namespace AngularTutorial.Entities
{
    public class Step : TableEntity
    {
        /// <summary>
        /// Gets or sets the name of the module that contains the step. This is an alias for the partition key.
        /// </summary>
        public string ModuleName
        {
            get { return PartitionKey; }
            set { PartitionKey = value; }
        }

        /// <summary>
        /// Gets or sets the name of the step. This is an alias for the row key.
        /// </summary>
        public string Name
        {
            get { return RowKey; }
            set { RowKey = value; }
        }

        public string UniqueKey { get { return PartitionKey + RowKey; } }
        
        public string StartingHtml { get; set; }
        public string SolutionHtml { get; set; }
        public string StartingJavaScript { get; set; }
        public string SolutionJavaScript { get; set; }
        public FrameWriteInstructions FrameWriteInstructions { get; set; }
    }
}
