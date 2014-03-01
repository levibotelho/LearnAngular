using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class TableOfContentsEntry : CacheableEntityBase
    {
        public readonly string Title;
        public readonly TableOfContentsEntry[] Children;

        public TableOfContentsEntry(string id, string title)
            : base(id)
        {
            Title = title;
            Children = new TableOfContentsEntry[0];
        }

        public TableOfContentsEntry(string id, string title, TableOfContentsEntry[] children)
            : base(id)
        {
            Title = title;
            Children = children;
        }
    }
}