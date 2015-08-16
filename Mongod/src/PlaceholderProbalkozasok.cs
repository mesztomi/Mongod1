using MongoDB.Bson;
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
        }
    }
}
