using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongod.src
{
    class PlaceholderProbalkozasok
    {
        static async Task BsonDocMethod()
        {
            var doc = new BsonDocument
            {
                {"name", "Sanya" }

            };

            doc.Add("age", 30);

            doc["profession"] = "hacker";

            var nestedArray = new BsonArray();

            nestedArray.Add(new BsonDocument("color", "red"));

            doc.Add("array", nestedArray);

            Console.WriteLine(1);
            //Console.WriteLine(doc.TryGetElement("name", out name));

            Console.WriteLine(doc.Count());

            Console.WriteLine();

            Console.WriteLine(doc.ContainsValue("Sanya"));

            Console.WriteLine(doc.Contains("name"));

            Console.WriteLine(doc);

            //var doc2 = new BsonDocument
            //{
            //    { "Name", "Smith"},
            //    {"Something", "something else" },
            //    {"profession", "hacker" }
            //};

            //await collectionUsed.InsertManyAsync(new[] { doc, doc2 });
        }

        static async Task MainAsync2(string[] args)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var databaseUsed = client.GetDatabase("test");
            var collectionUsed = databaseUsed.GetCollection<Person>("people");

            var doc = new Person
            {
                Name = "Gerzson",
                Age = 31,
                Profession = "hacker"
            };

            await collectionUsed.InsertOneAsync(doc);

        }

        static async Task MainAsync3(string[] args)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var databaseUsed = client.GetDatabase("test");
            var collectionUsed = databaseUsed.GetCollection<BsonDocument>("people");

            using (var cursor = await collectionUsed.Find(new BsonDocument()).ToCursorAsync())
            {
                while (await cursor.MoveNextAsync())
                {
                    foreach (var doc in cursor.Current)
                    {
                        Console.WriteLine(doc);
                    }
                }
            };

        }
    }
}
