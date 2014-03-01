using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class Module : CacheableEntityBase
    {
        public readonly string Title;
        public readonly Lesson[] Lessons;

        public Module(string id, string title, Lesson[] lessons)
            : base(id)
        {
            Title = title;
            Lessons = lessons;
        }
    }
}