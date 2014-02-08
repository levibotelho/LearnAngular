using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class Step : CacheableEntityBase
    {
        readonly TranslationDictionary _name;

        public Step() { }

        public Step(Guid id, TranslationDictionary name)
            : base(id)
        {
            _name = name;
        }

        public string StartingHtml { get; set; }
        public string SolutionHtml { get; set; }
        public string StartingJavaScript { get; set; }
        public string SolutionJavaScript { get; set; }
        public FrameWriteInstructions FrameWriteInstructions { get; set; }

        public string GetName(string languageCode)
        {
            return _name[languageCode];
        }
    }
}