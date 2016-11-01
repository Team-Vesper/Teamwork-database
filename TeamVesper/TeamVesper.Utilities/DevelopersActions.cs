namespace TeamVesper.Utilities
{
    using Mappers;
    using Models;
    using MongoDB.Driver;
    using System.Collections.Generic;

    public static class DevelopersActions
    {
        public static void AddFromMongo()
        {
            var client = new MongoClient(@"mongodb://localhost");
            var dbContext = client.GetDatabase("TeamVesper");
            var devs = dbContext.GetCollection<MongoDeveloper>("Devs");
            // List<Developer> sqlDevs = MongoDeveloperCollectionsExtensions.Developers(devs);
        }
    }
}
