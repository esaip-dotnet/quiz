using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebClientCore.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using WebClientCore.Extensions;

namespace WebClientCore.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home")]
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        //Ajouter le quiz
        [HttpPost]
        [Route("Home/Validate")]
        public IActionResult Validate(Quiz quiz)
        {
            Uri resultHttp = GetResponseUri(quiz);

            if (resultHttp == null) {
                return RedirectToAction("Index", "Home");
            }
            else {
                try {
                    return RedirectToAction("Index", "Question", new { quizUri = resultHttp });
                } catch (AggregateException e)  {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        //Récupérer la réponse de la méthode POST du quiz
        private Uri GetResponseUri(Quiz quiz)
        {
            var client = new HttpClient();
            var response = HttpClientEx.PostJsonAsync(client, "http://coreosjpg.cloudapp.net:80/quiz", quiz).GetAwaiter().GetResult(); ;
            if (response.StatusCode == HttpStatusCode.Created)
            {
                var contents = response.Headers.Location;
                return contents;
            }
            return null;
        }
    }
}
