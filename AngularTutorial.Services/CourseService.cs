using System;
using System.Linq;
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
        readonly Guid _tableOfContentsCacheKey;
        readonly ICacheRepository _cacheRepository;

        public CourseService(ICacheRepository cacheRepository, ICourseServiceBootstrapper bootstrapper)
        {
            _tableOfContentsCacheKey = bootstrapper.TableOfContentsCacheKey;
            _cacheRepository = cacheRepository;
        }

        public TableOfContents GetTableOfContents()
        {
            return _cacheRepository.Get<TableOfContents>(_tableOfContentsCacheKey);
        }

        public Step GetStep(Guid id)
        {
            return _cacheRepository.Get<Step>(id);
        }
    }
}