using System;
using System.Device.Gpio;
using System.Threading;
using System.Diagnostics;

namespace MotionSensor
{
    class Program
    {
        static void Main()
        {       
            var controller = new GpioController();
            controller.OpenPin(17, PinMode.Input);         

            while (true)
            {
                if (controller.Read(17) == PinValue.High)
                {
                    Console.WriteLine("Something is there!");

                    DateTime date = DateTime.Now;
                    TimeSpan time = date.TimeOfDay;

                    Console.WriteLine("Taking A Picture!");
                    ProcessStartInfo startInfo = new ProcessStartInfo("raspistill", $"-o /home/pi/images/{time}.jpg");
                    Process process = Process.Start(startInfo);
                    process.WaitForExit();
                    Console.WriteLine("Done...");                                       

                }
                else if (controller.Read(17) == PinValue.Low)
                {
                    //Console.WriteLine("Nothing is there.");
                    Thread.Sleep(50);
                }
            }
        }
    }
}
