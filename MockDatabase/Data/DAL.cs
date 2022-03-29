using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MockDatabase.Data
{
    public class DAL
    {
        public IMongoClient mongoDBClient;
        public IMongoDatabase database;

        public DAL(IMongoClient client = null)
        {
            mongoDBClient = client ?? OuvrirConnexion();
            database = ConnectDatabase();
        }
        private IMongoClient OuvrirConnexion()
        {
            MongoClient dbClient = null;
            try
            {
                dbClient = new MongoClient("mongodb://localhost:27017/TP2DB");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible de se connecter à la base de données " + ex.Message, "Erreur");
            }
            return dbClient;
        }

        private IMongoDatabase ConnectDatabase()
        {
            IMongoDatabase db = null;
            try
            {
                db = mongoDBClient.GetDatabase("StockDB");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible de se connecter à la base de données " + ex.Message, "Erreur");
            }
            return db;
        }
        public List<Aliment> ReadAliments()
        {
            var collection = database.GetCollection<Aliment>("Aliments");
            var documents = collection.FindSync(Builders<Aliment>.Filter.Empty).ToList(); //(new BsonDocument()).ToList();
            return documents;
        }
        public ObjectId InsertALiment(Aliment aliment)
        {
            try
            {
                var collection = database.GetCollection<Aliment>("Aliments");
                collection.InsertOne(aliment);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible de se connecter à la base de données " + ex.Message, "Erreur");
            }
            return aliment.Id;
        }

        public void UpdateAliment(Aliment aliment)
        {
            // A implémenter
        }

        public bool DeleteAliment(Aliment aliment)
        {
            // A implémenter
            return true;
        }
    }
}
