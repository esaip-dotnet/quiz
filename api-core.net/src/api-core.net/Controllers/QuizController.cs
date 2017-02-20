using api_core.net.Daos;
using api_core.net.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_core.net.Controllers
{
    /**
     * Controller QuizController
     * 
     * @attr quizDao : QuizDao
     * @route /quiz
     **/
    [Route("quiz")]
    public class QuizController : Controller
    {
        QuizDao quizDao;

        /**
         * Constructor QuizController
         * 
         * @param quizDao : QuizDao
         **/
        public QuizController(QuizDao quizDao)
        {
            this.quizDao = quizDao;
        }

        /**
         * Function GetQuizById
         * Get Quiz by Id using GET request
         * 
         * @param idQuiz : string
         * @route /quiz/{idQuiz}
         * @return ObjectResult
         **/
        [HttpGet("{idQuiz}")]
        public IActionResult GetQuizById(string idQuiz)
        {
            // Get Quiz by Id from DB
            var quiz = quizDao.GetQuizById(new ObjectId(idQuiz));
            if (quiz == null)
            {
                return NotFound();
            }
            return new ObjectResult(quiz);
        }

        /**
         * Function GetAllQuiz
         * Get all Quiz using GET request
         * 
         * @route /quiz
         * @return ObjectResult
         **/
        [HttpGet]
        public IActionResult GetAllQuiz()
        {
            // Get all Quiz from DB
            IEnumerable<BaseQuiz> listQuiz = quizDao.GetAllQuiz();
            if (listQuiz == null)
            {
                return NotFound();
            }
            return new ObjectResult(listQuiz);
        }

        /**
         * Function CreateQuiz
         * Create Quiz using POST request
         * 
         * @param quiz : Quiz
         * @route /quiz
         * @return CreatedResult
         **/
        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromBody]Quiz quiz)
        {
            // Create Quiz in DB
            await quizDao.CreateQuiz(quiz);

            // Return Quiz location and object
            return new CreatedResult($"/quiz/{quiz.Id}", quiz);
        }

        /**
         * Function PatchQuiz
         * Patch Quiz using PATCH request
         * 
         * @param idQuiz : string
         * @param patch : JsonPatchDocument<Quiz>
         * @route /quiz/{idQuiz}
         * @return ObjectResult
         **/
        [HttpPatch("{idQuiz}")]
        public async Task<IActionResult> PatchQuiz(string idQuiz, [FromBody]JsonPatchDocument<Quiz> patch)
        {
            // Get Quiz from DB
            var quiz = quizDao.GetQuizById(new ObjectId(idQuiz));
            // Apply patch to Quiz
            patch.ApplyTo(quiz, ModelState);

            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            // Patch Quiz in DB
            await quizDao.UpdateQuiz(quiz.Id, quiz);

            return new ObjectResult(quiz);
        }
    }
}
