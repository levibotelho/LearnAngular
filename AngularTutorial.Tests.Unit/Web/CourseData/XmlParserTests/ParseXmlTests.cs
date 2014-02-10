using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using AngularTutorial.Web.CourseData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AngularTutorial.Tests.Unit.Web.CourseData.XmlParserTests
{
    [TestClass]
    public class ParseXmlTests
    {
        const string XmlPath = @"Web\CourseData\XmlParserTests\Course.xml";

        [TestMethod]
        public void GeneratesOneModulePerModuleInXml()
        {
            var parser = new XmlParser(XmlPath);
            var modules = parser.ParseXml();
            Assert.AreEqual(2, modules.Count());
        }
    }
}
