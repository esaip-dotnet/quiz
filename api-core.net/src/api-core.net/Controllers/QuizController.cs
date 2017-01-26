using api_core.net.Daos;
using api_core.net.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
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

        [HttpGet("{idQuiz}")]
        public IActionResult GetId(string idQuiz)
        {
            var quiz = quizDao.GetQuiz(new ObjectId(idQuiz));
            if (quiz == null)
            {
                return NotFound();
            }
            return new ObjectResult(quiz);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Quiz> listQuiz = quizDao.GetAllQuiz();
            if (listQuiz == null)
            {
                return NotFound();
            }
            return new ObjectResult(listQuiz);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Quiz quiz)
        {
            await quizDao.Create(quiz);

            return new CreatedResult($"/quiz/{quiz.Id}", quiz);
        }

        [HttpPatch("{idQuiz}")]
        public IActionResult Patch(string idQuiz, [FromBody]JsonPatchDocument<Quiz> patch)
        {
            var quiz = quizDao.GetQuiz(new ObjectId(idQuiz));
            patch.ApplyTo(quiz, ModelState);

            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            //TODO Update

            return new ObjectResult(quiz);
        }
    }
}
