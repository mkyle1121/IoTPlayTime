using System;
using System.Collections.Generic;
using System.Threading;
using Iot.Device.KeyMatrix;
using System.Device.Gpio;

namespace KeypadMatrix
{
    class Program
    {
        static void Main()
        {
            IEnumerable<int> outputs = new int[] { 26, 19, 13, 6 };
            IEnumerable<int> inputs = new int[] { 21, 20, 16, 12 };        
            KeyMatrix keyMatrix = new KeyMatrix(outputs, inputs, TimeSpan.FromMilliseconds(20));

            Console.WriteLine("Ready to Listen...");
            keyMatrix.KeyEvent += KeyMatrix_KeyEvent;
            keyMatrix.StartListeningKeyEvent();            
                        
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(1);         
            }           
        }

        private static void KeyMatrix_KeyEvent(object sender, KeyMatrixEvent keyMatrixEvent)
        {
            var pin21 = new GpioController();
            pin21.OpenPin(21);
            if (pin21.Read(21) == PinValue.High)
            {
                Console.WriteLine("A was pressed?");
            }
        }
    }
}
