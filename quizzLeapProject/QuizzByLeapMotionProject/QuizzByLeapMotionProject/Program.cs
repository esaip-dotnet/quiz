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
        //Valeurs déterminées pour créer les zones neutres du capteur
        const int izoneNeutreNegative = -100;
        const int izoneNeutrePositive = 100;

        private Object thisLock = new Object();

        private static int idQuiz = 1;
        private static int iCompteurQuestion = 0;
        private static String Question = "Quelle est la couleur du cheval blanc d'Henri IV";
        private static String[] reponses = new String[]{ "Noir", "Blanc", "La réponse D", "Obi-wan kenobi" };
        private int bonneReponse = 2;
        private Quiz quiz;

        /// <summary>
        /// Permet d'initialiser les éléments de base de l'élection.
        /// </summary>
        public void initSampleListener()
        {
            AffichagePosition();

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
        /// Cette fonction pour afficher la question en créant l'objet quiz correspondant.
        /// Une pause de 1 seconde est effectuée entre chaque affichage de réponse
        /// </summary>
        public void AffichagePosition()
        {
            quiz = new Quiz(idQuiz, Question, reponses);
            SafeWriteLine("La question est: " + Question);
            System.Threading.Thread.Sleep(2000);
            SafeWriteLine("Réponse 1: " + reponses.GetValue(0).ToString());
            System.Threading.Thread.Sleep(1000);
            SafeWriteLine("Réponse 2: " + reponses.GetValue(1).ToString());
            System.Threading.Thread.Sleep(1000);
            SafeWriteLine("Réponse 3: " + reponses.GetValue(2).ToString());
            System.Threading.Thread.Sleep(1000);
            SafeWriteLine("Réponse 4: " + reponses.GetValue(3).ToString());
            System.Threading.Thread.Sleep(1000);
            SafeWriteLine("Sélectionnez votre réponse en positionnant votre main !");
        }



        /// <summary>
        /// Evènement lorsque le capteur de la leap détecte une main. 
        /// On créé les objets nécessaire pour détecter une main et sa position en vecteur
        /// Puis selon la position de la main(centre de la paume), nous détectons la réponse fournie par l'utilisation
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
                //PENSER AU Y POUR PAS COLLER 1/3 ET 2/4   !!!!!!!!!!!
                //if (position.x <0 && position.z <0)
                if (position.x < izoneNeutreNegative && position.z < 0)
                {
                    SafeWriteLine("Vous choississez la réponse 1");
                    if (bonneReponse !=1)
                    {
                        System.Threading.Thread.Sleep(2000);
                        SafeWriteLine("Mauvaise réponse");
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2000);
                        SafeWriteLine("Bien joué !");
                    }

                }
                //else if (position.x < 0 && position.z > 0)
                else if (position.x < izoneNeutreNegative && position.z > 0)
                {
                    SafeWriteLine("Vous choississez la réponse 3");
                    if (bonneReponse != 3)
                    {
                        System.Threading.Thread.Sleep(2000);
                        SafeWriteLine("Mauvaise réponse");
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2000);
                        SafeWriteLine("Bien joué !");
                    }
                }
                //else if (position.x > 0 && position.z < 0)
                else if (position.x > izoneNeutrePositive && position.z < 0)
                {
                    SafeWriteLine("Vous choississez la réponse 2");
                    if (bonneReponse != 2)
                    {
                        System.Threading.Thread.Sleep(2000);
                        SafeWriteLine("Mauvaise réponse");
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2000);
                        SafeWriteLine("Bien joué !");
                    }
                }
                //else if (position.x > 0 && position.z > 0)
                else if (position.x > izoneNeutrePositive && position.z > 0)
                {
                    SafeWriteLine("Vous choississez la réponse 4");
                    if (bonneReponse != 4)
                    {
                        System.Threading.Thread.Sleep(2000);
                        SafeWriteLine("Mauvaise réponse");
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2000);
                        SafeWriteLine("Bien joué !");
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
                while (true) ;

            }
        }
    }
}