using System;
using System.Linq;
using System.Xml.Linq;
using AngularTutorial.Entities;

namespace AngularTutorial.Web.CourseData
{
    public class XmlParser
    {
        static readonly XNamespace Namespace = "http://angulartutorial.azurewebsites.net/Course.xsd";

        static readonly XName InstructionsNodeName = Namespace + "Instructions";
        static readonly XName HtmlNodeName = Namespace + "Html";
        static readonly XName JavaScriptNodeName = Namespace + "JavaScript";

        static readonly XName HeaderNodeName = Namespace + "Header";
        static readonly XName InitialNodeName = Namespace + "Initial";
        static readonly XName SolutionNodeName = Namespace + "Solution";
        static readonly XName FooterNodeName = Namespace + "Footer";

        static readonly XName PageNodeName = Namespace + "Page";

        static readonly XName HeadIncludesNodeName = Namespace + "HeadIncludes";
        static readonly XName ScriptIncludesNodeName = Namespace + "ScriptIncludes";

        static readonly XName IncludeNodeName = Namespace + "Include";

        static readonly XName IdAttributeName = "Id";
        static readonly XName TitleAttributeName = "Title";
        static readonly XName NameAttributeName = "Name";

        readonly XDocument _document;

        public XmlParser(string documentPath)
        {
            _document = XDocument.Load(documentPath);
        }

        public Module[] ParseXml()
        {
            // ReSharper disable PossibleNullReferenceException
            return _document.Root.Elements().Select(GenerateModule).ToArray();
            // ReSharper restore PossibleNullReferenceException
        }

        static Module GenerateModule(XElement moduleNode)
        {
            var id = Guid.Parse(moduleNode.Attribute(IdAttributeName).Value);
            var title = moduleNode.Attribute(TitleAttributeName).Value;
            var steps = moduleNode.Elements().Select(GenerateStep).ToArray();
            return new Module(id, title, steps);
        }

        static Step GenerateStep(XElement stepNode)
        {
            // ReSharper disable PossibleNullReferenceException
            var id = Guid.Parse(stepNode.Attribute(IdAttributeName).Value);
            var title = stepNode.Attribute(TitleAttributeName).Value;
            return new Step(id, title)
            {
                Instructions = GetValueFromElement(stepNode.Element(InstructionsNodeName)),
                Html = GenerateHtmlDefinition(stepNode.Element(HtmlNodeName)),
                JavaScript = GenerateJavaScriptDefinition(stepNode.Element(JavaScriptNodeName)),
                HeadIncludes = GenerateIncludes(stepNode.Element(HeadIncludesNodeName)),
                ScriptIncludes = GenerateIncludes(stepNode.Element(ScriptIncludesNodeName))
            };
            // ReSharper restore PossibleNullReferenceException
        }

        static HtmlDefinition GenerateHtmlDefinition(XContainer element)
        {
            if (element == null)
                return null;

            var header = GetValueFromElement(element.Element(HeaderNodeName));
            var initial = GetValueFromElement(element.Element(InitialNodeName));
            var solution = GetValueFromElement(element.Element(SolutionNodeName));
            var footer = GetValueFromElement(element.Element(FooterNodeName));

            return new HtmlDefinition(header, initial, solution, footer);
        }

        static JavaScriptDefinition GenerateJavaScriptDefinition(XContainer element)
        {
            if (element == null)
                return null;

            var pages = element.Elements(PageNodeName).Select(GenerateJavaScriptPage).ToArray();
            return new JavaScriptDefinition(pages);
        }

        static JavaScriptPage GenerateJavaScriptPage(XElement element)
        {
            var name = element.Attribute(NameAttributeName).Value;
            var initial = GetValueFromElement(element.Element(InitialNodeName));
            var solution = GetValueFromElement(element.Element(SolutionNodeName));
            return new JavaScriptPage(name, initial, solution);
        }

        static string[] GenerateIncludes(XContainer element)
        {
            return element != null ? element.Elements(IncludeNodeName).Select(GetValueFromElement).ToArray() : null;
        }

        static string GetValueFromElement(XElement element)
        {
            return element != null ? element.Value.Trim() : null;
        }
    }
}