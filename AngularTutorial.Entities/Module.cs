using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class Module
    {
        public readonly Guid Id;
        public readonly string Title;
        public readonly Lesson[] Lessons;

        public Module(Guid id, string title, Lesson[] lessons)
        {
            Id = id;
            Title = title;
            Lessons = lessons;
        }
    }
}