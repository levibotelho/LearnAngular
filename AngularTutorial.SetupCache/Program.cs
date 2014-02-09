using System;
using System.Collections.Generic;
using System.Linq;
using AngularTutorial.Entities;
using AngularTutorial.Repository;

namespace AngularTutorial.SetupCache
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid gettingStartedId = Guid.NewGuid(), continuingOnId = Guid.NewGuid(), gettingStarted1Id = Guid.NewGuid(),
                gettingStarted2Id = Guid.NewGuid(), gettingStarted3Id = Guid.NewGuid(), continuingOn1Id = Guid.NewGuid(),
                continuingOn2Id = Guid.NewGuid();

            var modules = new[]
            {
                new Module(gettingStartedId, new Translation<string>(new Dictionary<Language, string> {{Language.English, "Getting Started"}})),
                new Module(continuingOnId, new Translation<string>(new Dictionary<Language, string> {{Language.English, "Continuing On"}})),
            };

            var moduleNamesDictionary = new Dictionary<Language, string[]> {{Language.English, modules.Select(x => x.GetName(Language.English)).ToArray()}};
            var moduleNames = new Translation<string[]>(moduleNamesDictionary);

            var steps = new[]
            {
                new Step(gettingStarted1Id, new Translation<string>(new Dictionary<Language, string> {{Language.English, "Getting Started 1"}})),
                new Step(gettingStarted2Id, new Translation<string>(new Dictionary<Language, string> {{Language.English, "Getting Started 2"}})),
                new Step(gettingStarted3Id, new Translation<string>(new Dictionary<Language, string> {{Language.English, "Getting Started 3"}})),
                new Step(continuingOn1Id, new Translation<string>(new Dictionary<Language, string> {{Language.English, "Continuing On 1"}})),
                new Step(continuingOn2Id, new Translation<string>(new Dictionary<Language, string> {{Language.English, "Continuing On 2"}})),
            };
            
            var tableOfContentsArray = new[]
            {
                new KeyValuePair<Guid, Guid[]>(gettingStartedId, new[] {gettingStarted1Id, gettingStarted2Id, gettingStarted3Id}),
                new KeyValuePair<Guid, Guid[]>(continuingOnId, new[] {continuingOn1Id, continuingOn2Id})
            };

            var tableOfContents = new TableOfContents(Guid.Parse(ConfigurationFacade.TableOfContentsCacheKey), tableOfContentsArray, moduleNames);

            var cache = new CacheRepository(new UnitOfWork());
            cache.Clear();
            AddCollection(modules, cache);
            AddCollection(steps, cache);
            Add(tableOfContents, cache);
        }

        static void Add(CacheableEntityBase entity, ICacheRepository cache)
        {
            cache.Put(entity.Id, entity);
        }

        static void AddCollection(IEnumerable<CacheableEntityBase> collection, ICacheRepository cache)
        {
            foreach (var entity in collection)
                cache.Put(entity.Id, entity);
        }
    }
}
