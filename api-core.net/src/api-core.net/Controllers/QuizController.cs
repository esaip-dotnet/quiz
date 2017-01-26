using api_core.net.Daos;
using api_core.net.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api_core.net.Controllers
{
    [Route("quiz")]
    public class QuizController : Controller
    {
        QuizDao quizDao;

        public QuizController(QuizDao quizDao)
        {
            this.quizDao = quizDao;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Quiz quiz)
        {
            await quizDao.Create(quiz);

            return new OkObjectResult(quiz);
        }
    }
}
