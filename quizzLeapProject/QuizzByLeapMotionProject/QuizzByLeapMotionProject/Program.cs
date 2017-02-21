using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leap;
using System.Net;
using System.IO;

namespace QuizzByLeapMotionProject
{
    {
    class SampleListener : Listener
    {
        private Object thisLock = new Object();
        private int compteur = 0;
        private int DELAIS = 3;
        private String messageAttente = ".";

        /************LEAP V2*******************/
        private static int idQuiz = 1;
        private static String Question = "Quelle est la couleur du cheval blanc d'Henri IV";
        private static String[] reponses = new String[]{ "Noir", "Blanc", "La réponse D", "Obi-wan kenobi" };
        private int bonneReponse = 2;
        private Quiz quiz;
        /*************************************/

        /// <summary>
        /// Permet d'initialiser les éléments de base de l'élection.
        /// </summary>
        public void initSampleListener()
        {
            /*****************LEAP V2**********************/
            AffichagePosition();
            /**********************************************/

        }
        private void SafeWriteLine(String line)
        {
            lock (thisLock)
            {
                Console.WriteLine(line);
            }
        }

        public override void OnInit(Controller controller)
        {
            SafeWriteLine("Initialized\n");

        }

        public override void OnConnect(Controller controller)
        {
          //  SafeWriteLine("Connected\n");
            controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
            controller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }

        public override void OnDisconnect(Controller controller)
        {
            //Note: not dispatched when running in a debugger.
            SafeWriteLine("Disconnected\n");
        }

        public override void OnExit(Controller controller)
        {
            SafeWriteLine("Exited\n");
        }

        /// <summary>
        /// Permet d'afficher les informations pour chaque nouveau vote.
        /// </summary>
        /// <param name="election">Demande l'objet election afin d'afficher les informations des choix, etc...</param>


        /// <summary>
        /// TODO Fonction permettant la transformation des objets liés à l'élection en chaine de caractère au format JSON.
        /// </summary>
        /// <param name="election"> Objet Election contenant les autres objets Vote et Choix</param>
        /// <returns>Retourne la chaine de caractère au format JSON</returns>
     /*   public String generateJSon(Election election)
        {
            String json = "{'id':'" + election.getNom() + "','votes':[";

            for (int i = 0; i < election.getListeVote().Count; i++)
            {
                Vote vote = election.getListeVote()[i];
                json += "{'choix':'" + vote.getChoixFait().getId() + "', 'prenom':'" + vote.getPrenom() + "'}";
                //Pensez à ajouter les virgules en cas d'envoi de plusieurs lignes.
            }
            json += "]}";
            return json;
        }*/
        /// <summary>
        /// Fonction permettant la transformation des objets liés à l'élection en chaine de caractère au format XML.
        /// </summary>
        /// <param name="election"> Objet Election contenant les autres objets Vote et Choix</param>
        /// <returns>Retourne la chaine de caractère au format XML</returns>
       /* public String generateXML(Election election)
        {
            String xml = "<Election id:\"" + election.getNom() + "\">";
            foreach (Vote vote in election.getListeVote())
            {
                xml += "<Vote choix:\"" + vote.getChoixFait().getId() + "\" prenom:\"" + vote.getPrenom() + "\"/>";
            }
            xml += "</Election>";
            return xml;
        }*/
        /// <summary>
        /// Fonction permettant d'envoyer les informations vers le serveur
        /// TODO
        /// </summary>
        /// <param name="fichier">demande les données à envoyer (Format JSON ou XML, à appeler avec les fonctions generateXML et generateJSon</param>
        public async Task envoiInformation()
        {
            String url = "coreosjpg.cloudapp.net/quiz";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = File.ReadAllText("test.json");

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }



            SafeWriteLine("url = " + url + " json " + fichier);
        }

        /*************LEAP V2****************/
        public void AffichagePosition()
        {
            quiz = new Quiz(idQuiz, Question, reponses);
            SafeWriteLine("La question est: " + Question);
            System.Threading.Thread.Sleep(5000);
            SafeWriteLine("Réponse 1: " + reponses.GetValue(0).ToString());
            System.Threading.Thread.Sleep(2000);
            SafeWriteLine("Réponse 2: " + reponses.GetValue(1).ToString());
            System.Threading.Thread.Sleep(2000);
            SafeWriteLine("Réponse 3: " + reponses.GetValue(2).ToString());
            System.Threading.Thread.Sleep(2000);
            SafeWriteLine("Réponse 4: " + reponses.GetValue(3).ToString());
            System.Threading.Thread.Sleep(2000);
            SafeWriteLine("Sélectionnez votre réponse en positionnant votre main !");
        }

        public override void OnFrame(Controller controller)
        {
            Frame frame = controller.Frame();

            Hand hand = frame.Hands.Rightmost;
            Vector position = hand.PalmPosition;
            float timeVisible = hand.TimeVisible; 
            if (position.x != 0 && position.y != 0 && position.z !=0)
            {
                if (position.x <0 && position.z <0)
                {
                    SafeWriteLine("Vous choississez la réponse 1");
                    //if (bonneReponse !=1)
                    //{
                    //    System.Threading.Thread.Sleep(2000);
                    //    SafeWriteLine("Mauvaise réponse");
                    //}
                    //else
                    //{
                    //    System.Threading.Thread.Sleep(2000);
                    //    SafeWriteLine("Bien joué !");
                    //}
                    envoiInformation();

                }
                else if (position.x < 0 && position.z > 0)
                {
                    SafeWriteLine("Vous choississez la réponse 3");
                    //if (bonneReponse != 3)
                    //{
                    //    System.Threading.Thread.Sleep(2000);
                    //    SafeWriteLine("Mauvaise réponse");
                    //}
                    //else
                    //{
                    //    System.Threading.Thread.Sleep(2000);
                    //    SafeWriteLine("Bien joué !");
                    //}
                    envoiInformation();
                }
                else if (position.x > 0 && position.z < 0)
                {
                    SafeWriteLine("Vous choississez la réponse 2");
                    //if (bonneReponse != 2)
                    //{
                    //    System.Threading.Thread.Sleep(2000);
                    //    SafeWriteLine("Mauvaise réponse");
                    //}
                    //else
                    //{
                    //    System.Threading.Thread.Sleep(2000);
                    //    SafeWriteLine("Bien joué !");
                    //}
                    envoiInformation();
                }
                else if (position.x > 0 && position.z > 0)
                {
                    SafeWriteLine("Vous choississez la réponse 4");
                    //if (bonneReponse != 4)
                    //{
                    //    System.Threading.Thread.Sleep(2000);
                    //    SafeWriteLine("Mauvaise réponse");
                    //}
                    //else
                    //{
                    //    System.Threading.Thread.Sleep(2000);
                    //    SafeWriteLine("Bien joué !");
                    //}
                    envoiInformation();
                }
            }
            System.Threading.Thread.Sleep(3000);


        }

        /***********************************/

        class Sample
        {
            public static void Main()
            {
                // Create a sample listener and controller
                SampleListener listener = new SampleListener();
                Controller controller = new Controller();

                // Keep this process running until Enter is pressed
                controller.AddListener(listener);
                Console.WriteLine("Appuyez sur la touche échape pour quitter: \n");
                listener.initSampleListener();
                while (true) ;

            }
        }
    }
}