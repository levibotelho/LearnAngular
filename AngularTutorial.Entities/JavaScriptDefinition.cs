using System;
using System.Collections.Generic;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class JavaScriptDefinition
    {
        public readonly IReadOnlyCollection<JavaScriptPage> Pages;

        public JavaScriptDefinition(IReadOnlyCollection<JavaScriptPage> javaScriptPages)
        {
            Pages = javaScriptPages;
        }
    }
}
