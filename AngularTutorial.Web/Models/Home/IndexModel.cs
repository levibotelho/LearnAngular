using System.Collections.Generic;
using AngularTutorial.Entities;

namespace AngularTutorial.Web.Models.Home
{
    public class IndexModel
    {
        public IndexModel() { }

        public IndexModel(IEnumerable<TableOfContentsEntry> modules)
        {
            Modules = modules;
        }

        public IEnumerable<TableOfContentsEntry> Modules { get; private set; }
    }
}