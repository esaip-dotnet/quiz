using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace api_core.net.Daos
{
    /**
    * La base DAO sert à se connecter à la base de données.
    * Elle est faite de manière à être un singleton pour éviter les connexions répétées.
    **/
    public class BaseDao
    {
        // Paramètres privés de la BDD
        private MongoClient _client { get; set; }
        private IMongoDatabase _db { get; set; }
        // Paramètres public pour récuperer la BDD
        public MongoClient client { get { return this._client; } }
        public IMongoDatabase db { get { return this._db; } }
        // Ces paramètres sont attribués au lancement de l'application avec la valeur les représentants 
        // dans le fichier appsetting.json
        public static string UrlMongo { get; set; }
        public static string PortMongo { get; set; }
        // Le paramètre renvoyé pour acceder à la base de "l'exterieur"
        private static BaseDao instance;

        private BaseDao() {
            _client = new MongoClient($"mongodb://{UrlMongo}:{PortMongo}");
            _db = _client.GetDatabase("QuizDB");
        }
        // Fonctionnement du singleton
        public static BaseDao Instance
        {
            // On cherche à récuperer la connexion depuis l'exterieur
            get
            {
                // Si l'instance est nulle = si l'application n'a jamais appelé la BDD
                if (instance == null)
                {
                    // On créé une nouvelle instance
                    instance = new BaseDao();
                }
                // Sinon on renvoie l'existante 
                return instance;
            }
        }
    }
}