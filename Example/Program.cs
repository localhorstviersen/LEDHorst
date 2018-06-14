using LEDControl;
using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            LEDStrip strip = new LEDStrip(256);
            for (int r = 0; r < 256; r += 16)
            {
                for (uint g = 0; g < 256; g += 16)
                {
                    for (uint b = 0; b < 256; b += 16)
                    {
                        for (ushort i = 0; i < 256; i++)
                        {
                            strip.setPixel(i, (byte)r, (byte)g, (byte)b);
                        }
                        strip.show();
                    }
                }
            }
            Console.WriteLine("END");
        }
    }
}
