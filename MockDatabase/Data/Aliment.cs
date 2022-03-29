using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MockDatabase.Data
{
    public class Aliment
    {
        public ObjectId Id { get; set; }
        public string nom { get; set; }
        public int Quantite { get; set; }
        public string Unite { get; set; }

    }
}


