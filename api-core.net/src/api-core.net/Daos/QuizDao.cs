using api_core.net.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_core.net.Daos
{
    /**
     * Dao QuizDao
     * @attr baseDao : BaseDao
     **/
    public class QuizDao
    {
        private BaseDao baseDao = BaseDao.Instance;

        /**
         * Function GetQuizById
         * Find Quiz by Id in Quiz collection
         * 
         * @param id : ObjectId
         * @return Quiz
         **/
        public Quiz GetQuizById(ObjectId id)
        {
            // Filter Quiz by Id
            var filter = Builders<Quiz>.Filter.Eq(q => q.Id, id);
            // Get from DB and Return Quiz filtered by Id
            return baseDao.db.GetCollection<Quiz>("Quiz").Find(filter).First();
        }

        /**
         * Function GetAllQuiz
         * Find all Quiz in Quiz collection
         * 
         * @return IEnumerable<BaseQuiz>
         **/
        public IEnumerable<BaseQuiz> GetAllQuiz()
        {
            // Get all Quiz from DB
            IEnumerable<Quiz> list = baseDao.db.GetCollection<Quiz>("Quiz").Find(_ => true).ToList();

            // Filter all unwanted attributes in Quiz object
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

        /**
         * Function CreateQuiz
         * Insert one Quiz async in Quiz collection
         * 
         * @param quiz : Quiz
         * @async Task
         **/
        public async Task CreateQuiz(Quiz quiz)
        {
            // Insert Quiz in DB async
            await baseDao.db.GetCollection<Quiz>("Quiz").InsertOneAsync(quiz);
        }

        /**
         * Function UpdateQuiz
         * Replace one Quiz async in Quiz collection
         *
         * @param id : ObjectId
         * @param quiz : Quiz
         * @async Task
         **/
        public async Task UpdateQuiz(ObjectId id, Quiz quiz)
        {
            quiz.Id = id;

            // Filter Quiz by Id
            var filter = Builders<Quiz>.Filter.Eq(p => p.Id, id);
            // Replace Quiz in DB async
            await baseDao.db.GetCollection<Quiz>("Quiz").ReplaceOneAsync(filter, quiz);
        }
    }
}