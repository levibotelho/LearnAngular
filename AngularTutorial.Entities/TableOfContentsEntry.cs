using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class TableOfContentsEntry : CacheableEntityBase
    {
        public readonly string Title;
        public readonly TableOfContentsEntry[] Children;

        public TableOfContentsEntry(Guid id, string title)
            : base(id)
        {
            Title = title;
            Children = new TableOfContentsEntry[0];
        }

        public TableOfContentsEntry(Guid id, string title, TableOfContentsEntry[] children)
            : base(id)
        {
            Title = title;
            Children = children;
        }
    }
}