using api_core.net.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_core.net.Daos
{
    /**
  * Dialogue Applicaiton / Base de données pour la classe Quiz
  **/
    public class QuizDao
    {
        // On récupère la connexion à la base
        private BaseDao baseDao = BaseDao.Instance;

        /**
         * Trouver un quiz existant
         * 
         * @param id : l'ID du quiz à trouver
         * @return un objet Quiz
         **/
        public Quiz GetQuiz(ObjectId id)
        {
            // On récupère dans la base le quiz correspondant à l'ID avec un filtre
            var filter = Builders<Quiz>.Filter.Eq(q => q.Id, id);
            // On retourne l'objet quiz trouvé
            return baseDao.db.GetCollection<Quiz>("Quiz").Find(filter).First();
        }
        /**
       * Trouver tous les quiz existants
       * 
       * @return Une liste d'objet Quiz
       **/
        public IEnumerable<BaseQuiz> GetAllQuiz()
        {
            // On récupère tous les quiz 
            var projection = Builders<Quiz>.Projection.Exclude("questions");
            // Pour chacun des quiz on le "transforme" en BaseQuiz, c'est-à-dire, sans les questions
            IEnumerable<Quiz> list = baseDao.db.GetCollection<Quiz>("Quiz").Find(_ => true).ToList();

            IEnumerable<BaseQuiz> baseList = from quiz in list
                                             select new BaseQuiz
                                             {
                                                 Id = quiz.Id,
                                                 Summary = quiz.Summary,
                                                 Description = quiz.Description,
                                                 Title = quiz.Title
                                             };

            // On retourne la liste
            return baseList;
        }
        /**
         * Créer un quiz
         * 
         * @param quiz : un objet Quiz
         **/
        public async Task Create(Quiz quiz)
        {
            // On insert directement l'objet dans la base
            await baseDao.db.GetCollection<Quiz>("Quiz").InsertOneAsync(quiz);
        }
        /**
        * Mise à jour d'un quiz existant
        * 
        * @param id : l'ID du quiz à éditer
        * @param quiz : les nouvelles valeurs à attribuer 
        **/
        public async Task Update(ObjectId id, Quiz quiz)
        {
            // On assigne au quizl'id reçu
            quiz.Id = id;
            // On récupère dans la base le quiz correspondant à l'ID avec un filtre
            var filter = Builders<Quiz>.Filter.Eq(p => p.Id, id);
            // On remplace l'objet présent par le nouveau
            await baseDao.db.GetCollection<Quiz>("Quiz").ReplaceOneAsync(filter, quiz);
        }
    }
}