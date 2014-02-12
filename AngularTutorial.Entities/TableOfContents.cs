using System;
using System.Collections.Generic;
using System.Linq;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class TableOfContents
    {
        public readonly TableOfContentsEntry[] Modules;

        public TableOfContents() { }

        public TableOfContents(IEnumerable<Module> modules)
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