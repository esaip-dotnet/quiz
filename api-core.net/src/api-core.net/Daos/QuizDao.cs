using api_core.net.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_core.net.Daos
{
    public class QuizDao
    {
        private BaseDao baseDao = BaseDao.Instance;

        public Quiz GetQuiz(ObjectId id)
        {
            var filter = Builders<Quiz>.Filter.Eq(q => q.Id, id);
            return baseDao.db.GetCollection<Quiz>("Quiz").Find(filter).First();
        }

        public IEnumerable<Quiz> GetAllQuiz()
        {
            return baseDao.db.GetCollection<Quiz>("Quiz").Find(_ => true).ToList();
        }

        public async Task Create(Quiz quiz)
        {
            await baseDao.db.GetCollection<Quiz>("Quiz").InsertOneAsync(quiz);
        }

        public async Task Update(ObjectId id, Quiz quiz)
        {
            quiz.Id = id;

            var filter = Builders<Quiz>.Filter.Eq(p => p.Id, id);
            await baseDao.db.GetCollection<Quiz>("Quiz").ReplaceOneAsync(filter, quiz);
        }
    }
}