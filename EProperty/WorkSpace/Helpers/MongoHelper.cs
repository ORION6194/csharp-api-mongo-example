using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EProperty.WorkSpace.Helpers
{
    public class MongoHelper<T> where T : class
    {
        public MongoCollection<T> Collection { get; private set; }
        public MongoHelper()
        {
            var credentials = MongoCredential.CreateMongoCRCredential(ConstantClass.dbname, ConstantClass.dbusername, ConstantClass.dbpwd);
            var settings = new MongoClientSettings
            {
                Server = new MongoServerAddress(ConstantClass.dbaddress, ConstantClass.dbport),
                Credentials = new[] { credentials },
                UseSsl = false
            };

            var mongoClient = new MongoClient(settings);
            var db = mongoClient.GetServer().GetDatabase(ConstantClass.dbname);
            var dbClassName = typeof(T).Name.ToLower();
            Collection = db.GetCollection<T>(dbClassName);
        }
    }
}