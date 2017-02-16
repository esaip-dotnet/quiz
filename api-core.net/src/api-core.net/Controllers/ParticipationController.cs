using api_core.net.Daos;
using api_core.net.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace api_core.net.Controllers
{
    /* 
     * Controller ParticipationController
     * 
     * @attr participationDao : ParticipationDao
     * @route /quiz/{idQuiz}/participation
     * 
     */
    [Route("quiz/{idQuiz}/participation")]
    public class ParticipationController : Controller
    {
        ParticipationDao participationDao;

        /* 
         * Constructor ParticipationController
         * 
         * @param participationDao : ParticipationDao
         * 
         */
        public ParticipationController(ParticipationDao participationDao)
        {
            this.participationDao = participationDao;
        }

        /*
         * Function CreateParticipation
         * 
         * Create Participation using POST request
         * 
         * @param idQuiz : string
         * @param participation : Participation
         * @route /quiz/{idQuiz}/participation
         * 
         * @return CreatedResult
         * 
         */
        [HttpPost]
        public async Task<IActionResult> CreateParticipation(string idQuiz, [FromBody]Participation participation)
        {
            participation.Quiz.Id = new ObjectId(idQuiz);
            // Create Participation in DB
            await participationDao.CreateParticipation(participation);

            // Return Participation location and object
            return new CreatedResult($"/quiz/{idQuiz}/participation/{participation.Id}", participation);
        }

        /*
         * Function UpdateParticipation
         * 
         * Update Participation if exists otherwise create it using PUT request
         * 
         * @param idQuiz : string
         * @param idParticipation : string
         * @param participation : Participation
         * @route /quiz/{idQuiz}/participation/{idParticipation}
         * 
         * @return OkResult
         * 
         */
        [HttpPut("{idParticipation}")]
        public async Task<IActionResult> UpdateParticipation(string idQuiz, string idParticipation, [FromBody]Participation participation)
        {
            participation.Quiz.Id = new ObjectId(idQuiz);
            ObjectId idPart = new ObjectId(idParticipation);
            
            // Get Participation by Id from DB
            var part = participationDao.GetParticipationById(idPart);

            // If doesn't exist create participation otherwise update it
            if (part == null)
            {
                await participationDao.CreateParticipation(participation);
            } else
            {
                await participationDao.ReplaceParticipation(idPart, participation);
            }

            
            return new OkResult();
        }

        /*
         * Function GetParticipationById
         * 
         * Get Participation by Id using GET request
         * 
         * @param idParticipation : string
         * @route /quiz/{idQuiz}/participation/{idParticipation}
         * 
         * @return ObjectResult
         * 
         */
        [HttpGet("{idParticipation}")]
        public IActionResult GetParticipationById(string idParticipation)
        {
            // Get Participation by Id from DB
            var participation = participationDao.GetParticipationById(new ObjectId(idParticipation));
            if (participation == null)
            {
                return NotFound();
            }
            return new ObjectResult(participation);
        }

        /*
         * Function PatchParticipation
         * 
         * Patch Quiz using PATCH request
         * 
         * @param idParticipation : string
         * @param patch : JsonPatchDocument<Participation>
         * @route /quiz/{idQuiz}/participation/{idParticipation}
         * 
         * @return ObjectResult
         * 
         */
        [HttpPatch("{idParticipation}")]
        public async Task<IActionResult> PatchParticipation(string idParticipation, [FromBody]JsonPatchDocument<Participation> patch)
        {
            // Get Participation by Id from DB
            var participation = participationDao.GetParticipationById(new ObjectId(idParticipation));
            // Apply patch to Participation
            patch.ApplyTo(participation, ModelState);

            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            // Patch Participation in DB
            await participationDao.ReplaceParticipation(participation.Id, participation);

            return new ObjectResult(participation);
        }
    }
}
