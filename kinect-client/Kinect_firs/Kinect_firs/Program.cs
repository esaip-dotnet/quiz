using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Kinect;
using System.Threading;

namespace Kinect_firs
{
    class Program

    {
       // private static ColorFrameReader colorFrameReader; 
        private static KinectSensor kinectSensor;
        private static BodyFrameReader bodyFrameReader = null;
        private static Body[] bodies = null;
        private static CoordinateMapper coordinateMapper = null;
        private const float InferredZPositionClamp = 0.1f;
       
        // private static DrawingGroup drawingGroup;
        //private static DrawingImage imageSource;

        static void Main(string[] args)
        {
            
            // one sensor is currently supported
            kinectSensor = KinectSensor.GetDefault();
            coordinateMapper = kinectSensor.CoordinateMapper;
            // open the sensor
            kinectSensor.Open();
            
            bodyFrameReader = kinectSensor.BodyFrameSource.OpenReader();
           if (bodyFrameReader != null) {
                
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
                
        /// <summary>
        /// Cette fonction est appellée dès que l'on reçoit des frames depuis la kinnect
        /// On commence d'abord par testé si l'on reçoit bien des frames.
        /// Puis pour chaque partie du corps répertoriée, on calcul et affiche la position
        /// </summary>
        /// <param name=sender></param>
        /// <param name=BodyFrameArrivedEventArgs>Réception de l'évènement</param>
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
                        
                       
                        IReadOnlyDictionary<JointType, Joint> joints = body.Joints;
                        //Dictionary<JointType, Point> jointPoints = new Dictionary<JointType, Point>();
                        JointType HandLeft =(Microsoft.Kinect.JointType) 7;
                        JointType HandRight = (Microsoft.Kinect.JointType)11;
                        JointType Head = (Microsoft.Kinect.JointType)3;

                        foreach (JointType jointType in joints.Keys)
                        {

                            String hnow=DateTime.Now.ToString("mm:ss");
                            CameraSpacePoint positionHL = joints[HandLeft].Position;
                            if (positionHL.Z < 0)
                                positionHL.Z = InferredZPositionClamp;

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
                                //Console.Clear();
                                Console.WriteLine("RHand_X =" + RHand_X + " " + "RHand_Y=" + RHand_Y);
                            }
                            CameraSpacePoint positionHead = joints[Head].Position;
                            if (positionHead.Z < 0)
                                positionHead.Z = InferredZPositionClamp;

                            DepthSpacePoint depthSpacePointH = coordinateMapper.MapCameraPointToDepthSpace(positionHead);
                            float Head_X = depthSpacePointH.X;
                            float Head_Y = depthSpacePointH.Y;
                           // Console.Clear();
                            Console.WriteLine("Head_X =" + Head_X + " " + "Head_Y" + Head_Y);
                        int milliseconds = 5000;
                        Thread.Sleep(milliseconds);


                    }
                    else
                    {
                      //  Console.WriteLine("Body Not TRack");
                       
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