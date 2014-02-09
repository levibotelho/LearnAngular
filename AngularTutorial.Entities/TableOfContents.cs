using System;
using System.Collections.Generic;
using System.Linq;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class TableOfContents : CacheableEntityBase
    {
        readonly Translation<Dictionary<Guid, TableOfContentsModule>> _tableOfContents;

        public TableOfContents() { }

        public TableOfContents(Guid id, IEnumerable<KeyValuePair<Module, IEnumerable<Step>>> curriculum)
            : base(id)
        {
            var languages = Enum.GetValues(typeof (Language)).Cast<Language>();
            var tableOfContentsDictionary = languages.ToDictionary(x => x, x => GenerateTranslatedTableOfContents(curriculum, x));
            _tableOfContents = new Translation<Dictionary<Guid, TableOfContentsModule>>(tableOfContentsDictionary);
        }

        public Dictionary<Guid, TableOfContentsModule> this[Language language]
        {
            get { return _tableOfContents[language]; }
        }

        public TableOfContentsModule[] GetModules(Language language)
        {
            return _tableOfContents[language].Select(x => x.Value).ToArray();
        }

        public TableOfContentsStep[] GetSteps(Guid moduleId, Language language)
        {
            return _tableOfContents[language][moduleId].Steps;
        }

        static Dictionary<Guid, TableOfContentsModule> GenerateTranslatedTableOfContents(
            IEnumerable<KeyValuePair<Module, IEnumerable<Step>>> modules, Language language)
        {
            return modules.Select(x => GenerateTranslatedModule(x, language)).ToDictionary(x => x.Id, x => x);
        }

        static TableOfContentsModule GenerateTranslatedModule(KeyValuePair<Module, IEnumerable<Step>> module, Language language)
        {
            var translatedSteps = TranslateSteps(module.Value, language);
            return new TableOfContentsModule(module.Key.Id, module.Key.GetName(language), translatedSteps);
        }

        static TableOfContentsStep[] TranslateSteps(IEnumerable<Step> steps, Language language)
        {
            return steps.Select(step => new TableOfContentsStep(step.Id, step.GetName(language))).ToArray();
        }
    }
}