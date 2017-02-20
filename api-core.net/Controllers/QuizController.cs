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
     * Controller de la classe Quiz
     * La route de base du controller est :
     * quiz
     **/
    [Route("quiz")]
    public class QuizController : Controller
    {
        // Le DAO nécessaire au traitement des données
        QuizDao quizDao;

        public QuizController(QuizDao quizDao)
        {
            this.quizDao = quizDao;
        }

        /**
         * Route GET
         * Renvoie un objet Quiz 
         * HTTP Code : 200
         * 
         * @param idQuiz id du quiz
         * @return un objet Quiz
         **/
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

        /**
         * Route GET
         * Renvoie tous les quiz 
         * HTTP Code : 200
         * 
         * @return list d'objet Quiz
         **/
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<BaseQuiz> listQuiz = quizDao.GetAllQuiz();
            if (listQuiz == null)
            {
                return NotFound();
            }
            return new ObjectResult(listQuiz);
        }

        /**
         * Route POST
         * Créé un objet Quiz et l'URL de cette dernière
         * HTTP Code : 201
         * 
         * @param quiz un objet Quiz
         **/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Quiz quiz)
        {
            await quizDao.Create(quiz);

            return new CreatedResult($"/quiz/{quiz.Id}", quiz);
        }

        /**
         * Route PATCH
         * PATCH un objet quiz
         * HTTP Code : 200
         * 
         * @param idQuiz id de la quiz
         * @param patch l'objet quiz sous forme de JSONPatchDocument
         **/
        [HttpPatch("{idQuiz}")]
        public async Task<IActionResult> Patch(string idQuiz, [FromBody]JsonPatchDocument<Quiz> patch)
        {
            var quiz = quizDao.GetQuiz(new ObjectId(idQuiz));
            patch.ApplyTo(quiz, ModelState);

            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            await quizDao.Update(quiz.Id, quiz);

            return new ObjectResult(quiz);
        }
    }
}
