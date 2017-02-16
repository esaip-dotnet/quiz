/******************************************************************************\
* Copyright (C) 2012-2014 Leap Motion, Inc. All rights reserved.               *
* Leap Motion proprietary and confidential. Not for distribution.              *
* Use subject to the terms of the Leap Motion SDK Agreement available at       *
* https://developer.leapmotion.com/sdk_agreement, or another agreement         *
* between Leap Motion and you, your company or other organization.             *
\******************************************************************************/
using System;
using System.Threading;
using Leap;
using System.Collections.Generic;

namespace VoteByLeapMotionProject
{
    class SampleListener : Listener
    {
        private Object thisLock = new Object();
        private static int idQuiz = 1;
        private static int iCompteurQuestion = 1;      
        private static String[] Question = new String[4] { "Quelle est la couleur du cheval blanc d'Henri IV ?", "Quelle est l'évolution du Pokémon M.Mime ?", "Est-ce que les nains dépensent moins car au supermarché les produits les moins chers sont tout en bas ?", "Peut-on faire de la confiture de coings dans une casserole ronde ?" };
        private static String[] reponses1 = new String[]{ "Noir", "Blanc", "La réponse D", "Obi-wan kenobi" };
        private static String[] reponses2 = new String[] { "Mme.Mime", "Grand-père.Mime", "Alakazam", "Il n'en a pas" };
        private static String[] reponses3 = new String[] { "Oui", "Non", "Alerte discrimination", "Oui si c'est de la bière" };
        private static String[] reponses4 = new String[] { "Oui", "Non", "Arrêtez les réponses stupides", "C'est dans les vieux pots qu'on fait la meilleure confiture" };
        private static int[] itTabReponses = new int[] {2,4,3,3};
        private Quiz quiz;

        /// <summary>
        /// Permet d'initialiser les éléments de base de l'élection.
        /// </summary>
        public void initSampleListener()
        {
            AffichageQuestion(1);
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
            controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
            controller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }

        public override void OnDisconnect(Controller controller)
        {
            SafeWriteLine("Disconnected\n");
        }

        public override void OnExit(Controller controller)
        {
            SafeWriteLine("Exited\n");
        }
         
        /// <summary>
        /// Cette fonction est appellée à chaque affichage de question. Elle utilise le compteur de question
        /// qui lui est passé en paramètre afin de pouvoir créer l'objet quiz correspondant
        /// Une pause de 1 seconde est effectuée entre chaque affichage de réponse
        /// </summary>
        /// <param name="iNumeroQuestion">Compteur de question</param>
        public void AffichageQuestion(int iNumeroQuestion)
        {
            try
            {
                if (iNumeroQuestion == 1)
                {
                    //Le compteur est initialisé à 1 par défaut. Il faut donc soustraire 1
                    //pour récupérer la question correspondante dans le tableau de string
                    quiz = new Quiz(idQuiz, Question[iNumeroQuestion - 1], reponses1);

                    SafeWriteLine("La question est: " + Question[iNumeroQuestion - 1]);
                    System.Threading.Thread.Sleep(2000);
                    SafeWriteLine("Réponse 1: " + reponses1.GetValue(0).ToString());
                    System.Threading.Thread.Sleep(1000);
                    SafeWriteLine("Réponse 2: " + reponses1.GetValue(1).ToString());
                    System.Threading.Thread.Sleep(1000);
                    SafeWriteLine("Réponse 3: " + reponses1.GetValue(2).ToString());
                    System.Threading.Thread.Sleep(1000);
                    SafeWriteLine("Réponse 4: " + reponses1.GetValue(3).ToString());
                    System.Threading.Thread.Sleep(1000);
                    SafeWriteLine("Sélectionnez votre réponse en positionnant votre main !");
                }

                if (iNumeroQuestion == 2)
                {
                    quiz = new Quiz(idQuiz, Question[iNumeroQuestion - 1], reponses2);

                    SafeWriteLine("La question est: " + Question[iNumeroQuestion - 1]);
                    System.Threading.Thread.Sleep(2000);
                    SafeWriteLine("Réponse 1: " + reponses2.GetValue(0).ToString());
                    System.Threading.Thread.Sleep(1000);
                    SafeWriteLine("Réponse 2: " + reponses2.GetValue(1).ToString());
                    System.Threading.Thread.Sleep(1000);
                    SafeWriteLine("Réponse 3: " + reponses2.GetValue(2).ToString());
                    System.Threading.Thread.Sleep(1000);
                    SafeWriteLine("Réponse 4: " + reponses2.GetValue(3).ToString());
                    System.Threading.Thread.Sleep(1000);
                    SafeWriteLine("Sélectionnez votre réponse en positionnant votre main !");

                }
                if (iNumeroQuestion == 3)
                {
                    quiz = new Quiz(idQuiz, Question[iNumeroQuestion - 1], reponses3);

                    SafeWriteLine("La question est: " + Question[iNumeroQuestion - 1]);
                    System.Threading.Thread.Sleep(2000);
                    SafeWriteLine("Réponse 1: " + reponses3.GetValue(0).ToString());
                    System.Threading.Thread.Sleep(1000);
                    SafeWriteLine("Réponse 2: " + reponses3.GetValue(1).ToString());
                    System.Threading.Thread.Sleep(1000);
                    SafeWriteLine("Réponse 3: " + reponses3.GetValue(2).ToString());
                    System.Threading.Thread.Sleep(1000);
                    SafeWriteLine("Réponse 4: " + reponses3.GetValue(3).ToString());
                    System.Threading.Thread.Sleep(1000);
                    SafeWriteLine("Sélectionnez votre réponse en positionnant votre main !");
                }
                if (iNumeroQuestion == 4)
                {
                    quiz = new Quiz(idQuiz, Question[iNumeroQuestion - 1], reponses4);
                    SafeWriteLine("La question est: " + Question[iNumeroQuestion - 1]);
                    System.Threading.Thread.Sleep(2000);
                    SafeWriteLine("Réponse 1: " + reponses4.GetValue(0).ToString());
                    System.Threading.Thread.Sleep(1000);
                    SafeWriteLine("Réponse 2: " + reponses4.GetValue(1).ToString());
                    System.Threading.Thread.Sleep(1000);
                    SafeWriteLine("Réponse 3: " + reponses4.GetValue(2).ToString());
                    System.Threading.Thread.Sleep(1000);
                    SafeWriteLine("Réponse 4: " + reponses4.GetValue(3).ToString());
                    System.Threading.Thread.Sleep(1000);
                    SafeWriteLine("Sélectionnez votre réponse en positionnant votre main !");
                }
          }
            catch
            {
                SafeWriteLine("Erreur d'affichage de la question.");
            }
        }
        
        /// <summary>
        /// Cette fonction est appellée lorsqu'une bonne réponse est donnée par l'utilisation
        /// On incrémente d'abord le compteur puis on test si il est supérieur au nombre de question
        /// Auquel cas on termine le programme. Sinon on rappelle l'affichage de question
        /// </summary>
        public void SwitchQuestion()
        {
            SafeWriteLine("Bien joué !");
            iCompteurQuestion++;
            try { 
                    if (iCompteurQuestion> Question.Length)
                    {
                        SafeWriteLine("Fin du quiz !\n Merci de votre participation.");
                        Environment.Exit(0);
                    }
                    else
                    {
                        AffichageQuestion(iCompteurQuestion); 
                    }
                }
            catch
            {
                SafeWriteLine("Erreur lors du changement de la question.");
            }
        }

        /// <summary>
        /// Evènement lorsque le capteur de la leap détecte une main. 
        /// On créé les objets nécessaire pour détecter une main et sa position en vecteur
        /// Puis selon la position de la main(centre de la paume), nous détectons la réponse fournie par l'utilisation
        /// On appelle SwitchQuestion() dès qu'une bonne réponse est donnée.
        /// </summary>
        /// <param name="Controller">L'objet controller pour la leap</param>
        public override void OnFrame(Controller controller)
        {
            Frame frame = controller.Frame();
            Hand hand = frame.Hands.Rightmost;
            Vector position = hand.PalmPosition;
            float timeVisible = hand.TimeVisible; 
            if (position.x != 0 && position.y != 0 && position.z !=0)
            {
                if (position.x < 0 && position.z < 0)
                {
                    SafeWriteLine("Vous choississez la réponse 1");
                    if (itTabReponses[iCompteurQuestion-1] != 1)
                    {
                        System.Threading.Thread.Sleep(2000);
                        SafeWriteLine("Mauvaise réponse");
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2000);
                        SwitchQuestion();
                    }
                }
                else if (position.x < 0 && position.z > 0)
                {
                    SafeWriteLine("Vous choississez la réponse 3");
                    if (itTabReponses[iCompteurQuestion-1] != 3)
                    {
                        System.Threading.Thread.Sleep(2000);
                        SafeWriteLine("Mauvaise réponse");
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2000);
                        SwitchQuestion();
                    }
                }
                else if (position.x > 0 && position.z < 0)
                {
                    SafeWriteLine("Vous choississez la réponse 2");
                    if (itTabReponses[iCompteurQuestion-1] != 2)
                    {
                        System.Threading.Thread.Sleep(2000);
                        SafeWriteLine("Mauvaise réponse");
                        SwitchQuestion();
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2000);
                        SwitchQuestion();
                    }
                }
                else if (position.x > 0 && position.z > 0)
                {
                    SafeWriteLine("Vous choississez la réponse 4");
                    if (itTabReponses[iCompteurQuestion-1] != 4)
                    {
                        System.Threading.Thread.Sleep(2000);
                        SafeWriteLine("Mauvaise réponse");
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2000);
                        SwitchQuestion();
                    }
                }
            }
            System.Threading.Thread.Sleep(3000);
        }

        /***********************************/

        class Sample
        {
            public static void Main()
            {
                SampleListener listener = new SampleListener();
                Controller controller = new Controller();
                controller.AddListener(listener);
                Console.WriteLine("Appuyez sur la touche échape pour quitter: \n");
                listener.initSampleListener();
                while (true);
            }
        }
    }
}