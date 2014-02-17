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
        static Step _sparseStep, _fullStep, _partialStep;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var parser = new XmlParser(XmlPath);
            _parsedModules = parser.ParseXml();
            _sparseStep = _parsedModules[0].Steps[0];
            _fullStep = _parsedModules[0].Steps[1];
            _partialStep = _parsedModules[1].Steps[0];
        }

        [TestMethod]
        public void GeneratesOneModulePerModuleInXml()
        {
            Assert.AreEqual(2, _parsedModules.Count());
        }

        [TestMethod]
        public void GeneratesOneStepPerStepInXml()
        {
            Assert.AreEqual(2, _parsedModules[0].Steps.Length);
        }

        [TestMethod]
        public void GeneratedStepIncludesId()
        {
            Assert.AreNotEqual(Guid.Empty, _sparseStep.Id);
        }

        [TestMethod]
        public void GeneratedStepIncludesTitle()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_sparseStep.Title));
        }

        [TestMethod]
        public void GeneratedStepIncludesInstructions()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_sparseStep.Instructions));
        }
        
        [TestMethod]
        public void GeneratedStepIncludesHtmlWhenPresent()
        {
            Assert.IsNotNull(_fullStep.Html);
        }

        [TestMethod]
        public void GeneratedStepDoesNotIncludeHtmlWhenNotPresent()
        {
            Assert.IsNull(_sparseStep.Html);
        }

        [TestMethod]
        public void GeneratedStepIncludesHtmlHeaderWhenPresent()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullStep.Html.Header));
        }

        [TestMethod]
        public void GeneratedStepDoesNotIncludeHtmlHeaderWhenNotPresent()
        {
            Assert.IsTrue(string.IsNullOrWhiteSpace(_partialStep.Html.Header));
        }

        [TestMethod]
        public void GeneratedStepIncludesHtmlFooterWhenPresent()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullStep.Html.Footer));
        }

        [TestMethod]
        public void GeneratedStepDoesNotIncludeHtmlFooterWhenNotPresent()
        {
            Assert.IsTrue(string.IsNullOrWhiteSpace(_partialStep.Html.Footer));
        }

        [TestMethod]
        public void GeneratedHtmlIncludesInitialHtml()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullStep.Html.Initial));
        }

        [TestMethod]
        public void GeneratedHtmlIncludesSolutionHtml()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullStep.Html.Initial));
        }

        [TestMethod]
        public void GeneratedStepIncludesJavaScriptWhenPresent()
        {
            Assert.IsNotNull(_fullStep.JavaScript);
        }

        [TestMethod]
        public void GeneratedStepDoesNotIncludeJavaScriptWhenNotPresent()
        {
            Assert.IsNull(_sparseStep.JavaScript);
        }
        
        [TestMethod]
        public void GeneratedJavaScriptIncludesOnePagePerPageInXml()
        {
            Assert.AreEqual(2, _fullStep.JavaScript.Pages.Count);
        }

        [TestMethod]
        public void GeneratedJavaScriptPageIncludesName()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullStep.JavaScript.Pages.ElementAt(0).Name));
        }

        [TestMethod]
        public void GeneratedJavaScriptPageIncludesIntialJavaScript()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullStep.JavaScript.Pages.ElementAt(0).Initial));
        }

        [TestMethod]
        public void GeneratedJavaScriptPageIncludesSolutionJavaScript()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullStep.JavaScript.Pages.ElementAt(0).Solution));
        }

        [TestMethod]
        public void GeneratedStepIncludesOneHeadIncludePerHeadIncludeInXml()
        {
            Assert.AreEqual(2, _fullStep.HeadIncludes.Length);
        }

        [TestMethod]
        public void GeneratedStepHasNoHeadIncludesWhenNotPresent()
        {
            Assert.IsNull(_sparseStep.HeadIncludes);
        }

        [TestMethod]
        public void GeneratedStepIncludesOneScriptIncludePerScriptIncludeInXml()
        {
            Assert.AreEqual(2, _fullStep.ScriptIncludes.Length);
        }

        [TestMethod]
        public void GeneratedStepHasNoScriptIncludesWhenNotPresent()
        {
            Assert.IsNull(_sparseStep.ScriptIncludes);
        }
    }
}