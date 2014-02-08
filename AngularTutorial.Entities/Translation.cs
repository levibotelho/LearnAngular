using System;
using System.Collections.Generic;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class Translation<T>
    {
        readonly Dictionary<string, T> _translations;

        public Translation() { }

        public Translation(Dictionary<string, T> translations)
        {
            _translations = translations;
        }

        public T this[string languageCode]
        {
            get
            {
                T translation;
                return _translations.TryGetValue(languageCode, out translation) ? translation : _translations["en"];
            }
        }
    }
}
