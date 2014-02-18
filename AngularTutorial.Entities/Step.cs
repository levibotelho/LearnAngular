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
        public HtmlDocument[] HtmlDocuments { get; set; }
        public JavaScriptDocument[] JavaScriptDocuments { get; set; }
        public string[] HeadIncludes { get; set; }
        public string[] ScriptIncludes { get; set; }
    }
}