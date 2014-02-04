using System;
using System.Collections.Generic;
using System.Linq;

namespace AngularTutorial.Entities
{
    public class TableOfContents
    {
        public TableOfContents(IEnumerable<TableEntityIndex> steps)
        {
            Modules = steps.GroupBy(x => x.PartitionKey, x => x.RowKey).ToDictionary(x => x.Key, x => x.ToArray());
        }

        public Dictionary<string, string[]> Modules { get; set; }
    }
}
