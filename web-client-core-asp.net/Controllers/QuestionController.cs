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
        [HttpGet]
        public IActionResult Index([FromQuery]Uri quizUri)
        {
            this.quizUri = quizUri;
            return View();
        }
        /// <summary>
        /// Ajouter la question au quiz
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        ///Envoyer la question avec la méthode Patch
        /// </summary>
        /// <param name="patch"></param>
        /// <returns></returns>
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
