using System;
using System.Collections.Generic;
using System.Linq;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class TableOfContents : CacheableEntityBase
    {
        public readonly TableOfContentsEntry[] Modules;

        public TableOfContents() { }

        public TableOfContents(Guid id, IEnumerable<Module> modules)
            : base(id)
        {
            Modules = modules
                .Select(module => new TableOfContentsEntry(
                    module.Id,
                    module.Title,
                    module.Steps.Select(step => new TableOfContentsEntry(step.Id, step.Title)).ToArray()))
                .ToArray();
        }
    }
}