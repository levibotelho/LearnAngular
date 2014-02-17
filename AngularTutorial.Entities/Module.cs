using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class Module
    {
        public readonly Guid Id;
        public readonly string Title;
        public readonly Step[] Steps;

        public Module(Guid id, string title, Step[] steps)
        {
            Id = id;
            Title = title;
            Steps = steps;
        }
    }
}