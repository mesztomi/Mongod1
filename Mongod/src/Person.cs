using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongod
{
    class Person
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Profession { get; set; }

        //public List<string> Colors { get; set; }

        //public List<Pet> Pets { get; set; }

        //public BsonDocument ExtraElements { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: \"{1}\", Age: {2}, Profession: \"{3}\"", Id, Name, Age, Profession);
        }
    }
}
