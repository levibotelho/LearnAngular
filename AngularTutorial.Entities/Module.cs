using System;

namespace AngularTutorial.Entities
{
    public class Module : CacheableEntityBase
    {
        readonly TranslationDictionary _name;

        public Module() { }

        public Module(Guid id, TranslationDictionary name)
            :base(id)
        {
            _name = name;
        }

        public string GetName(string languageCode)
        {
            return _name[languageCode];
        }
    }
}