using System;
using System.Threading.Tasks;
using MMALSharp;
using MMALSharp.Common;
using MMALSharp.Handlers;

namespace PiCamera
{
    class Program
    {

        static void TakePicture()
        {
            MMALCamera cam = MMALCamera.Instance;
            MMALCameraConfig.ShutterSpeed = 2000000;

            using (var imgCaptureHandler = new ImageStreamCaptureHandler("/home/pi/images/", "jpg"))
            {
                Console.WriteLine("Taking Picture.");
                cam.TakePicture(imgCaptureHandler, MMALEncoding.JPEG, MMALEncoding.I420);
            }         

            Console.WriteLine("Cleanup Starting.");
            cam.Cleanup();
            Console.WriteLine("Done with Cleanup.");
        }


        static void Main()
        {
            TakePicture();
            
        }
    }
}
