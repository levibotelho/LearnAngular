using System.Collections.Generic;

namespace AngularTutorial.Entities
{
    public class TranslationDictionary
    {
        readonly Dictionary<string, string> _translations;

        public TranslationDictionary() { }

        public TranslationDictionary(Dictionary<string, string> translations)
        {
            _translations = translations;
        }

        public string this[string languageCode]
        {
            get
            {
                string translation;
                return _translations.TryGetValue(languageCode, out translation) ? translation : _translations["en"];
            }
        }
    }
}
