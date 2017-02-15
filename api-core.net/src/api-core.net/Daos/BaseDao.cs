using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace api_core.net.Daos
{
    /*
     * Base Dao BaseDao (Singleton)
     * 
     * @attr _client : MongoClient
     * @attr _db : IMongoDatabase
     * @attr instance : BaseDao
     * 
     * @const UrlMongo : string
     * @const PortMongo : string
     * 
     */
    public class BaseDao
    {
        private MongoClient _client { get; set; }
        private IMongoDatabase _db { get; set; }

        public MongoClient client { get { return this._client; } }
        public IMongoDatabase db { get { return this._db; } }

        public static string UrlMongo { get; set; }
        public static string PortMongo { get; set; }

        private static BaseDao instance;

        /*
         * Constructor BaseDao
         * 
         * @attr _client : MongoClient
         * @attr _db : IMongoDatabase
         * 
         */
        private BaseDao() {
            _client = new MongoClient($"mongodb://{UrlMongo}:{PortMongo}");
            _db = _client.GetDatabase("QuizDB");
        }

        /*
         * Singleton Instance BaseDao
         * 
         */
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