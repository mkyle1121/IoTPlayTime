using Iot.Device.Pcx857x;
using System.Device.Gpio;
using System.Device.I2c;
using Iot.Device.CharacterLcd;

namespace LCDScreen3
{
    class Program
    {
        static void Main()
        {
            using I2cDevice i2cDevice = I2cDevice.Create(new I2cConnectionSettings(1, 0x27));
            using Pcf8574 serialDriver = new Pcf8574(i2cDevice);

            using var lcd = new Lcd1602
            (
                dataPins: new int[] { 4, 5, 6, 7 },
                registerSelectPin: 0,
                readWritePin: 1,
                enablePin: 2,
                backlightPin: 3,
                controller: new GpioController(PinNumberingScheme.Logical, serialDriver)
            );

            lcd.Clear();
            lcd.SetCursorPosition(2, 0);
            lcd.Write("That Wassup!");
            lcd.SetCursorPosition(3, 1);
            lcd.Write("Derp!");            
        }
    }
}
