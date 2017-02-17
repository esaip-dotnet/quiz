using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Kinect;
using System.Threading;

namespace Kinect_firs
{
    //classe Principale contenant le main
    class Program

    {
        //Capteur kinect
        private static KinectSensor kinectSensor;
        private static BodyFrameReader bodyFrameReader = null;
        private static Body[] bodies = null;
        private static CoordinateMapper coordinateMapper = null;
        private const float InferredZPositionClamp = 0.1f;

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
                        //Dictionary<JointType, Point> jointPoints = new Dictionary<JointType, Point>();
                        JointType HandLeft =(Microsoft.Kinect.JointType) 7;
                        JointType HandRight = (Microsoft.Kinect.JointType)11;

                        // Pour chaques points du corps tracker
                        foreach (JointType jointType in joints.Keys)
                        {
                            // Heure de tacking
                            String hnow = DateTime.Now.ToString("mm:ss");

                            // Main gauche
                            CameraSpacePoint positionHL = joints[HandLeft].Position;
                            if (positionHL.Z < 0)
                            {
                                positionHL.Z = InferredZPositionClamp;
                            }
                            // Recherche des coordonées de la main gauche
                            DepthSpacePoint depthSpacePoint = coordinateMapper.MapCameraPointToDepthSpace(positionHL);
                            float LHandX = depthSpacePoint.X;
                            float LHandY = depthSpacePoint.Y;
                            Console.Clear();
                            Console.WriteLine("LHandX =" + LHandX + " " + "LHandY=" + LHandY);

                            // Main droite
                            CameraSpacePoint positionHR = joints[HandRight].Position;
                            if (positionHR.Z < 0)
                            {
                                positionHR.Z = InferredZPositionClamp;
                            }

                            // Recherche des coordonées de la main droite
                            DepthSpacePoint depthSpacePoint2 = coordinateMapper.MapCameraPointToDepthSpace(positionHR);
                            float RHand_X = depthSpacePoint2.X;
                            float RHand_Y = depthSpacePoint2.Y;
                            Console.WriteLine("RHand_X =" + RHand_X + " " + "RHand_Y=" + RHand_Y);
                        }

                        // Timer
                        int milliseconds = 500;
                        Thread.Sleep(milliseconds);


                    }else{
                        Console.WriteLine("Body Not Track");         
                    }
                }

            }else{
                Console.WriteLine("Data NOT Received");          
            }
        } 
    }
}
        
    










