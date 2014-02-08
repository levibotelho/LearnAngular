using System;
using System.Linq;
using AngularTutorial.Entities;
using AngularTutorial.Repository;

namespace AngularTutorial.Services
{
    public interface ICurriculumService
    {
        TableOfContents GetTableOfContents();
        string[] GetModuleNames(string languageCode);
    }

    public class CurriculumService : ICurriculumService
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

        public string[] GetModuleNames(string languageCode)
        {
            return GetTableOfContents().Modules.Select(moduleId => _cacheRepository.Get<Module>(moduleId).GetName(languageCode)).ToArray();
        }
    }
}