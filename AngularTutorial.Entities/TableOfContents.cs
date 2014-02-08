using System;
using System.Collections.Generic;
using System.Linq;

namespace AngularTutorial.Entities
{
    class TableOfContents : CacheableEntityBase
    {
        readonly KeyValuePair<Guid, Guid[]>[] _tableOfContents;

        public TableOfContents() { }

        public TableOfContents(Guid id, KeyValuePair<Guid, Guid[]>[] tableOfContents)
            : base(id)
        {
            _tableOfContents = tableOfContents;
            Modules = tableOfContents.Select(x => x.Key).ToArray();
        }

        public Guid[] this[Guid key]
        {
            get { return _tableOfContents.Single(x => x.Key == key).Value; }
        }

        public Guid[] Modules { get; private set; }
    }
}
