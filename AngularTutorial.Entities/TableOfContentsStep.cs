using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public struct TableOfContentsStep
    {
        public readonly string Text;
        public readonly Guid Id;

        public TableOfContentsStep(Guid id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
