using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Importation des Librairies Kinect et Microsoft
using Microsoft.Kinect;
using System.Threading;

namespace Kinect_firs
{
    class Program

    {
        // Récupération des fonctions Kinect
        private static KinectSensor kinectSensor;
        private static BodyFrameReader bodyFrameReader = null;
        private static Body[] bodies = null;
        private static CoordinateMapper coordinateMapper = null;
        private const float InferredZPositionClamp = 0.1f;

        // Points du corps
        static JointType HandRight;
        static JointType MidSpine;
        static float RHand_X;
        static float RHand_Y;
        static float MSpine_X;
        static float MSpine_Y;

        static void Main(string[] args)
        {
            // Lancement du premier Capteur
            kinectSensor = KinectSensor.GetDefault();
            coordinateMapper = kinectSensor.CoordinateMapper;
            // Ouverture du premier capteur
            kinectSensor.Open();

            // Lancement de la recherche d'un corps
            bodyFrameReader = kinectSensor.BodyFrameSource.OpenReader();
            if (bodyFrameReader != null)
            {
                // Tentative d'accès
                try
                {
                    bodyFrameReader.FrameArrived += Reader_FrameArrived;
                }
                // Vérification d'une exception dans la recherche
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            // En cas de recherche infructueuse, on arrête
            else
            {
                Console.WriteLine("BodyFrameReader is null");
            }
            Console.ReadLine();
        }

        // Vérification la zone de la main droite
        static String checkZoneRH()
        {
            String zoneHand;
            if (RHand_X < MSpine_X && RHand_Y < MSpine_Y)
                zoneHand = "Zone 1";
            else if (RHand_X > MSpine_X && RHand_Y < MSpine_Y)
                zoneHand = "Zone 2";
            else if (RHand_X < MSpine_X && RHand_Y > MSpine_Y)
                zoneHand = "Zone 3";
            else if (RHand_X > MSpine_X && RHand_Y > MSpine_Y)
                zoneHand = "Zone 4";
            else
                zoneHand = "Hand not found";

            return zoneHand;
        }

        // Lecture du capteur
        static void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
          // Test de réception de données
            bool dataReceived = false;

            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame != null)
                {
                    if (bodies == null)
                        bodies = new Body[bodyFrame.BodyCount];
                    bodyFrame.GetAndRefreshBodyData(bodies);
                    dataReceived = true;
                }
            }
            // Si des données sont reçues
            if (dataReceived)
            {
                // Pour chaque partie du corps
                foreach (Body body in bodies)
                {
                    if (body.IsTracked)
                    {
                        // Récupération des fonctions de détection des parties du corps humain dans la librairie Kinect
                        IReadOnlyDictionary<JointType, Joint> joints = body.Joints;

                        // Récupération des élements Main Gauche, Main Gauche et Tete
                        JointType HandRight = (Microsoft.Kinect.JointType)11;
                        JointType Head = (Microsoft.Kinect.JointType)3;

                        // Pour chaque points du corps tracker
                        foreach (JointType jointType in joints.Keys)
                        {
                            // Heure de tacking
                            String hnow = DateTime.Now.ToString("mm:ss");

                            // Tentative de détection de la Main Droite
                            CameraSpacePoint positionHR = joints[HandRight].Position;
                            if (positionHR.Z < 0)
                            {
                              positionHR.Z = InferredZPositionClamp;
                            }

                            // Récuperation des coordonnées X,Y de la main droite
                            DepthSpacePoint depthSpacePoint2 = coordinateMapper.MapCameraPointToDepthSpace(positionHR);
                            RHand_X = depthSpacePoint2.X;
                            RHand_Y = depthSpacePoint2.Y;

                            // Milieu de la colonne
                            CameraSpacePoint positionMS = joints[MidSpine].Position;
                            if (positionMS.Z < 0)
                            {
                                positionMS.Z = InferredZPositionClamp;
                            }
                            // Recherche des coordonées du milieu de la colonne
                            DepthSpacePoint depthSpacePoint3 = coordinateMapper.MapCameraPointToDepthSpace(positionMS);
                            MSpine_X = depthSpacePoint3.X;
                            MSpine_Y = depthSpacePoint3.Y;
                            String zoneMain = checkZoneRH();
                            Console.WriteLine(zoneMain);
                        }

                        // Pause pour laisser le temps au système d'afficher la donnée
                        int milliseconds = 500;
                        Thread.Sleep(milliseconds);
                    }
                    // Annonce qu'aucun corps n'a été trouvé
                    else
                    {
                        Console.WriteLine("Body Not TRack");
                    }
                }
            }

            // Confirmation écrite qu'aucune donnée n'a été recue
            else
            {
                Console.WriteLine("Data NOT Received");
            }
        }
    }
}
