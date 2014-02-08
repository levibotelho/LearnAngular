using System;
using Microsoft.ApplicationServer.Caching;

namespace AngularTutorial.Repository
{
    public interface IUnitOfWork
    {
        Guid TableOfContentsCacheKey { get; }
        DataCache Cache { get; }
    }
}
