using System;
using AngularTutorial.Entities;
using AngularTutorial.Repository;

namespace AngularTutorial.Services
{
    public interface ICurriculumService
    {
        TableOfContents GetTableOfContents();
    }

    public class CurriculumService
    {
        readonly Guid _tableOfContentsCacheKey;
        readonly ICacheRepository _cacheRepository;

        public CurriculumService(ICacheRepository cacheRepository, ICurriculumServiceBootstrapper bootstrapper)
        {
            _tableOfContentsCacheKey = bootstrapper.TableOfContentsCacheKey;
            _cacheRepository = cacheRepository;
        }

        public TableOfContents GetTableOfContents()
        {
            return _cacheRepository.Get<TableOfContents>(_tableOfContentsCacheKey);
        }
    }
}