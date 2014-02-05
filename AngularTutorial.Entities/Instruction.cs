using Microsoft.WindowsAzure.Storage.Table;

namespace AngularTutorial.Entities
{
    public class Instruction : TableEntity
    {
        /// <summary>
        /// The ISO 639-1 code for the language of the instruction.
        /// </summary>
        public string LanguageCode
        {
            get { return PartitionKey; }
            set { PartitionKey = value; }
        }

        /// <summary>
        /// The "unique key" of the step that the instruction is for. 
        /// </summary>
        public string StepUniqueKey
        {
            get { return RowKey; }
            set { RowKey = value; }
        }

        public string Text { get; set; }
    }
}
