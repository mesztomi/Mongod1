using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongod.src
{
    class Widget
    {
        public int Id { get; set; }

        [BsonElement("x")]
        public int X { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, X: {1}", Id, X);
        }
    }
}
