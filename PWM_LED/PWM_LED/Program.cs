using System.Device.Pwm;
using System.Threading;


namespace PWM_LED

{
    class Program
    {
        static void Main(string[] args)
        {

            var pwm = PwmChannel.Create(0,0,400,.1);
            pwm.Start();

            while(true)
            {
                for (double i = 0; i <= 1; i += .1)
                {
                    pwm.DutyCycle = i;
                    Thread.Sleep(50);
                }

                for (double i = 1; i > 0; i -= .1)
                {
                    pwm.DutyCycle = i;
                    Thread.Sleep(50);
                }
            }

           

        }
    }
}
