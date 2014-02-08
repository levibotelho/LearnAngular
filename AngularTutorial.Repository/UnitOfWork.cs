using System;
using Microsoft.ApplicationServer.Caching;

namespace AngularTutorial.Repository
{
    public interface IUnitOfWork
    {
        Guid TableOfContentsCacheKey { get; }
        DataCache Cache { get; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUnitOfWorkBootstrapper bootstrapper)
        {
            TableOfContentsCacheKey = bootstrapper.TableOfContentsCacheKey;
            Cache = new DataCacheFactory().GetDefaultCache();
        }

        public Guid TableOfContentsCacheKey { get; private set; }
        public DataCache Cache { get; private set; }
    }
}
