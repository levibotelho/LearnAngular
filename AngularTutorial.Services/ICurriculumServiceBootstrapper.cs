using System;

namespace AngularTutorial.Services
{
    public interface ICurriculumServiceBootstrapper
    {
        Guid TableOfContentsCacheKey { get; }
    }
}
