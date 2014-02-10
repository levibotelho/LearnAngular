using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using AngularTutorial.Entities;

namespace AngularTutorial.Web.CourseData
{
    public class XmlParser
    {
        const string ModuleNodeName = "Module";
        const string StepNodeName = "Step";
        const string TitleAttributeName = "Title";

        XDocument _document;

        public XmlParser(string documentPath)
        {
            _document = XDocument.Load(documentPath);
        }

        public IEnumerable<Module> ParseXml()
        {
            var moduleNodes = _document.Descendants(ModuleNodeName);
            foreach (var moduleNode in moduleNodes)
            {
                var title = moduleNode.Attribute(TitleAttributeName).Value;
                yield return new Module(title, null);
            }
        }
    }
}