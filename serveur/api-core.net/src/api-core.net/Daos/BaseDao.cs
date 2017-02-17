using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace api_core.net.Daos
{
    public class BaseDao
    {
        private MongoClient _client { get; set; }
        private IMongoDatabase _db { get; set; }

        public MongoClient client { get { return this._client; } }
        public IMongoDatabase db { get { return this._db; } }

        public static string UrlMongo { get; set; }
        public static string PortMongo { get; set; }

        private static BaseDao instance;

        private BaseDao() {
            _client = new MongoClient($"mongodb://{UrlMongo}:{PortMongo}");
            _db = _client.GetDatabase("QuizDB");
        }

        public static BaseDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BaseDao();
                }
                return instance;
            }
        }
    }
}