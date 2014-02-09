using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class Module : CacheableEntityBase
    {
        readonly Translation<string> _name;

        public Module() { }

        public Module(Guid id, Translation<string> name)
            :base(id)
        {
            _name = name;
        }

        public string GetName(Language language)
        {
            return _name[language];
        }
    }
}