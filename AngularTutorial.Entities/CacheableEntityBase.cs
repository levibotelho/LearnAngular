using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public abstract class CacheableEntityBase
    {
        public readonly string Id;

        protected CacheableEntityBase(string id)
        {
            Id = id;
        }
    }
}