using System;
using System.Device.Gpio;
using System.Threading;

namespace BlinkLED
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new GpioController();
            controller.OpenPin(17, PinMode.Output);

            while (true)
            {
                controller.Write(17, PinValue.High);
                Thread.Sleep(1000);
                controller.Write(17, PinValue.Low);
                Thread.Sleep(1000);
            }
        }
    }
}
