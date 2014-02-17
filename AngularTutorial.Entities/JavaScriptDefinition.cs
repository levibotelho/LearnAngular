using System.Collections.Generic;

namespace AngularTutorial.Entities
{
    public class JavaScriptDefinition
    {
        public readonly IReadOnlyCollection<JavaScriptPage> Pages;

        public JavaScriptDefinition(IReadOnlyCollection<JavaScriptPage> javaScriptPages)
        {
            Pages = javaScriptPages;
        }
    }
}
