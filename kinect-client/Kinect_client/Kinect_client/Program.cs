using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Kinect;
using System.Threading;

namespace Kinect_client
{
    class Program

    {
        //Déclaration de l'objet Kinect
        private static KinectSensor kinectSensor;
        //Déclaration du conteneur
        private static BodyFrameReader bodyFrameReader = null;
        //Déclaration de tableau contenant les futures corps détectés
        private static Body[] bodies = null;
        //Déclaration objet permettant récupération données
        private static CoordinateMapper coordinateMapper = null;
        private const float InferredZPositionClamp = 0.1f;
        static void Main(string[] args)
        {
            //On implémente l'objet Kinect
            kinectSensor = KinectSensor.GetDefault();
            coordinateMapper = kinectSensor.CoordinateMapper;
            //Ouvre la connexion de la kinect
            kinectSensor.Open();
            //On ouvre un conteneur
            bodyFrameReader = kinectSensor.BodyFrameSource.OpenReader();
           if (bodyFrameReader != null) {
                //Si ce conteneur n'est pas vide alors on va lire les données de la Kinect
                try
                {
                    bodyFrameReader.FrameArrived += Reader_FrameArrived;
                }
                catch(Exception e)
                {   
                    Console.WriteLine(e);
                }
            }
            else
            {
                Console.WriteLine("BodyFrameReader is null");
            }
            Console.ReadLine();
        }
        //Fonction permettant d'aller lire coordonnées de la Kinect
        static void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            bool dataReceived = false;
            //On utilise la frame générée par la Kinect
            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                //Si elle est nulle on test si un corps a été détecté
                if (bodyFrame != null)
                {
                    //Si aucun corps n'a été détecté on implémente l'objet bodies 
                    if (bodies == null)
                       bodies = new Body[bodyFrame.BodyCount];
                       bodyFrame.GetAndRefreshBodyData(bodies);
                       dataReceived = true;
                }
            }
            //Si on a reçu les données alors on exécute le code ci-dessous
            if (dataReceived)
            {
                foreach (Body body in bodies)
                {
                    //pour chaque corps détecté on va aller lire les coordonnées 
                     if (body.IsTracked)
                    {
                        //On définit les points qu'on veut récupérer (Main gauche,Main droite,Tête)
                        IReadOnlyDictionary<JointType, Joint> joints = body.Joints;
                        JointType HandLeft =(Microsoft.Kinect.JointType) 7;
                        JointType HandRight = (Microsoft.Kinect.JointType)11;
                        JointType Head = (Microsoft.Kinect.JointType)3;
                        foreach (JointType jointType in joints.Keys)
                        {
                            String hnow=DateTime.Now.ToString("mm:ss");
                            CameraSpacePoint positionHL = joints[HandLeft].Position;
                            if (positionHL.Z < 0)
                                positionHL.Z = InferredZPositionClamp;
                            //On récupère les coordonnées de la main gauche puis on les affiches 
                            DepthSpacePoint depthSpacePoint = coordinateMapper.MapCameraPointToDepthSpace(positionHL);
                            float LHandX = depthSpacePoint.X;
                            float LHandY = depthSpacePoint.Y;
                            Console.Clear();
                            Console.WriteLine("LHandX =" + LHandX + " " + "LHandY=" + LHandY);
                            CameraSpacePoint positionHR = joints[HandRight].Position;
                            if (positionHR.Z < 0)
                               positionHR.Z = InferredZPositionClamp;
                            DepthSpacePoint depthSpacePoint2 = coordinateMapper.MapCameraPointToDepthSpace(positionHR);
                            float RHand_X = depthSpacePoint.X;
                            float RHand_Y = depthSpacePoint.Y;
                                Console.WriteLine("RHand_X =" + RHand_X + " " + "RHand_Y=" + RHand_Y);
                            }
                            CameraSpacePoint positionHead = joints[Head].Position;
                            if (positionHead.Z < 0)
                                positionHead.Z = InferredZPositionClamp;
                            DepthSpacePoint depthSpacePointH = coordinateMapper.MapCameraPointToDepthSpace(positionHead);
                            float Head_X = depthSpacePointH.X;
                            float Head_Y = depthSpacePointH.Y;
                            Console.WriteLine("Head_X =" + Head_X + " " + "Head_Y" + Head_Y);
                            int milliseconds = 5000;
                            Thread.Sleep(milliseconds);
                    }
                }
            }
            else
            {
                Console.WriteLine("Data NOT Received");
              
            }
            } 
    }
}
        
    










