using System;
using System.Linq;
using AngularTutorial.Entities;
using AngularTutorial.Web.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AngularTutorial.Tests.Unit.Web.CourseData.XmlParserTests
{
    [TestClass]
    public class ParseXmlTests
    {
        const string XmlPath = @"Web\CourseData\XmlParserTests\Course.xml";
        static Module[] _parsedModules;
        static Lesson _sparseLesson, _fullLesson, _partialLesson;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var parser = new XmlParser(XmlPath);
            _parsedModules = parser.ParseXml();
            _sparseLesson = _parsedModules[0].Lessons[0];
            _fullLesson = _parsedModules[0].Lessons[1];
            _partialLesson = _parsedModules[1].Lessons[0];
        }

        [TestMethod]
        public void GeneratesOneModulePerModuleInXml()
        {
            Assert.AreEqual(2, _parsedModules.Count());
        }

        [TestMethod]
        public void GeneratesOneLessonPerLessonInXml()
        {
            Assert.AreEqual(2, _parsedModules[0].Lessons.Length);
        }

        [TestMethod]
        public void GeneratedLessonIncludesId()
        {
            Assert.AreNotEqual(Guid.Empty, _sparseLesson.Id);
        }

        [TestMethod]
        public void GeneratedLessonIncludesTitle()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_sparseLesson.Title));
        }

        [TestMethod]
        public void GeneratedLessonIncludesInstructions()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_sparseLesson.Instructions));
        }
        
        [TestMethod]
        public void GeneratedLessonIncludesHtmlWhenPresent()
        {
            Assert.IsNotNull(_fullLesson.HtmlDocuments);
        }

        [TestMethod]
        public void GeneratedLessonDoesNotIncludeHtmlWhenNotPresent()
        {
            Assert.IsNull(_sparseLesson.HtmlDocuments);
        }

        public void GeneratedHtmlIncludesOneDocumentPerDocumentInXml()
        {
            Assert.AreEqual(2, _fullLesson.HtmlDocuments.Length);
        }

        [TestMethod]
        public void GeneratedHtmlDocumentIncludesName()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullLesson.HtmlDocuments.First().Name));
        }

        [TestMethod]
        public void GeneratedHtmlDocumentIncludesHeaderWhenPresent()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullLesson.HtmlDocuments.First().Header));
        }

        [TestMethod]
        public void GeneratedHtmlDocumentDoesNotIncludeHeaderWhenNotPresent()
        {
            Assert.IsTrue(string.IsNullOrWhiteSpace(_partialLesson.HtmlDocuments.First().Header));
        }

        [TestMethod]
        public void GeneratedHtmlDocumentIncludesFooterWhenPresent()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullLesson.HtmlDocuments.First().Footer));
        }

        [TestMethod]
        public void GeneratedHtmlDocumentDoesNotIncludeFooterWhenNotPresent()
        {
            Assert.IsTrue(string.IsNullOrWhiteSpace(_partialLesson.HtmlDocuments.First().Footer));
        }

        [TestMethod]
        public void GeneratedHtmlDocumentIncludesInitialHtml()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullLesson.HtmlDocuments.First().Initial));
        }

        [TestMethod]
        public void GeneratedHtmlDocumentIncludesSolutionHtml()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullLesson.HtmlDocuments.First().Solution));
        }

        [TestMethod]
        public void GeneratedLessonIncludesJavaScriptWhenPresent()
        {
            Assert.IsNotNull(_fullLesson.JavaScriptDocuments);
        }

        [TestMethod]
        public void GeneratedLessonDoesNotIncludeJavaScriptWhenNotPresent()
        {
            Assert.IsNull(_sparseLesson.JavaScriptDocuments);
        }
        
        [TestMethod]
        public void GeneratedJavaScriptIncludesOneDocumentPerDocumentInXml()
        {
            Assert.AreEqual(2, _fullLesson.JavaScriptDocuments.Length);
        }

        [TestMethod]
        public void GeneratedJavaScriptDocumentIncludesName()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullLesson.JavaScriptDocuments.First().Name));
        }

        [TestMethod]
        public void GeneratedJavaScriptDocumentIncludesIntialJavaScript()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullLesson.JavaScriptDocuments.First().Initial));
        }

        [TestMethod]
        public void GeneratedJavaScriptDocumentIncludesSolutionJavaScript()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(_fullLesson.JavaScriptDocuments.First().Solution));
        }

        [TestMethod]
        public void GeneratedLessonIncludesOneHeadIncludePerHeadIncludeInXml()
        {
            Assert.AreEqual(2, _fullLesson.HeadIncludes.Length);
        }

        [TestMethod]
        public void GeneratedLessonHasNoHeadIncludesWhenNotPresent()
        {
            Assert.IsNull(_sparseLesson.HeadIncludes);
        }

        [TestMethod]
        public void GeneratedLessonIncludesOneScriptIncludePerScriptIncludeInXmlPlusDefault()
        {
            Assert.AreEqual(3, _fullLesson.ScriptIncludes.Length);
        }

        [TestMethod]
        public void GeneratedLessonHasOneScriptIncludeWhenNotPresent()
        {
            Assert.AreEqual(1, _sparseLesson.ScriptIncludes.Length);
        }

        [TestMethod]
        public void AllScriptIncludesIncludeAngular()
        {
            var includes = new[] { _sparseLesson.ScriptIncludes, _fullLesson.ScriptIncludes };
            Assert.IsTrue(includes.All(x => x.Any(y => y.Contains("angularjs"))));
        }

        [TestMethod]
        public void DefaultScriptIncludesAreInScriptTag()
        {
            var includes = _sparseLesson.ScriptIncludes;
            Assert.IsTrue(includes.All(x => x.StartsWith("<script")));
        }

        [TestMethod]
        public void DefaultScriptIncludesEndWithScriptClosingTag()
        {
            var includes = _sparseLesson.ScriptIncludes;
            Assert.IsTrue(includes.All(x => x.EndsWith("</script>")));
        }
    }
}