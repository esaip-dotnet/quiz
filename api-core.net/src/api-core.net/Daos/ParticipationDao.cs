using api_core.net.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace api_core.net.Daos
{
    /**
     * Dao ParticipationDao
     * 
     * @attr baseDao : BaseDao
     **/
    public class ParticipationDao
    {
        private BaseDao baseDao = BaseDao.Instance;

        /**
         * Function GetParticipationById
         * Find Participation by Id in Quiz collection
         * 
         * @param id : ObjectId
         * @return Participation
         **/
        public Participation GetParticipationById(ObjectId id)
        {
            // Filter Participations by Id
            var filter = Builders<Participation>.Filter.Eq(p => p.Id, id);
            // Get from DB and Return Participation filtered by Id
            return baseDao.db.GetCollection<Participation>("Participation").Find(filter).First();
        }

        /**
         * Function CreateParticipation
         * Insert one Participation async in Participation collection
         * 
         * @param participation : Participation
         * @async Task
         * 
         **/
        public async Task CreateParticipation(Participation participation)
        {
            // Insert Participation in DB async
            await baseDao.db.GetCollection<Participation>("Participation").InsertOneAsync(participation);
        }

        /**
         * Function ReplaceParticipation
         * Replace one Participation async in Participation collection
         *
         * @param id : ObjectId
         * @param participation : Participation
         * @async Task
         **/
        public async Task ReplaceParticipation(ObjectId id, Participation participation)
        {
            participation.Id = id;

            // Filter Participations by Id
            var filter = Builders<Participation>.Filter.Eq(p => p.Id, id);
            // Replace Participation in DB async
            await baseDao.db.GetCollection<Participation>("Participation").ReplaceOneAsync(filter, participation);
        }
    }
}
