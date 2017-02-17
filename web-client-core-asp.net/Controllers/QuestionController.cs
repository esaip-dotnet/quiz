using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebClientCore.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using WebClientCore.Extensions;

namespace WebClientCore.Controllers
{
    public class QuestionController : Controller
    {
        Uri quizUri;
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index([FromQuery]Uri quizUri)
        {
            this.quizUri = quizUri;
            return View();
        }

        //Ajouter la question au quiz
        [HttpPost]
        [Route("Question/Validate")]
        public IActionResult Validate(Question question)
        {
            Patch patch = new Patch("add", "/questions", question);
            bool resultHttp = PasthJsonAsync(patch);

            if (resultHttp == false)
            {
                return RedirectToAction("Index", "Question");
            }
            else
            {
                try
                {
                    return RedirectToAction("Index", "Home");
                }
                catch (AggregateException e)
                {
                    return RedirectToAction("Index", "Question");
                }
            }
        }

        //Envoyer la question avec la méthode Patch
        private bool PasthJsonAsync(Patch patch)
        {
            var client = new HttpClient();
            var response = HttpClientEx.PatchJsonAsync(client, "http://coreosjpg.cloudapp.net:80" + quizUri, patch).GetAwaiter().GetResult(); ;
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }
    }
}
