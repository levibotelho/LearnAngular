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
    public class CourseService
    {
        static TableOfContents _tableOfContents;
        ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public TableOfContents TableOfContents
        {
            get { return _tableOfContents ?? (_tableOfContents = GenerateTableOfContents()); }
        }

        TableOfContents GenerateTableOfContents()
        {
            var listing = _repository.GetTableListing();
            return new TableOfContents(_repository.GetTableListing());
        }
        
        public IEnumerable<Step> GetModule(string moduleName)
        {
            return _repository.GetAllInPartition(moduleName);
        }

        public void AddStep(Step step)
        {
            _repository.AddStep(step);
        }
    }
}
