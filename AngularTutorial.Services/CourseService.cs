using System;
using AngularTutorial.Entities;
using AngularTutorial.Repository;

namespace AngularTutorial.Services
{
    public interface ICourseService
    {
        TableOfContents GetTableOfContents();
        Step GetStep(Guid id);
    }

    public class CourseService : ICourseService
    {
        readonly ICacheRepository _cacheRepository;

        public CourseService(ICacheRepository cacheRepository)
        {
            _cacheRepository = cacheRepository;
        }

        public TableOfContents GetTableOfContents()
        {
            // By convention, the table of contents is always located at Guid.Empty.
            return _cacheRepository.Get<TableOfContents>(Guid.Empty);
        }

        public Step GetStep(Guid id)
        {
            return _cacheRepository.Get<Step>(id);
        }
    }
}