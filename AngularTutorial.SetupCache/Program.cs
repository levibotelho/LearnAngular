using System;
using System.Collections.Generic;
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
                new Module(gettingStartedId, new TranslationDictionary(new Dictionary<string, string> {{"en", "Getting Started"}})),
                new Module(continuingOnId, new TranslationDictionary(new Dictionary<string, string> {{"en", "Continuing On"}})),
            };

            var steps = new[]
            {
                new Step(gettingStarted1Id, new TranslationDictionary(new Dictionary<string, string> {{"en", "Getting Started 1"}})),
                new Step(gettingStarted2Id, new TranslationDictionary(new Dictionary<string, string> {{"en", "Getting Started 2"}})),
                new Step(gettingStarted3Id, new TranslationDictionary(new Dictionary<string, string> {{"en", "Getting Started 3"}})),
                new Step(continuingOn1Id, new TranslationDictionary(new Dictionary<string, string> {{"en", "Continuing On 1"}})),
                new Step(continuingOn2Id, new TranslationDictionary(new Dictionary<string, string> {{"en", "Continuing On 2"}})),
            };
            
            var tableOfContentsArray = new[]
            {
                new KeyValuePair<Guid, Guid[]>(gettingStartedId, new[] {gettingStarted1Id, gettingStarted2Id, gettingStarted3Id}),
                new KeyValuePair<Guid, Guid[]>(continuingOnId, new[] {continuingOn1Id, continuingOn2Id})
            };

            var tableOfContents = new TableOfContents(Guid.Parse(ConfigurationFacade.TableOfContentsCacheKey), tableOfContentsArray);

            var cache = new CacheRepository(new UnitOfWork());
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
