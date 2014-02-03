using System.Collections.Generic;
using System.Linq;

namespace AngularTutorial.Entities
{
    public class TableOfContents
    {
        public TableOfContents(IEnumerable<KeyValuePair<string, string>> steps)
        {
            Modules = steps.GroupBy(x => x.Key, x => x.Value).ToDictionary(x => x.Key, x => x.ToArray());
        }

        public Dictionary<string, string[]> Modules { get; set; }
    }
}
