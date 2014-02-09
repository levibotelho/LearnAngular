using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class Module : CacheableEntityBase
    {
        public Module() { }

        public Module(Guid id, string name)
            :base(id)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}