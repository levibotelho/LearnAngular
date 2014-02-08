using System;
using Microsoft.ApplicationServer.Caching;

namespace AngularTutorial.Repository
{
    public interface IUnitOfWork
    {
        DataCache Cache { get; }
    }
}
