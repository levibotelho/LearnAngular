using System;

namespace AngularTutorial.Services
{
    public interface ICourseServiceBootstrapper
    {
        Guid TableOfContentsCacheKey { get; }
    }
}
