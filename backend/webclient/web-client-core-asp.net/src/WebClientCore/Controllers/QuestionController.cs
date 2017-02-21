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

//Controller pour la page d'ajout de question
namespace WebClientCore.Controllers
{
    public class QuestionController : Controller
    {
        //Variable pour stocker l'uri du quiz
        Uri quizUri;
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index([FromQuery]Uri quizUri)
        {
            //Récupérer la valeur de l'uri retournée par le HomeController
            this.quizUri = quizUri;
            //Affichage de la page
            return View();
        }

        //Ajouter la question au quiz
        //Dès que l'utilisateur valide l'ajout de la question
        [HttpPost]
        [Route("Question/Validate")]
        public IActionResult Validate(Question question)
        {
            //Créer une variable de type Patch pour l'envoi sur l'api
            Patch patch = new Patch("add", "/questions", question);
            //Etat permettant de savoir si l'ajout de la question a fonctionné
            //Il faut mettre en paramètre un objet de type Patch
            bool resultHttp = PatchJsonAsync(patch);

            //Si il y a une réponse négative
            if (resultHttp == false) {
                //Retourner sur la page d'ajout de question
                return RedirectToAction("Index", "Question");
            }
            else {
                try {
                    //Sinon ajoute la question et retourne sur l'ajout d'un quiz
                    return RedirectToAction("Index", "Home");
                }
                catch (AggregateException e) {
                    //Si il y a une exception, retourner sur la page d'ajout de question
                    return RedirectToAction("Index", "Question");
                }
            }
        }

        //Envoyer la question avec la méthode Patch
        private bool PatchJsonAsync(Patch patch)
        {
            //Initialition de la variable client avec un HttpClient
            var client = new HttpClient();
            //Attendre la réponse de l'api
            //Si la réponse est 204 c'est que le question à bien été ajoutée par la méthode patch
            var response = HttpClientEx.PatchJsonAsync(client, "http://coreosjpg.cloudapp.net:80" + quizUri, patch).GetAwaiter().GetResult(); ;
            if (response.StatusCode == HttpStatusCode.NoContent) {
                return true;
            }
            return false;
        }
    }
}
