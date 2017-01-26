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

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Participation p)
        {
            await participationDao.Create(p);

            return new OkResult();
        }

        [HttpPut("{idParticipation}")]
        public async Task<IActionResult> Put(string id, [FromBody]Participation p)
        {
            ObjectId idPart = new ObjectId(id);
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
