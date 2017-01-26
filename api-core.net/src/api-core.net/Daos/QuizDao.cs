using api_core.net.Models;
using System.Threading.Tasks;

namespace api_core.net.Daos
{
    public class QuizDao
    {
        private BaseDao baseDao = BaseDao.Instance;

        public async Task Create(Quiz quiz)
        {
            await baseDao.db.GetCollection<Quiz>("Quiz").InsertOneAsync(quiz);
        }
    }
}