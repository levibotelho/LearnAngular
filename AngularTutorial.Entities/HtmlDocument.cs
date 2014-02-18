using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class HtmlDocument
    {
        public readonly string Header;
        public readonly string Initial;
        public readonly string Solution;
        public readonly string Footer;
        public readonly string Name;

        public HtmlDocument(string name, string header, string initial, string solution, string footer)
        {
            Name = name;
            Header = header;
            Initial = initial;
            Solution = solution;
            Footer = footer;
        }
    }
}