using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularTutorial.Entities;
using AngularTutorial.Repository;
using Microsoft.WindowsAzure.Storage.Table;

namespace AngularTutorial.Services
{
    public interface ICourseService
    {
        TableOfContents TableOfContents { get; }
        IEnumerable<Step> GetModule(string moduleName);
        void AddStep(Step step);
    }

    public class CourseService : ICourseService
    {
        static TableOfContents _tableOfContents;
        readonly IStepRepository _repository;

        public CourseService(IStepRepository repository)
        {
            _repository = repository;
        }

        public TableOfContents TableOfContents
        {
            get { return _tableOfContents ?? (_tableOfContents = GenerateTableOfContents()); }
        }
        
        public IEnumerable<Step> GetModule(string moduleName)
        {
            return _repository.GetAllInPartition(moduleName);
        }

        public void AddStep(Step step)
        {
            _repository.AddStep(step);
        }

        TableOfContents GenerateTableOfContents()
        {
            return new TableOfContents(_repository.GetTableListing());
        }
    }
}
