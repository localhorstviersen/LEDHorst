using LEDControl;
using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            LEDController ctrl = new LEDController();
            LEDController.LEDStrip strip1 = new LEDController.LEDStrip(120, 13, 10, 255, 0, ctrl);
            LEDController.LEDStrip strip2 = new LEDController.LEDStrip(16*16, 18, 11, 255, 1, ctrl);
            strip1.Send();
            for (byte i = 0; i < 120; i++)
            {
                strip1.Colors[i].R = 22;
                strip1.Colors[i].G = i;
                strip1.Colors[i].B = (byte)(i+120);
            }
            strip1.Send();
            Console.ReadLine();
        }
    }
}
