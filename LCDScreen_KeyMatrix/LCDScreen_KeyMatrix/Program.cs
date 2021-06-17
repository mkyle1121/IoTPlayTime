using System;
using System.Collections.Generic;
using System.Threading;
using Iot.Device.KeyMatrix;
using System.Device.Gpio;
using Iot.Device.Pcx857x;
using System.Device.I2c;

namespace LCDScreen_KeyMatrix
{
    class Program
    {
        
        static I2cDevice i2cDevice = I2cDevice.Create(new I2cConnectionSettings(1, 0x3f));
        static Pcf8574 serialDriver = new Pcf8574(i2cDevice);

        static Iot.Device.CharacterLcd.Lcd1602 lcd = new Iot.Device.CharacterLcd.Lcd1602(dataPins: new int[] { 4, 5, 6, 7 },
                                                                registerSelectPin: 0,
                                                                readWritePin: 1,
                                                                enablePin: 2,
                                                                backlightPin: 3,
                                                                controller: new GpioController(PinNumberingScheme.Logical, serialDriver));

        static string lcdChars = string.Empty;

        static void Main()
        {
            IEnumerable<int> outputs = new int[] { 6, 13, 19, 26 };
            IEnumerable<int> inputs = new int[] { 12, 16, 20, 21 };
            KeyMatrix keyMatrix = new KeyMatrix(outputs, inputs, TimeSpan.FromMilliseconds(20));                      

            Console.WriteLine("Press a Button...");            

            DefaultLCD();

            while (true)
            {                
                KeyMatrixEvent key = keyMatrix.ReadKey();                

                if (key.EventType == PinEventTypes.Falling)
                {
                    continue;
                }
                else if (key.Input == 0 && key.Output == 0 && key.EventType == PinEventTypes.Rising)
                {
                    lcdChars += "1";
                    Console.WriteLine("1");
                }                    
                else if (key.Input == 1 && key.Output == 0 && key.EventType == PinEventTypes.Rising)
                {
                    lcdChars += "2";
                    Console.WriteLine("2");
                }
                else if (key.Input == 2 && key.Output == 0 && key.EventType == PinEventTypes.Rising)
                {
                    lcdChars += "3";
                    Console.WriteLine("3");
                }
                else if (key.Input == 3 && key.Output == 0 && key.EventType == PinEventTypes.Rising)
                {
                    lcdChars += "A";
                    Console.WriteLine("A");
                }
                else if (key.Input == 0 && key.Output == 1 && key.EventType == PinEventTypes.Rising)
                {
                    lcdChars += "4";
                    Console.WriteLine("4");
                }
                else if (key.Input == 1 && key.Output == 1 && key.EventType == PinEventTypes.Rising)
                {
                    lcdChars += "5";
                    Console.WriteLine("5");
                }
                else if (key.Input == 2 && key.Output == 1 && key.EventType == PinEventTypes.Rising)
                {
                    lcdChars += "6";
                    Console.WriteLine("6");
                }
                else if (key.Input == 3 && key.Output == 1 && key.EventType == PinEventTypes.Rising)
                {
                    lcdChars += "B";
                    Console.WriteLine("B");
                }
                else if (key.Input == 0 && key.Output == 2 && key.EventType == PinEventTypes.Rising)
                {
                    lcdChars += "7";
                    Console.WriteLine("7");
                }
                else if (key.Input == 1 && key.Output == 2 && key.EventType == PinEventTypes.Rising)
                {
                    lcdChars += "8";
                    Console.WriteLine("8");
                }
                else if (key.Input == 2 && key.Output == 2 && key.EventType == PinEventTypes.Rising)
                {
                    lcdChars += "9";
                    Console.WriteLine("9");
                }
                else if (key.Input == 3 && key.Output == 2 && key.EventType == PinEventTypes.Rising)
                {
                    lcdChars += "C";
                    Console.WriteLine("C");
                }
                else if (key.Input == 0 && key.Output == 3 && key.EventType == PinEventTypes.Rising)
                {
                    lcdChars += "*";
                    Console.WriteLine("*");
                }
                else if (key.Input == 1 && key.Output == 3 && key.EventType == PinEventTypes.Rising)
                {
                    lcdChars += "0";
                    Console.WriteLine("0");
                }
                else if (key.Input == 2 && key.Output == 3 && key.EventType == PinEventTypes.Rising)
                {
                    lcdChars += "#";
                    Console.WriteLine("#");
                }
                else if (key.Input == 3 && key.Output == 3 && key.EventType == PinEventTypes.Rising)
                {
                    lcdChars += "D";
                    Console.WriteLine("D");
                }

                Thread.Sleep(1);

                WriteLCD();

                if (lcdChars.Length > 16)
                {
                    TooLongLCD();
                    lcdChars = string.Empty;
                    DefaultLCD();                    
                }                
            }
        }

        static void DefaultLCD()
        {
            lcd.Clear();
            lcd.SetCursorPosition(0, 0);
            lcd.Write("Please Enter");
            lcd.SetCursorPosition(0, 1);
            lcd.Write("A Password");
        }

        static void WriteLCD()
        {
            lcd.Clear();
            lcd.SetCursorPosition(0, 0);
            lcd.Write(lcdChars);
        }

        static void TooLongLCD()
        {
            lcd.SetCursorPosition(0, 0);
            for (int i = 1; i <= 3; i++)
            {
                lcd.Clear();
                lcd.Write($"Too Long!");
                Thread.Sleep(500);
                lcd.Clear();
                Thread.Sleep(500);
            }            
        }
    }
}
