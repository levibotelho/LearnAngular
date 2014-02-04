using System;
using AngularTutorial.Entities;
using AngularTutorial.Repository;
using AngularTutorial.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AngularTutorial.UnitTests
{
    [TestClass]
    public class Jobs
    {
        [TestMethod]
        public void CreateStorageContainer()
        {
            var bootstrapper = new TestUnitOfWorkBootstrapper();
            var storageAccount = CloudStorageAccount.Parse(bootstrapper.ConnectionString);
            storageAccount.CreateCloudTableClient().GetTableReference(bootstrapper.CourseRepositoryTableName).CreateIfNotExists();
        }

        [TestMethod]
        public void AddSteps()
        {
            var steps = new[]
            {
                new Step
                {
                    ModuleName = "Getting Started",
                    Name = "Adding the ng attributes",
                    StartingHtml = "",
                    SolutionHtml = "",
                    StartingJavaScript = "",
                    SolutionJavaScript = "",
                    FrameWriteInstructions = new FrameWriteInstructions()
                },
                new Step
                {
                    ModuleName = "Getting Started",
                    Name = "Adding a calculated value",
                    StartingHtml = "",
                    SolutionHtml = "",
                    StartingJavaScript = "",
                    SolutionJavaScript = "",
                    FrameWriteInstructions = new FrameWriteInstructions()
                },
                new Step
                {
                    ModuleName = "Getting Started",
                    Name = "Adding a data binding",
                    StartingHtml = "",
                    SolutionHtml = "",
                    StartingJavaScript = "",
                    SolutionJavaScript = "",
                    FrameWriteInstructions = new FrameWriteInstructions()
                }
            };
            
            var service = new CourseService(new CourseRepository(new UnitOfWork(new TestUnitOfWorkBootstrapper())));
            foreach (var step in steps)
            {
                service.AddStep(step);
            }
        }
    }

    class TestUnitOfWorkBootstrapper : IUnitOfWorkBootstrapper
    {
        public TestUnitOfWorkBootstrapper()
        {
            ConnectionString = "DefaultEndpointsProtocol=https;AccountName=angulartutorial;AccountKey=2D5YqjhocOtz7HAAXHvmiDBkOw303dhsOPjmph0G7wwPfe0rdmYOtPknwwG5RuWosxyJ1HS+ea1PugjVj/VgIw==";
            CourseRepositoryTableName = "Steps";
        }

        public string ConnectionString { get; private set; }
        public string CourseRepositoryTableName { get; private set; }
    }
}
