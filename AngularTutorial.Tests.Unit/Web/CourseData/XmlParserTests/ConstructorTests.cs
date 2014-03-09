using System;
using System.IO;
using AngularTutorial.Web.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AngularTutorial.Tests.Unit.Web.CourseData.XmlParserTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void LoadsCorrectlyWhenFileExists()
        {
            var parser = new XmlParser(@"Web\CourseData\XmlParserTests\Course.xml");
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ThrowsFileNotFoundExceptionWhenFileDoesNotExist()
        {
            var parser = new XmlParser(@"Web\CourseData\XmlParserTests\DoesNotExist.xml");
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void ThrowsFileNotFoundExceptionWhenDirectoryDoesNotExist()
        {
            var parser = new XmlParser(@"Web\CourseData\DoesNotExist\DoesNotExist.xml");
        }
    }
}
