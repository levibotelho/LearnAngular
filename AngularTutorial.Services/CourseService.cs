using System;
using AngularTutorial.Entities;
using AngularTutorial.Repository;

namespace AngularTutorial.Services
{
    public interface ICourseService
    {
        TableOfContents GetTableOfContents();
        Lesson GetLesson(string id);
    }

    public class CourseService : ICourseService
    {
        public static readonly string TableOfContentsKey = "table-of-contents";

        readonly ICacheRepository _cacheRepository;

        public CourseService(ICacheRepository cacheRepository)
        {
            _cacheRepository = cacheRepository;
        }

        public TableOfContents GetTableOfContents()
        {
            // By convention, the table of contents is always located at Guid.Empty.
            return _cacheRepository.Get<TableOfContents>(TableOfContentsKey);
        }

        public Lesson GetLesson(string id)
        {
            return _cacheRepository.Get<Lesson>(id);
        }
    }
}