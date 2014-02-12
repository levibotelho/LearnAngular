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
        static readonly XName StartingHtmlNodeName = Namespace + "StartingHtml";
        static readonly XName SolutionHtmlNodeName = Namespace + "SolutionHtml";
        static readonly XName StartingJavaScriptNodeName = Namespace + "StartingJavaScript";
        static readonly XName SolutionJavaScriptNodeName = Namespace + "SolutionJavaScript";
        static readonly XName FrameWriteInstructionsNodeName = Namespace + "FrameWriteInstructions";
        
        static readonly XName StartDocumentNodeName = Namespace + "StartDocument";
        static readonly XName HeadToContentNodeName = Namespace + "HeadToContent";
        static readonly XName ContentToScriptName = Namespace + "ContentToScript";
        static readonly XName EndDocumentNodeName = Namespace + "EndDocument";

        static readonly XName TitleAttributeName = "Title";

        readonly XDocument _document;

        public XmlParser(string documentPath)
        {
            _document = XDocument.Load(documentPath);
        }

        public Module[] ParseXml()
        {
            // ReSharper disable PossibleNullReferenceException
            return _document.Root.Elements().Select(GenerateModuleFromXElement).ToArray();
            // ReSharper restore PossibleNullReferenceException
        }

        Module GenerateModuleFromXElement(XElement moduleNode)
        {
            var title = moduleNode.Attribute(TitleAttributeName).Value;
            var steps = moduleNode.Elements().Select(GenerateStepFromXElement).ToArray();
            return new Module(title, steps);
        }

        Step GenerateStepFromXElement(XElement stepNode)
        {
            // ReSharper disable PossibleNullReferenceException
            return new Step(Guid.NewGuid(), stepNode.Attribute(TitleAttributeName).Value)
            {
                Instructions = GetValueFromElement(stepNode.Element(InstructionsNodeName)),
                StartingHtml = GetValueFromElement(stepNode.Element(StartingHtmlNodeName)),
                SolutionHtml = GetValueFromElement(stepNode.Element(SolutionHtmlNodeName)),
                StartingJavaScript = GetValueFromElement(stepNode.Element(StartingJavaScriptNodeName)),
                SolutionJavaScript = GetValueFromElement(stepNode.Element(SolutionJavaScriptNodeName)),
                FrameWriteInstructions = GenerateFrameWriteInstructionsFromElement(stepNode.Element(FrameWriteInstructionsNodeName))
            };
            // ReSharper restore PossibleNullReferenceException
        }

        FrameWriteInstructions GenerateFrameWriteInstructionsFromElement(XElement frameWriteInstructionsNode)
        {
            // ReSharper disable PossibleNullReferenceException
            return new FrameWriteInstructions
            {
                StartDocument = GetValueFromElement(frameWriteInstructionsNode.Element(StartDocumentNodeName)),
                HeadToContent = GetValueFromElement(frameWriteInstructionsNode.Element(HeadToContentNodeName)),
                ContentToScript = GetValueFromElement(frameWriteInstructionsNode.Element(ContentToScriptName)),
                EndDocument = GetValueFromElement(frameWriteInstructionsNode.Element(EndDocumentNodeName))
            };
            // ReSharper restore PossibleNullReferenceException
        }

        static string GetValueFromElement(XElement element)
        {
            return element.Value.Trim();
        }
    }
}