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
using Mongod.src;

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
            var databaseUsed = client.GetDatabase("students");
            var collectionUsed = databaseUsed.GetCollection<BsonDocument>("grades");
            
            
            

            var result = collectionUsed.BulkWriteAsync(new WriteModel<BsonDocument>[]
            {
                new DeleteOneModel<BsonDocument>("{x : 5}"),
                new UpdateManyModel<BsonDocument>("{x: {$lt : 5}}", "{$inc: {x : 2}}")
            });
            
            await collectionUsed.Find(new BsonDocument()).ForEachAsync(x => Console.WriteLine(x));
            
        }       
    }
}
