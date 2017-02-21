using api_core.net.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace api_core.net.Daos
{
    /**
    * Dialogue Application / Base de données pour la classe Participation
    **/
    public class ParticipationDao
    {
        // On récupère la connexion à la base
        private BaseDao baseDao = BaseDao.Instance;

        /**
         * Mise à jour d'une participation existante
         * 
         * @param id : l'ID de la participation à éditer
         * @param participation : les nouvelles valeurs à attribuer 
         **/
        public async Task Update(ObjectId id, Participation participation)
        {
            // On assigne à la participation l'id reçu
            participation.Id = id;
            // On récupère dans la base la participation correspondant à l'ID avec un filtre
            var filter = Builders<Participation>.Filter.Eq(p => p.Id, id);
            // On remplace l'objet présent par le nouveau
            await baseDao.db.GetCollection<Participation>("Participation").ReplaceOneAsync(filter, participation);
        }
        /**
        * Trouver une participation existante
        * 
        * @param id : l'ID de la participation à trouver
        * @return un objet Participation
        **/
        public Participation GetParticipation(ObjectId id)
        {
            // On récupère dans la base la participation correspondant à l'ID avec un filtre
            var filter = Builders<Participation>.Filter.Eq(p => p.Id, id);
            // On retourne l'objet participation trouvé
            return baseDao.db.GetCollection<Participation>("Participation").Find(filter).First();
        }
        /**
         * Créer une participation
         * 
         * @param participation : un objet Participation
         **/
        public async Task Create(Participation participation)
        {
            // On insert directement l'objet dans la base
            await baseDao.db.GetCollection<Participation>("Participation").InsertOneAsync(participation);
        }
    }
}
