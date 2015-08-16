using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

namespace Mongod
{
    class Program
    {
        
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            
            Console.WriteLine("Press Enter!");
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var databaseUsed = client.GetDatabase("test");
            var collectionUsed = databaseUsed.GetCollection<BsonDocument>("widgets");
            await databaseUsed.DropCollectionAsync("widgets");

            var docs = Enumerable.Range(0, 10).Select(i => new BsonDocument("_id", i).Add("x", i));

            await collectionUsed.InsertManyAsync(docs);

            var result = await collectionUsed.ReplaceOneAsync(
                new BsonDocument("_id", 5), 
                new BsonDocument("_id", 5).Add("x", 30));

            await collectionUsed.Find(new BsonDocument()).ForEachAsync(x => Console.WriteLine(x));
            
        }

       
        
    }
}
