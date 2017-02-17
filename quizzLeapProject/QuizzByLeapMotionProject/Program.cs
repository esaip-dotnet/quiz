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
    class SampleListener : Listener
    {
        // Constantes permettant de définir le zones à ne pas prendre en compte afin d'éviter des confusions
        const int izoneNeutreNegative = -100;
        const int izoneNeutrePositive = 100;
        // Constante pour le rayon des zones de réponses personnalisées
        const int rayonZone = 150;
        // Utilisée pour afficher un message dans la console
        private Object thisLock = new Object();
        // Objet de la classe quizz
        private Quiz quiz;
        //id du quizz en cours
        private static int idQuiz = 1;
        // Variable utilisée pour définir la question à afficher
        private static int iCompteurQuestion = 0;
        // Contient les questions 
        private static String[] Question = new String[4] { "Quelle est la couleur du cheval blanc d'Henri IV ?", "Quelle est l'évolution du Pokémon M.Mime ?", "Est-ce que les nains dépensent car au supermarché les produits les moins sont tout en bas ?", "Peut-on faire de la confiture de coings dans une casserole ronde ?" };
        // Contient toutes les réponses possibles 
        private static String[] reponses1 = new String[] { "Noir", "Blanc", "La réponse D", "Obi-wan kenobi" };
        private static String[] reponses2 = new String[] { "Mme.Mime", "Grand-père.Mime", "Alakazam", "Il n'en a pas" };
        private static String[] reponses3 = new String[] { "Oui", "Non", "Alerte discrimination", "Oui si c'est de la bière" };
        private static String[] reponses4 = new String[] { "Oui", "Non", "Arrêtez les réponses stupides", "C'est dans les vieux pots qu'on fait la meilleure confiture" };
        // Permet de définir les bonnes réponses
        private static int[] itTabReponses = new int[] { 2, 4, 3, 3 };
        // Variable des zones de réponses de l'utilisateur
        private static float[] centreRep1;
        private static float[] centreRep2;
        private static float[] centreRep3;
        private static float[] centreRep4;
        // Permet de définir si c'est le lancement de l'application
        private static Boolean firstStart = true;
        // Variable qui permet de définir au programme quelle zone de réponse est à configurer
        private static int firstStartNumRep = 0;
        // Permet de vérifier si toutes les zones de réponses ont bien été toutes sauvegardées
        private static Boolean[] positionsSauvegardees = { false, false, false, false };

        // Lancement le programme
        public void initSampleListener()
        {
            SelectionPosition();

            if (positionsSauvegardees[0] && positionsSauvegardees[1] && positionsSauvegardees[2] && positionsSauvegardees[3])
            {
                AffichageQuestion(1);
            }
        }

        // Affiche un message dans la console
        private void SafeWriteLine(String line)
        {
            lock (thisLock)
            {
                Console.WriteLine(line);
            }
        }

        // Se lance lorsque que l'initialisation a commencé
        public override void OnInit(Controller controller)
        {
            SafeWriteLine("Initialized\n");
        }

        // Se lance lorsque la connection est établi
        public override void OnConnect(Controller controller)
        {
            SafeWriteLine("Connected\n");
            controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
            controller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }

        // Se lance lorsque la connection est perdu
        public override void OnDisconnect(Controller controller)
        {
            SafeWriteLine("Disconnected\n");
        }

        // Se lance lorsque l'on ferme l'application
        public override void OnExit(Controller controller)
        {
            SafeWriteLine("Exited\n");
        }

        // Fonction permettant de demander à l'utilisateur de sauvegarder ses zones de réponses
        private void SelectionPosition()
        {
            SafeWriteLine("Préparez-vous à sélectionner vos zones de réponses");
            System.Threading.Thread.Sleep(5000);

            // Tant que la zone pour la réponse 1 n'est pas sauvegardé, on demande à l'utilisateur de placer sa main
            while (positionsSauvegardees[0] == false)
            {
                SafeWriteLine("Placez votre main au niveau de la réponse 1");
                firstStartNumRep = 1;
                System.Threading.Thread.Sleep(5000);
            }

            // Si la zone de réponse précédente est sauvegardée
            if (positionsSauvegardees[0] == true)
            {
                // Tant que la zone pour la réponse 2 n'est pas sauvegardé, on demande à l'utilisateur de placer sa main
                while (positionsSauvegardees[1] == false)
                {
                    SafeWriteLine("Placez votre main au niveau de la réponse 2");
                    firstStartNumRep = 2;
                    System.Threading.Thread.Sleep(5000);
                }
            }

            // Si la zone de réponse précédente est sauvegardée
            if (positionsSauvegardees[1] == true)
            {
                // Tant que la zone pour la réponse 3 n'est pas sauvegardé, on demande à l'utilisateur de placer sa main
                while (positionsSauvegardees[2] == false)
                {
                    SafeWriteLine("Placez votre main au niveau de la réponse 3");
                    firstStartNumRep = 3;
                    System.Threading.Thread.Sleep(5000);
                }
            }

            // Si la zone de réponse précédente est sauvegardée
            if (positionsSauvegardees[2] == true)
            {
                // Tant que la zone pour la réponse 4 n'est pas sauvegardé, on demande à l'utilisateur de placer sa main
                while (positionsSauvegardees[3] == false)
                {
                    SafeWriteLine("Placez votre main au niveau de la réponse 4");
                    firstStartNumRep = 4;
                    System.Threading.Thread.Sleep(5000);
                }
            }
            firstStart = false;
        }

        // Affichage des questions et des 4 réponses possibles en fonction du numéro de la question
        public void AffichageQuestion(int iNumeroQuestion)
        {
            if (iNumeroQuestion == 1)
            {
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

        // Fonction permettant de passer à la question suivante et de terminer l'application s'il n'y a plus de question
        public void SwitchQuestion()
        {
            iCompteurQuestion++;
            if (iCompteurQuestion > Question.Length)
            {
                SafeWriteLine("Fin du quiz !\n Merci de votre participation.");
                Environment.Exit(0);
            }
            else
            {
                AffichageQuestion(iCompteurQuestion);
            }
        }

        // Fonction permettant de calculer la distance entre 2 points du plan
        public float calculDistance(float positionX1, float positionZ1, float positionX2, float positionZ2)
        {
            float distance = (float)(Math.Sqrt(((positionX1 - positionX2) * (positionX1 - positionX2)) + ((positionZ1 - positionZ2) * (positionZ1 - positionZ2))));

            return distance;
        }

        // Fonction qui va contamment être appelée. C'est ici que l'on récupère la position de la main
        public override void OnFrame(Controller controller)
        {
            Frame frame = controller.Frame();
            Hand hand = frame.Hands.Rightmost;
            Vector position = hand.PalmPosition;
            float timeVisible = hand.TimeVisible;

            // On entre dans le if, uniquement si c'est le lancement de l'application
            if (firstStart == true)
            {
                // Permet d'empècher l'application de sauvegarder une position même si l'utilisateur ne place pas sa main
                if (position.x != 0 && position.y != 0 && position.z != 0)
                {
                    if (firstStartNumRep == 1)
                    {
                        System.Threading.Thread.Sleep(2000);

                        // Enregistre la zone de réponse 1
                        centreRep1 = new float[] { position.x, position.y, position.z };
                        positionsSauvegardees[0] = true;
                        SafeWriteLine("Position 1 sauvegardée");

                        //SafeWriteLine("x = " + centreRep1[0].ToString() + " et z = " + centreRep1[2].ToString());
                    }
                    if (firstStartNumRep == 2)
                    {
                        System.Threading.Thread.Sleep(2000);

                        // Calcul des distances entre la zone que nous voulons créer et la zone précédente
                        float distRep1Rep2 = calculDistance(position.x, position.z, centreRep1[0], centreRep1[2]);

                        // On vérifie que la zone a créer est à une distance suffisante de l'autre
                        if (distRep1Rep2 < 2 * rayonZone)
                        {
                            SafeWriteLine("Ecartez-vous de la zone 1");
                        }
                        else
                        {
                            // Enregistre la zone de réponse 2
                            centreRep2 = new float[] { position.x, position.y, position.z };
                            positionsSauvegardees[1] = true;
                            SafeWriteLine("Position 2 sauvegardée");

                            //SafeWriteLine("x = " + centreRep2[0].ToString() + " et z = " + centreRep2[2].ToString());
                        }
                    }
                    if (firstStartNumRep == 3)
                    {
                        System.Threading.Thread.Sleep(2000);

                        // Calcul des distances entre la zone que nous voulons créer et les zones précédentes
                        float distRep1Rep3 = calculDistance(position.x, position.z, centreRep1[0], centreRep1[2]);
                        float distRep2Rep3 = calculDistance(position.x, position.z, centreRep2[0], centreRep2[2]);

                        // On vérifie que la zone a créer est à une distance suffisante des 2 autres
                        if (distRep1Rep3 < 2 * rayonZone)
                        {
                            SafeWriteLine("Ecartez-vous de la zone 1");
                        }
                        else if (distRep2Rep3 < 2 * rayonZone)
                        {
                            SafeWriteLine("Ecartez-vous de la zone 2");
                        }
                        else
                        {
                            // Enregistre la zone de réponse 3
                            centreRep3 = new float[] { position.x, position.y, position.z };
                            positionsSauvegardees[2] = true;
                            SafeWriteLine("Position 3 sauvegardée");

                            //SafeWriteLine("x = " + centreRep3[0].ToString() + " et z = " + centreRep3[2].ToString());
                        }
                    }
                    if (firstStartNumRep == 4)
                    {
                        System.Threading.Thread.Sleep(2000);

                        // Calcul des distances entre la zone que nous voulons créer et les zones précédentes
                        float distRep1Rep4 = calculDistance(position.x, position.z, centreRep1[0], centreRep1[2]);
                        float distRep2Rep4 = calculDistance(position.x, position.z, centreRep2[0], centreRep2[2]);
                        float distRep3Rep4 = calculDistance(position.x, position.z, centreRep3[0], centreRep3[2]);

                        // On vérifie que la zone a créer est à une distance suffisante des 3 autres
                        if (distRep1Rep4 < 2 * rayonZone)
                        {
                            SafeWriteLine("Ecartez-vous de la zone 1");
                        }
                        else if (distRep2Rep4 < 2 * rayonZone)
                        {
                            SafeWriteLine("Ecartez-vous de la zone 2");
                        }
                        else if (distRep3Rep4 < 2 * rayonZone)
                        {
                            SafeWriteLine("Ecartez-vous de la zone 3");
                        }
                        else
                        {
                            // Enregistre la zone de réponse 4
                            centreRep4 = new float[] { position.x, position.y, position.z };
                            positionsSauvegardees[3] = true;
                            SafeWriteLine("Position 4 sauvegardée");

                            //SafeWriteLine("x = " + centreRep4[0].ToString() + " et z = " + centreRep4[2].ToString());
                        }
                    }
                }
            }

            // On vérifie que toutes les positions de réponses ont bien été sauvegardées
            else if (positionsSauvegardees[0] && positionsSauvegardees[1] && positionsSauvegardees[2] && positionsSauvegardees[3])
            {
                if (position.x != 0 && position.y != 0 && position.z != 0)
                {
                    //Calcul de la distance du point avec chaque zone
                    float[] distRep = {calculDistance(position.x, position.z, centreRep1[0], centreRep1[2]), 
                                          calculDistance(position.x, position.z, centreRep2[0], centreRep2[2]),
                                          calculDistance(position.x, position.z, centreRep3[0], centreRep3[2]),
                                          calculDistance(position.x, position.z, centreRep4[0], centreRep4[2])};

                    // On vérifie si l'utilisateur est dans l'une des 4 zones
                    for (int i = 0; i < 4; i++)
                    {
                        if (distRep[i] < rayonZone)
                        {
                            SafeWriteLine("Vous choississez la réponse " + (i + 1));

                            // On vérifie si la réponse est bonne
                            if (itTabReponses[iCompteurQuestion] != (i + 1))
                            {
                                System.Threading.Thread.Sleep(1000);
                                SafeWriteLine("Mauvaise réponse");
                            }
                            else
                            {
                                System.Threading.Thread.Sleep(1000);
                                SafeWriteLine("Bien joué !");
                                SwitchQuestion();
                            }
                        }
                    }
                }
            }
            System.Threading.Thread.Sleep(3000);
        }

        class Sample
        {
            public static void Main()
            {
                // Crée un listener et un controller
                SampleListener listener = new SampleListener();
                Controller controller = new Controller();

                // L'application s'arrète quand on presse échap
                controller.AddListener(listener);
                Console.WriteLine("Appuyez sur la touche échape pour quitter: \n");
                listener.initSampleListener();
                while (true) ;
            }
        }
    }
}