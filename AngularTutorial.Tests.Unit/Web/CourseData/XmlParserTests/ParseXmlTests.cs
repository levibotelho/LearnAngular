using System;
using System.Linq;
using AngularTutorial.Entities;
using AngularTutorial.Web.CourseData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AngularTutorial.Tests.Unit.Web.CourseData.XmlParserTests
{
    [TestClass]
    public class ParseXmlTests
    {
        const string XmlPath = @"Web\CourseData\XmlParserTests\Course.xml";
        static Module[] _parsedModules;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var parser = new XmlParser(XmlPath);
            _parsedModules = parser.ParseXml();
        }

        [TestMethod]
        public void GeneratesOneModulePerModuleInXml()
        {
            Assert.AreEqual(2, _parsedModules.Count());
        }

        [TestMethod]
        public void GeneratedStepIncludesId()
        {
            Assert.AreNotEqual(Guid.Empty, _parsedModules.First().Steps.First().Id);
        }

        [TestMethod]
        public void GeneratedStepIncludesTitle()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_parsedModules.First().Steps.First().Title));
        }

        [TestMethod]
        public void GeneratedStepIncludesInstructions()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_parsedModules.First().Steps.First().Instructions));
        }

        [TestMethod]
        public void GeneratedStepIncludesStartingHtml()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_parsedModules.First().Steps.First().StartingHtml));
        }

        [TestMethod]
        public void GeneratedStepIncludesSolutionHtml()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_parsedModules.First().Steps.First().SolutionHtml));
        }

        [TestMethod]
        public void GeneratedStepIncludesStartingJavaScript()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_parsedModules.First().Steps.First().StartingJavaScript));
        }

        [TestMethod]
        public void GeneratedStepIncludesSolutionJavaScript()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_parsedModules.First().Steps.First().SolutionJavaScript));
        }

        [TestMethod]
        public void GeneratedStepIncludesFrameWriteInstructions()
        {
            Assert.IsNotNull(_parsedModules.First().Steps.First().FrameWriteInstructions);
        }

        [TestMethod]
        public void GeneratedFrameWriteInstructionsIncludesStartDocument()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_parsedModules.First().Steps.First().FrameWriteInstructions.StartDocument));
        }

        [TestMethod]
        public void GeneratedFrameWriteInstructionsIncludesHeadToContent()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_parsedModules.First().Steps.First().FrameWriteInstructions.HeadToContent));
        }

        [TestMethod]
        public void GeneratedFrameWriteInstructionsIncludesContentToScript()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_parsedModules.First().Steps.First().FrameWriteInstructions.ContentToScript));
        }

        [TestMethod]
        public void GeneratedFrameWriteInstructionsIncludesEndDocument()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_parsedModules.First().Steps.First().FrameWriteInstructions.EndDocument));
        }
    }
}