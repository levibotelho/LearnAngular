using System;
using System.Collections.Generic;
using System.Linq;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class TableOfContents : CacheableEntityBase
    {
        readonly Dictionary<Guid, TableOfContentsModule> _tableOfContents;

        public TableOfContents() { }

        public TableOfContents(Guid id, IEnumerable<KeyValuePair<Module, IEnumerable<Step>>> modules)
            : base(id)
        {
            _tableOfContents = modules.Select(GenerateTranslatedModule).ToDictionary(x => x.Id, x => x);
        }
        
        public TableOfContentsModule[] GetModules()
        {
            return _tableOfContents.Select(x => x.Value).ToArray();
        }

        public TableOfContentsStep[] GetSteps(Guid moduleId)
        {
            return _tableOfContents[moduleId].Steps;
        }
        
        static TableOfContentsModule GenerateTranslatedModule(KeyValuePair<Module, IEnumerable<Step>> module)
        {
            var translatedSteps = TranslateSteps(module.Value);
            return new TableOfContentsModule(module.Key.Id, module.Key.Name, translatedSteps);
        }

        static TableOfContentsStep[] TranslateSteps(IEnumerable<Step> steps)
        {
            return steps.Select(step => new TableOfContentsStep(step.Id, step.Name)).ToArray();
        }
    }
}