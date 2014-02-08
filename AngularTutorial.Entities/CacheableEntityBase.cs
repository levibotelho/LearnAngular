using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public abstract class CacheableEntityBase
    {
        public readonly Guid Id;

        protected CacheableEntityBase() { }

        protected CacheableEntityBase(Guid id)
        {
            Id = id;
        }
    }
}