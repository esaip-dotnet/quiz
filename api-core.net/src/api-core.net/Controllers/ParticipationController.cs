using api_core.net.Daos;
using api_core.net.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace api_core.net.Controllers
{
    /**
     * Controller de la classe Participation
     * La route de base du controller est :
     * quiz/{idQuiz}/participation
     * idQuiz, représente l'id du quiz auquel la participation se rapporte
     **/
    [Route("quiz/{idQuiz}/participation")]
    public class ParticipationController : Controller
    {
        // Le DAO nécessaire au traitement des données
        ParticipationDao participationDao;

        public ParticipationController(ParticipationDao participationDao)
        {
            this.participationDao = participationDao;
        }

        /**
         * Route POST
         * Créé un objet Participation et l'URL de cette dernière
         * HTTP Code : 201
         * 
         * @param p un objet Participation
         **/
        [HttpPost]
        public async Task<IActionResult> Post(string idQuiz, [FromBody]Participation p)
        {
            p.Quiz.Id = new ObjectId(idQuiz);
            await participationDao.Create(p);

            return new CreatedResult($"/quiz/{idQuiz}/participation/{p.Id}", p);
        }

        /**
         * Route PUT
         * Edite un objet Participation et renvoie sur la page de cette dernière
         * HTTP Code : 200
         * 
         * @param p un objet Participation
         **/
        [HttpPut("{idParticipation}")]
        public async Task<IActionResult> Put(string idQuiz, string idParticipation, [FromBody]Participation p)
        {
            p.Quiz.Id = new ObjectId(idQuiz);
            ObjectId idPart = new ObjectId(idParticipation);
            
            var part = participationDao.GetParticipation(idPart);

            if (part == null)
            {
                await participationDao.Create(p);
            }

            await participationDao.Update(idPart, p);
            return new OkResult();
        }

        /**
         * Route GET
         * Renvoie un objet Participation 
         * HTTP Code : 200
         * 
         * @param idParticipation id de la participation
         * @return un objet Participation
         **/
        [HttpGet("{idParticipation}")]
        public IActionResult GetId(string idParticipation)
        {
            var participation = participationDao.GetParticipation(new ObjectId(idParticipation));
            if (participation == null)
            {
                return NotFound();
            }
            return new ObjectResult(participation);
        }

        /**
         * Route PATCH
         * PATCH un objet participation
         * HTTP Code : 200
         * 
         * @param idParticipation id de la participation
         * @param patch l'objet participation sous forme de JSONPatchDocument
         **/
        [HttpPatch("{idParticipation}")]
        public async Task<IActionResult> Patch(string idParticipation, [FromBody]JsonPatchDocument<Participation> patch)
        {
            var participation = participationDao.GetParticipation(new ObjectId(idParticipation));
            patch.ApplyTo(participation, ModelState);

            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            await participationDao.Update(participation.Id, participation);

            return new ObjectResult(participation);
        }
    }
}
