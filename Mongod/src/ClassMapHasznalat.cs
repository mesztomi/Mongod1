using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongod.src
{
    class ClassMapHasznalat
    {
        static async Task classBarmoloMetodusClassMap()
        {

            BsonClassMap.RegisterClassMap<Person>(cm =>
            {
                cm.AutoMap();
                cm.MapMember(x => x.Name).SetElementName("név");
            });

            var person = new Person
            {
                Name = "Jones",
                Age = 34,
                //Colors = new List<string> { "red", "green" },
                //Pets = new List<Pet> { new Pet { Name = "Fluffy", Type = "Pig" } },
                //ExtraElements = new BsonDocument("anotherName", "anotherValue")
            };

            using (var writer = new JsonWriter(Console.Out))
            {
                BsonSerializer.Serialize(writer, person);
            }
        }
    }
}
