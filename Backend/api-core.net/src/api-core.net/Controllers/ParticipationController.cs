using api_core.net.Daos;
using api_core.net.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace api_core.net.Controllers
{
    [Route("quiz/{idQuiz}/participation")]
    public class ParticipationController : Controller
    {
        ParticipationDao participationDao;

        public ParticipationController(ParticipationDao participationDao)
        {
            this.participationDao = participationDao;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string idQuiz, [FromBody]Participation p)
        {
            p.Quiz.Id = new ObjectId(idQuiz);
            await participationDao.Create(p);

            return new CreatedResult($"/quiz/{idQuiz}/participation/{p.Id}", p);
        }

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
