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
            MainAsync(args).Wait();            
            Console.WriteLine("Press Enter!");
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var databaseUsed = client.GetDatabase("test");
            var collectionUsed = databaseUsed.GetCollection<BsonDocument>("people");

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Lt("Age", 30) & builder.Eq("Name", "Peter");

            var list = await collectionUsed.Find(filter).ToListAsync();

            foreach (var doc in list)
            {
                Console.WriteLine(doc);
            }

            //await collectionUsed.Find(new BsonDocument()).ForEachAsync(doc => Console.WriteLine(doc));          
            
        }

       
        
    }
}
