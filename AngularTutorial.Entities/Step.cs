using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class Step : CacheableEntityBase
    {
        public Step() { }

        public Step(Guid id, string name)
            : base(id)
        {
            Name = name;
        }

        public string Name { get; set; }
        public string StartingHtml { get; set; }
        public string SolutionHtml { get; set; }
        public string StartingJavaScript { get; set; }
        public string SolutionJavaScript { get; set; }
        public FrameWriteInstructions FrameWriteInstructions { get; set; }
    }
}