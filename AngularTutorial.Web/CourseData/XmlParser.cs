using System;
using System.Linq;
using System.Xml.Linq;
using AngularTutorial.Entities;
using MarkdownSharp;

namespace AngularTutorial.Web.CourseData
{
    public class XmlParser
    {
        static readonly string[] DefaultIncludes =
        {
            "<script src=\"//ajax.googleapis.com/ajax/libs/angularjs/1.2.12/angular.min.js\"></script>"
        };

        static readonly XNamespace Namespace = "http://angulartutorial.azurewebsites.net/Course.xsd";

        static readonly XName InstructionsNodeName = Namespace + "Instructions";
        static readonly XName HtmlNodeName = Namespace + "Html";
        static readonly XName JavaScriptNodeName = Namespace + "JavaScript";

        static readonly XName HeaderNodeName = Namespace + "Header";
        static readonly XName InitialNodeName = Namespace + "Initial";
        static readonly XName SolutionNodeName = Namespace + "Solution";
        static readonly XName FooterNodeName = Namespace + "Footer";

        static readonly XName DocumentNodeName = Namespace + "Document";

        static readonly XName HeadIncludesNodeName = Namespace + "HeadIncludes";
        static readonly XName ScriptIncludesNodeName = Namespace + "ScriptIncludes";

        static readonly XName IncludeNodeName = Namespace + "Include";

        static readonly XName IdAttributeName = "Id";
        static readonly XName TitleAttributeName = "Title";
        static readonly XName NameAttributeName = "Name";
        
        static readonly Markdown MarkdownEngine = new Markdown();

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
            var lessons = moduleNode.Elements().Select(x => GenerateLesson(x, id)).ToArray();
            return new Module(id, title, lessons);
        }

        static Lesson GenerateLesson(XElement lessonNode, Guid moduleId)
        {
            // ReSharper disable PossibleNullReferenceException
            var id = Guid.Parse(lessonNode.Attribute(IdAttributeName).Value);
            var title = lessonNode.Attribute(TitleAttributeName).Value;
            return new Lesson(id, title)
            {
                ModuleId = moduleId,
                Instructions = GenerateInstructions(lessonNode.Element(InstructionsNodeName)),
                HtmlDocuments = GenerateHtmlDocuments(lessonNode.Element(HtmlNodeName)),
                JavaScriptDocuments = GenerateJavaScriptDocuments(lessonNode.Element(JavaScriptNodeName)),
                HeadIncludes = GenerateHeadIncludes(lessonNode.Element(HeadIncludesNodeName)),
                ScriptIncludes = GenerateScriptIncludes(lessonNode.Element(ScriptIncludesNodeName))
            };
            // ReSharper restore PossibleNullReferenceException
        }

        static string GenerateInstructions(XElement instructionsNode)
        {
            var markdown = GetValueFromElement(instructionsNode);
            return MarkdownEngine.Transform(markdown);
        }

        static HtmlDocument[] GenerateHtmlDocuments(XContainer element)
        {
            if (element == null)
                return null;

            return element.Elements(DocumentNodeName).Select(GenerateHtmlDocument).ToArray();
        }

        static HtmlDocument GenerateHtmlDocument(XElement element)
        {
            var name = element.Attribute(NameAttributeName).Value;
            var header = GetValueFromElement(element.Element(HeaderNodeName));
            var initial = GetValueFromElement(element.Element(InitialNodeName));
            var solution = GetValueFromElement(element.Element(SolutionNodeName));
            var footer = GetValueFromElement(element.Element(FooterNodeName));

            return new HtmlDocument(name, header, initial, solution, footer);
        }

        static JavaScriptDocument[] GenerateJavaScriptDocuments(XContainer element)
        {
            if (element == null)
                return null;

            return element.Elements(DocumentNodeName).Select(GenerateJavaScriptDocument).ToArray();
        }
        
        static JavaScriptDocument GenerateJavaScriptDocument(XElement element)
        {
            var name = element.Attribute(NameAttributeName).Value;
            var initial = GetValueFromElement(element.Element(InitialNodeName));
            var solution = GetValueFromElement(element.Element(SolutionNodeName));
            return new JavaScriptDocument(name, initial, solution);
        }

        static string[] GenerateHeadIncludes(XContainer element)
        {
            return element != null ? element.Elements(IncludeNodeName).Select(GetValueFromElement).ToArray() : null;
        }

        static string[] GenerateScriptIncludes(XContainer element)
        {
            return element != null ? element.Elements(IncludeNodeName).Select(GetValueFromElement).Concat(DefaultIncludes).ToArray() : DefaultIncludes;
        }

        static string GetValueFromElement(XElement element)
        {
            return element != null ? element.Value.Trim() : string.Empty;
        }
    }
}