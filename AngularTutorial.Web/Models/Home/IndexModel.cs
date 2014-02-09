using System.Collections.Generic;
using AngularTutorial.Entities;

namespace AngularTutorial.Web.Models.Home
{
    public class IndexModel
    {
        public IndexModel() { }

        public IndexModel(IReadOnlyCollection<TableOfContentsModule> modules)
        {
            Modules = modules;
        }

        public IReadOnlyCollection<TableOfContentsModule> Modules { get; private set; }
    }
}