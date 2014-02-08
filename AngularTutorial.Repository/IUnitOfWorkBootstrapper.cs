using System;

namespace AngularTutorial.Repository
{
    public interface IUnitOfWorkBootstrapper
    {
        Guid TableOfContentsCacheKey { get; }
    }
}
