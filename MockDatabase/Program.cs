using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MockDatabase.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MockDatabase
{
    class Program
    {
        //private DAL dal;
        static void Main(string[] args)
        {
            DAL dal = new DAL();
            var aliment = new Aliment
            {
                Id = new MongoDB.Bson.ObjectId(),
                nom = "Beurre",
                Quantite = 5,
                Unite = "lb"
            };
            ObjectId id = dal.InsertALiment(aliment);
            Console.WriteLine(id);

            var documents = dal.ReadAliments();
            foreach (Aliment alm in documents)
            {
                Console.WriteLine(alm.Id.ToString() +", " + alm.nom + ", " + alm.Quantite + ", " + alm.Unite);
            }
            Console.ReadLine();
        }
    }
}
