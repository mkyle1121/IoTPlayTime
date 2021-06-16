using System;
using System.Collections.Generic;
using System.Threading;
using Iot.Device.KeyMatrix;
using System.Device.Gpio;

namespace KeypadMatrix
{
    class Program
    {

        //https://toscode.gitee.com/kinglinglive/iot/blob/dependabot/nuget/src/System.Device.Gpio.Tests/Moq-4.16.1/src/devices/KeyMatrix/README.md
        static void Main()
        {
            IEnumerable<int> outputs = new int[] { 6, 13, 19, 26 };
            IEnumerable<int> inputs = new int[] { 12, 16, 20, 21 };        
            KeyMatrix keyMatrix = new KeyMatrix(outputs, inputs, TimeSpan.FromMilliseconds(20));

            Console.WriteLine("Press a Button...");
            //keyMatrix.KeyEvent += KeyMatrix_KeyEvent;
            //keyMatrix.StartListeningKeyEvent();            
                        
            while (true)
            {
                KeyMatrixEvent key = keyMatrix.ReadKey();
                
                if (key.Input == 0 && key.Output == 0 && key.EventType == PinEventTypes.Rising)
                    Console.WriteLine("1");
                else if (key.Input == 1 && key.Output == 0 && key.EventType == PinEventTypes.Rising)
                    Console.WriteLine("2");
                else if (key.Input == 2 && key.Output == 0 && key.EventType == PinEventTypes.Rising)
                    Console.WriteLine("3");
                else if (key.Input == 3 && key.Output == 0 && key.EventType == PinEventTypes.Rising)
                    Console.WriteLine("A");
                else if (key.Input == 0 && key.Output == 1 && key.EventType == PinEventTypes.Rising)
                    Console.WriteLine("4");
                else if (key.Input == 1 && key.Output == 1 && key.EventType == PinEventTypes.Rising)
                    Console.WriteLine("5");
                else if (key.Input == 2 && key.Output == 1 && key.EventType == PinEventTypes.Rising)
                    Console.WriteLine("6");
                else if (key.Input == 3 && key.Output == 1 && key.EventType == PinEventTypes.Rising)
                    Console.WriteLine("B");
                else if (key.Input == 0 && key.Output == 2 && key.EventType == PinEventTypes.Rising)
                    Console.WriteLine("7");
                else if (key.Input == 1 && key.Output == 2 && key.EventType == PinEventTypes.Rising)
                    Console.WriteLine("8");
                else if (key.Input == 2 && key.Output == 2 && key.EventType == PinEventTypes.Rising)
                    Console.WriteLine("9");
                else if (key.Input == 3 && key.Output == 2 && key.EventType == PinEventTypes.Rising)
                    Console.WriteLine("C");
                else if (key.Input == 0 && key.Output == 3 && key.EventType == PinEventTypes.Rising)
                    Console.WriteLine("*");
                else if (key.Input == 1 && key.Output == 3 && key.EventType == PinEventTypes.Rising)
                    Console.WriteLine("0");
                else if (key.Input == 2 && key.Output == 3 && key.EventType == PinEventTypes.Rising)
                    Console.WriteLine("#");
                else if (key.Input == 3 && key.Output == 3 && key.EventType == PinEventTypes.Rising)
                    Console.WriteLine("D");

                Thread.Sleep(1);         
            }            
        }        
    }
}
