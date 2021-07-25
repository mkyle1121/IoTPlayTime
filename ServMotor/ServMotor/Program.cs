using System;
using Iot.Device.ServoMotor;
using System.Device.Pwm;
using System.Threading;

namespace ServMotor
{
    class Program
    {
        static void Main(string[] args)
        {

            var pwm = PwmChannel.Create(0, 0, 50, .05);
            pwm.Start();

            ServoMotor servo = new ServoMotor(pwm);
            servo.Start();

            /*
            while (true)
            {
                Console.WriteLine("Set 0");
                servo.WriteAngle(0);

                Thread.Sleep(2000);

                Console.WriteLine("Set 90");
                servo.WriteAngle(90);

                Thread.Sleep(2000);

                Console.WriteLine("Set 180");
                servo.WriteAngle(180);

                Thread.Sleep(2000);
            } 
            */

            while (true)
            {
                for (int i = 0; i <= 180; i++)
                {
                    Console.WriteLine($"Angle {i}");
                    servo.WriteAngle(i);
                    Thread.Sleep(5);
                }

                for (int i = 180; i >= 0; i--)
                {
                    Console.WriteLine($"Angle {i}");
                    servo.WriteAngle(i);
                    Thread.Sleep(5);
                }
            }
        }
    }
}
