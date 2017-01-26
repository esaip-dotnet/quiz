using MongoDB.Driver;

namespace api_core.net.Models
{
    public class BaseDao
    {
        public MongoClient _client { get; set; }
        public IMongoDatabase _db { get; set; }

        private static BaseDao instance;

        private BaseDao() {
            _client = new MongoClient("mongodb://localhost:27017");
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