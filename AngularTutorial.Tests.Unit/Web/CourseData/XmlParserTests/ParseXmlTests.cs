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
            Assert.IsNotNull(_fullStep.HtmlDocuments);
        }

        [TestMethod]
        public void GeneratedStepDoesNotIncludeHtmlWhenNotPresent()
        {
            Assert.IsNull(_sparseStep.HtmlDocuments);
        }

        public void GeneratedHtmlIncludesOneDocumentPerDocumentInXml()
        {
            Assert.AreEqual(2, _fullStep.HtmlDocuments.Length);
        }

        [TestMethod]
        public void GeneratedHtmlDocumentIncludesName()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullStep.HtmlDocuments.First().Name));
        }

        [TestMethod]
        public void GeneratedHtmlDocumentIncludesHeaderWhenPresent()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullStep.HtmlDocuments.First().Header));
        }

        [TestMethod]
        public void GeneratedHtmlDocumentDoesNotIncludeHeaderWhenNotPresent()
        {
            Assert.IsTrue(string.IsNullOrWhiteSpace(_partialStep.HtmlDocuments.First().Header));
        }

        [TestMethod]
        public void GeneratedHtmlDocumentIncludesFooterWhenPresent()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullStep.HtmlDocuments.First().Footer));
        }

        [TestMethod]
        public void GeneratedHtmlDocumentDoesNotIncludeFooterWhenNotPresent()
        {
            Assert.IsTrue(string.IsNullOrWhiteSpace(_partialStep.HtmlDocuments.First().Footer));
        }

        [TestMethod]
        public void GeneratedHtmlDocumentIncludesInitialHtml()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullStep.HtmlDocuments.First().Initial));
        }

        [TestMethod]
        public void GeneratedHtmlDocumentIncludesSolutionHtml()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullStep.HtmlDocuments.First().Solution));
        }

        [TestMethod]
        public void GeneratedStepIncludesJavaScriptWhenPresent()
        {
            Assert.IsNotNull(_fullStep.JavaScriptDocuments);
        }

        [TestMethod]
        public void GeneratedStepDoesNotIncludeJavaScriptWhenNotPresent()
        {
            Assert.IsNull(_sparseStep.JavaScriptDocuments);
        }
        
        [TestMethod]
        public void GeneratedJavaScriptIncludesOneDocumentPerDocumentInXml()
        {
            Assert.AreEqual(2, _fullStep.JavaScriptDocuments.Length);
        }

        [TestMethod]
        public void GeneratedJavaScriptDocumentIncludesName()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullStep.JavaScriptDocuments.First().Name));
        }

        [TestMethod]
        public void GeneratedJavaScriptDocumentIncludesIntialJavaScript()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullStep.JavaScriptDocuments.First().Initial));
        }

        [TestMethod]
        public void GeneratedJavaScriptDocumentIncludesSolutionJavaScript()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullStep.JavaScriptDocuments.First().Solution));
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