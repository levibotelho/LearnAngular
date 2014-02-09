using System;
using System.Collections.Generic;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class Translation<T>
    {
        readonly Dictionary<Language, T> _translations;

        public Translation() { }

        public Translation(Dictionary<Language, T> translations)
        {
            _translations = translations;
        }

        public T this[Language languageCode]
        {
            get
            {
                T translation;
                return _translations.TryGetValue(languageCode, out translation) ? translation : _translations[Language.English];
            }
        }
    }
}
