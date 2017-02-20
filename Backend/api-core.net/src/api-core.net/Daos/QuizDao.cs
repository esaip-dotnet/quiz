using api_core.net.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<BaseQuiz> GetAllQuiz()
        {
            var projection = Builders<Quiz>.Projection.Exclude("questions");

            IEnumerable<Quiz> list = baseDao.db.GetCollection<Quiz>("Quiz").Find(_ => true).ToList();

            IEnumerable<BaseQuiz> baseList = from quiz in list
                                             select new BaseQuiz
                                             {
                                                 Id = quiz.Id,
                                                 Summary = quiz.Summary,
                                                 Description = quiz.Description,
                                                 Title = quiz.Title
                                             };

            return baseList;
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