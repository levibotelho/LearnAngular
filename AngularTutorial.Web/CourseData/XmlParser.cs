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
        const string InstructionsNodeName = "Instructions";
        const string StartingHtmlNodeName = "StartingHtml";
        const string SolutionHtmlNodeName = "SolutionHtml";
        const string StartingJavaScriptNodeName = "StartingJavaScript";
        const string SolutionJavaScriptNodeName = "SolutionJavaScript";
        const string FrameWriteInstructionsNodeName = "FrameWriteInstructions";
        const string TitleAttributeName = "Title";

        static readonly XNamespace XmlNamespace = "http://angulartutorial.azurewebsites.net/Course.xsd";

        XDocument _document;

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
            return new Step
            {
                Title = stepNode.Attribute(TitleAttributeName).Value,
                Instructions = stepNode.Element(InstructionsNodeName).Value,
                StartingHtml = stepNode.Element(StartingHtmlNodeName).Value,
                SolutionHtml = stepNode.Element(SolutionHtmlNodeName).Value,
                StartingJavaScript = stepNode.Element(StartingJavaScriptNodeName).Value,
                SolutionJavaScript = stepNode.Element(SolutionJavaScriptNodeName).Value,
                FrameWriteInstructions = GenerateFrameWriteInstructionsFromElement(stepNode.Element(FrameWriteInstructionsNodeName))
            };
            // ReSharper restore PossibleNullReferenceException
        }

        FrameWriteInstructions GenerateFrameWriteInstructionsFromElement(XElement frameWriteInstructionsNode)
        {
            return null;
        }
    }
}