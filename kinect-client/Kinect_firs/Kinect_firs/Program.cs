using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Kinect;
using System.Threading;

namespace Kinect_firs
{
    // Classe Principale contenant le main
    class Program

    {
        // Capteur kinect
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

        // Fonction Main
        static void Main(string[] args){
            
            // Attribution de la kinect à l'objet kinect sensor   
            kinectSensor = KinectSensor.GetDefault();
            coordinateMapper = kinectSensor.CoordinateMapper;
            // Ouvre le capteur
            kinectSensor.Open();
            
            bodyFrameReader = kinectSensor.BodyFrameSource.OpenReader();
            
            if (bodyFrameReader != null) {
                try{
                    bodyFrameReader.FrameArrived += Reader_FrameArrived;
                }
                catch(Exception e){
                    Console.WriteLine(e);
                }
            }else{
                Console.WriteLine("BodyFrameReader is null");
            }
            Console.ReadLine();
        }

        // Verifier la zone de la main droite
        static String checkZoneLH()
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
        static void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e){

            // Test de réception de données
            bool dataReceived = false;

            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame()){

                if (bodyFrame != null){
                    if (bodies == null)
                       bodies = new Body[bodyFrame.BodyCount];
                       bodyFrame.GetAndRefreshBodyData(bodies);
                       dataReceived = true;
                }
            }

            // Si des données sont reçus 
            if (dataReceived){

                // Pour chaques partie du corps
                foreach (Body body in bodies){
                    if (body.IsTracked){
                        
                        // Définition des points tracker
                        IReadOnlyDictionary<JointType, Joint> joints = body.Joints;
                        HandRight = (Microsoft.Kinect.JointType) 11;
                        MidSpine = (Microsoft.Kinect.JointType) 1;

                        // Pour chaques points du corps tracker
                        foreach (JointType jointType in joints.Keys)
                        {
                            // Heure de tacking
                            String hnow = DateTime.Now.ToString("mm:ss");

                            // Main droite
                            CameraSpacePoint positionHR = joints[HandRight].Position;
                            if (positionHR.Z < 0)
                            {
                                positionHR.Z = InferredZPositionClamp;
                            }
                            // Recherche des coordonées de la main droite
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

                            String zoneMain = checkZoneLH();
                            Console.WriteLine(zoneMain);
                        }

                        // Timer
                        int milliseconds = 500;
                        Thread.Sleep(milliseconds);
                        Console.Clear();
                    }
                }

            }else{
                Console.WriteLine("Data NOT Received");          
            }
        }
    }
}
        
    










