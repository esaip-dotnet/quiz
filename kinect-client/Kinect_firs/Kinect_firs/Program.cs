using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Importation des Librairies Kinect / Microsoft*/
using Microsoft.Kinect;
using System.Threading;

namespace Kinect_firs
{
    class Program

    {
        /*Recuperation des Fonctions Kinect*/
        private static KinectSensor kinectSensor;
        private static BodyFrameReader bodyFrameReader = null;
        private static Body[] bodies = null;
        private static CoordinateMapper coordinateMapper = null;
        private const float InferredZPositionClamp = 0.1f;


        static void Main(string[] args)
        {

            /*Lancement du premier Capteur*/
            kinectSensor = KinectSensor.GetDefault();
            coordinateMapper = kinectSensor.CoordinateMapper;
            /*Ouverture du premier capteur*/
            kinectSensor.Open();

            /*Lancement de la recherche d'un corps*/
            bodyFrameReader = kinectSensor.BodyFrameSource.OpenReader();
            if (bodyFrameReader != null)
            {
                /*Tentative d'acces*/
                try
                {
                    bodyFrameReader.FrameArrived += Reader_FrameArrived;

                }
                /*Verification d'une exception dans la recherche*/
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }

            }
            /*En cas de recherche infructueuse > on arrete */
            else
            {
                Console.WriteLine("BodyFrameReader is null");
            }

            Console.ReadLine();
        }


        static void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
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
            if (dataReceived)
            {

                //Console.ReadLine();
                foreach (Body body in bodies)
                {
                    if (body.IsTracked)
                    {

                        /*Recuperation des fonctions de detection des parties du corps humain dans la librairies Kinect*/
                        IReadOnlyDictionary<JointType, Joint> joints = body.Joints;

                        /*Recuperation des Elements Main Gauche, Main Gauche et Tete*/
                        JointType HandLeft = (Microsoft.Kinect.JointType)7;
                        JointType HandRight = (Microsoft.Kinect.JointType)11;
                        JointType Head = (Microsoft.Kinect.JointType)3;

                        foreach (JointType jointType in joints.Keys)
                        {
                            /*Creation d'une fonction de Pause (Break) */
                            String hnow = DateTime.Now.ToString("mm:ss");

                            /*Tentative de Detection de la Main gauche */
                            CameraSpacePoint positionHL = joints[HandLeft].Position;
                            if (positionHL.Z < 0)
                                positionHL.Z = InferredZPositionClamp;

                            /*Recuperation des Coordonnées X,Y de la main gauche*/
                            DepthSpacePoint depthSpacePoint = coordinateMapper.MapCameraPointToDepthSpace(positionHL);
                            float LHandX = depthSpacePoint.X;
                            float LHandY = depthSpacePoint.Y;
                            Console.Clear();
                            Console.WriteLine("LHandX =" + LHandX + " " + "LHandY=" + LHandY);

                            /*Tentative de Detection de la Main Droite  */
                            CameraSpacePoint positionHR = joints[HandRight].Position;
                            if (positionHR.Z < 0)
                                positionHR.Z = InferredZPositionClamp;

                            /*Recuperation des Coordonnées X,Y de la main Droite*/
                            DepthSpacePoint depthSpacePoint2 = coordinateMapper.MapCameraPointToDepthSpace(positionHR);
                            float RHand_X = depthSpacePoint.X;
                            float RHand_Y = depthSpacePoint.Y;
                      
                            Console.WriteLine("RHand_X =" + RHand_X + " " + "RHand_Y=" + RHand_Y);
                        }
                        /*Recherche de la Position de la tete*/
                        CameraSpacePoint positionHead = joints[Head].Position;
                        if (positionHead.Z < 0)
                            positionHead.Z = InferredZPositionClamp;

                        /*Recuperation de la localisation de la tete (X,Y) */
                        DepthSpacePoint depthSpacePointH = coordinateMapper.MapCameraPointToDepthSpace(positionHead);
                        float Head_X = depthSpacePointH.X;
                        float Head_Y = depthSpacePointH.Y;

                        /*Affichage des coordonnées de la tete*/
                        Console.WriteLine("Head_X =" + Head_X + " " + "Head_Y" + Head_Y);
                        /*Pause pour laisser le temps au systeme d'afficher la donnée*/
                        int milliseconds = 5000;
                        Thread.Sleep(milliseconds);


                    }
                    /*Annonce qu'aucun corps n'a été trouvé*/
                    else
                    {
                        Console.WriteLine("Body Not TRack");

                    }
                }

            }

            /*Confirmation Ecrite qu'aucune donnée n'ait été recu*/
            else
            {
                Console.WriteLine("Data NOT Received");

            }
        }
    }
}

