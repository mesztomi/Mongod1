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
            var databaseUsed = client.GetDatabase("test");
            var collectionUsed = databaseUsed.GetCollection<Widget>("widgets");
            await databaseUsed.DropCollectionAsync("widgets");
            var docs = Enumerable.Range(0, 10).Select(i => new Widget {Id = i, X = i });
            await collectionUsed.InsertManyAsync(docs);

            var result = await collectionUsed.FindOneAndUpdateAsync<Widget>(
                x => x.X > 5,
                Builders<Widget>.Update.Inc(x =>x.X, 1),
                new FindOneAndUpdateOptions<Widget, Widget>
                {
                    ReturnDocument = ReturnDocument.After, //Itt módosítom, hogy azzal a doksival térjen vissza, ami a módosítás után van.
                    Sort = Builders<Widget>.Sort.Descending(x => x.X)//Itt állítom be, hogy a kollekciót honnan indítsa
                }
                );
            
            await collectionUsed.Find(new BsonDocument()).ForEachAsync(x => Console.WriteLine(x));
            
        }       
    }
}
