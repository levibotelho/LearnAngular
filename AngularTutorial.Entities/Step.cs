using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class Step : CacheableEntityBase
    {
        public Step(Guid id, string title)
            : base(id)
        {
            Title = title;
        }

        public string Title { get; set; }
        public string Instructions { get; set; }
        public string StartingHtml { get; set; }
        public string SolutionHtml { get; set; }
        public string StartingJavaScript { get; set; }
        public string SolutionJavaScript { get; set; }
        public FrameWriteInstructions FrameWriteInstructions { get; set; }
    }
}