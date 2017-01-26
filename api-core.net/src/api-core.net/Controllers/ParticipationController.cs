using api_core.net.Models;
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

            return new OkResult();
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
    }
}
