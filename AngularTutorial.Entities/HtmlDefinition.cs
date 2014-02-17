using System;

namespace AngularTutorial.Entities
{
    [Serializable]
    public class HtmlDefinition
    {
        public readonly string Header;
        public readonly string Initial;
        public readonly string Solution;
        public readonly string Footer;

        public HtmlDefinition(string header, string initial, string solution, string footer)
        {
            Header = header;
            Initial = initial;
            Solution = solution;
            Footer = footer;
        }
    }
}