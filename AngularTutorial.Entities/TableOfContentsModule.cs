using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class TableOfContentsModule
    {
        public readonly Guid Id;
        public readonly string Name;
        public readonly TableOfContentsStep[] Steps;

        public TableOfContentsModule(Guid id, string name, TableOfContentsStep[] steps)
        {
            Id = id;
            Name = name;
            Steps = steps;
        }
    }
}
