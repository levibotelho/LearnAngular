using System;
using System.Collections.Generic;
using System.Linq;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class TableOfContents : CacheableEntityBase
    {
        readonly KeyValuePair<Guid, Guid[]>[] _tableOfContents;
        
        public TableOfContents() { }
        
        public TableOfContents(Guid id, KeyValuePair<Guid, Guid[]>[] tableOfContents, Translation<string[]> moduleNames)
            : base(id)
        {
            _tableOfContents = tableOfContents;

            // moduleNames is passed and stored for performance reasons. It is entirely possible to dynamically generate
            // the list of module names each time they are requested.
            ModuleNames = moduleNames;
        }

        public Guid[] this[Guid key]
        {
            get { return _tableOfContents.Single(x => x.Key == key).Value; }
        }

        public Translation<string[]> ModuleNames { get; private set; }
    }
}
