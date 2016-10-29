using MongoDB.Driver;
using System;
using TeamVesper.Models;

namespace TeamVesper.MongoDbData
{
    public class MongoConnector<TEntity>
        where TEntity : MongoDeveloper
    {
        private IMongoClient client;
        private IMongoDatabase dbContext;
        private IMongoCollection<TEntity> dbSet;

        public MongoConnector(string connectionString = @"mongodb://localhost",
                                string databaseName = "TeamVesper",
                                string collectionName = "Devs")
        {
            this.Client = new MongoClient(connectionString);
            this.DbContext = this.client.GetDatabase(databaseName);
            this.Dbset = dbContext.GetCollection<TEntity>(collectionName);
        }

        public IMongoClient Client
        {
            get
            {
                return this.client;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Mongo client");
                }

                this.client = value;
            }
        }

        public IMongoDatabase DbContext
        {
            get
            {
                return this.dbContext;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Mongo database");
                }

                this.dbContext = value;
            }
        }

        public IMongoCollection<TEntity> Dbset
        {
            get
            {
                return this.dbSet;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Mongo collection");
                }

                this.dbSet = value;
            }
        }
    }
}
