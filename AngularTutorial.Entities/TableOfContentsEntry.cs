using System;
using System.Collections.Generic;
using System.Linq;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class TableOfContentsEntry : CacheableEntityBase
    {
        public readonly string Title;
        public readonly IEnumerable<TableOfContentsEntry> Children;

        public TableOfContentsEntry(Guid id, string title)
            : base(id)
        {
            Title = title;
            Children = Enumerable.Empty<TableOfContentsEntry>();
        }

        public TableOfContentsEntry(Guid id, string title, IEnumerable<TableOfContentsEntry> children)
            : base(id)
        {
            Title = title;
            Children = children;
        }
    }
}