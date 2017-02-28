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

//Controller pour la page d'ajout de quiz (page d'accueil)
namespace WebClientCore.Controllers
{
    public class HomeController : Controller
    {
        //Nous pouvons accéder à cette page directement en accédant au site
        //Il est aussi possible d'y accéder en mettant /home et /index
        [Route("Home")]
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            //Affichage de la page
            return View();
        }

        //Méthode POST permettant d'ajouter un quiz
        //Dès que l'utilisateur valide le formulaire de la page d'accueil
        [HttpPost]
        [Route("Home/Validate")]
        public IActionResult Validate(Quiz quiz)
        {
            //Récupérer l'uri de la réponse de l'api
            //Il faut mettre en paramètre le quiz à ajouter
            Uri resultHttp = GetResponseUri(quiz);

            //Si nous ne recevons pas de réponse
            if (resultHttp == null) {
                //Retourner sur la page principale
                return RedirectToAction("Index", "Home");
            }//Sinon si nous recevons une réponse
            else {
                try {
                    //On essaye d'accéder à la page d'ajout de question avec l'url récupérée
                    return RedirectToAction("Index", "Question", new { quizUri = resultHttp });
                } catch (AggregateException e)  {
                    //Si il y a une exception, retourner sur la page d'accueil
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        //Récupérer la réponse de la méthode POST du quiz
        private Uri GetResponseUri(Quiz quiz)
        {
            //Initialition de la variable client avec un HttpClient
            var client = new HttpClient();
            //Attendre la réponse de l'api
            //Si la réponse est 201 c'est que le quiz a bien été créé
            /*String apiUrlPort = Environment.GetEnvironmentVariable("API_URL_PORT");
            String dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var response = HttpClientEx.PostJsonAsync(client, "http://" + apiUrlPort + "/" + dbName, quiz).GetAwaiter().GetResult();*/
            var response = HttpClientEx.PostJsonAsync(client, "http://localhost:81/quiz/", quiz).GetAwaiter().GetResult();
            //Vérifier si le code est 201
            if (response.StatusCode == HttpStatusCode.Created) {
                //Si oui retourner l'uri du quiz
                var contents = response.Headers.Location;
                return contents;
            }
            return null;
        }
    }
}
