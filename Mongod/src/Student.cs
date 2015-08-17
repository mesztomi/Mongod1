using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongod.src
{
    class Student
    {
        public ObjectId Id { get; set; }

        public int student_id { get; set; }

        public string type { get; set; }

        public double score { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, StudenId: \"{1}\", type: {2}, Score: \"{3}\"", Id, student_id, type, score);
        }
    }
}
