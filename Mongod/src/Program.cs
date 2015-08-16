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
            var collectionUsed = databaseUsed.GetCollection<Person>("people");

            var builder = Builders<Person>.Filter;
            var filter = builder.Lt(x => x.Age, 30) & builder.Eq(x => x.Name, "Peter");

            var list = await collectionUsed.Find(filter).ToListAsync();

            foreach (var doc in list)
            {
                Console.WriteLine(doc);
            }           
            
        }

       
        
    }
}
