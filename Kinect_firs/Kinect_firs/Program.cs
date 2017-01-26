using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;


namespace Kinect_firs
{
    class Program

    {
        private static ColorFrameReader colorFrameReader;
        private static KinectSensor kinectSensor;
        event EventHandler<DepthFrameArrivedEventArgs> FrameArrived;
        static void Main(string[] args)
        {


            // one sensor is currently supported
            kinectSensor = KinectSensor.GetDefault();



            // open the sensor
            kinectSensor.Open();
            if (!kinectSensor.IsOpen)
            {
                Console.WriteLine("CLOSE");
                Console.Read();
            }
            else
            {
                Console.WriteLine("OPEN");
                Console.Read();
                //evenement lorsque frame 
               /* if (FrameArrived != null)
                {

                }
                    Changed(this, e);
               
                //recuperation frame 
                DepthFrameSource DepthFrameSource
            }
          */
            // kinectSensor.ColorStream.Enable();

            // kinectSensor.ColorStream.Enable();
            //kinectSensor.DepthStream.Enable();
            // kinectSensor.SkeletonStream.Enable();
        }
    }

    /*foreach (Skeleton skeleton in skeletons)
     {
         // get the joint
         Joint rightHand = skeleton.Joints[JointType.HandRight];

         // get the individual points of the right hand
         double rightX = rightHand.Position.X;
         double rightY = rightHand.Position.Y;
         double rightZ = rightHand.Position.Z;
     }
*/

    //kinectSensor.InitializeComponent();
}







