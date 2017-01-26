using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace api_core.net.Models
{
    public class ParticipationDao
    {
        private BaseDao baseDao = BaseDao.Instance;

        public async Task Update(ObjectId id, Participation participation)
        {
            participation.Id = id;
            
            var filter = Builders<Participation>.Filter.Eq(p => p.Id, id);
            await baseDao.db.GetCollection<Participation>("Participation").ReplaceOneAsync(filter, participation);
        }

        public Participation GetParticipation(ObjectId id)
        {
            var filter = Builders<Participation>.Filter.Eq(p => p.Id, id);
            return baseDao.db.GetCollection<Participation>("Participation").Find(filter).First();
        }

        public async Task Create(Participation participation)
        {
            await baseDao.db.GetCollection<Participation>("Participation").InsertOneAsync(participation);
        }
    }
}
