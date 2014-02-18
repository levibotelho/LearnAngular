using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class JavaScriptDocument
    {
        public readonly string Name;
        public readonly string Initial;
        public readonly string Solution;

        public JavaScriptDocument(string name, string initial, string solution)
        {
            Name = name;
            Initial = initial;
            Solution = solution;
        }
    }
}