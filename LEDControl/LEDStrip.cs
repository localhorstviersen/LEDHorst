using System;
using System.Collections.Generic;
using System.Drawing;

namespace LEDControl
{
    public class LEDStrip
    {
        private ushort ledCount;
        public ushort LEDCount
        {
            get { return ledCount; }
        }
        protected byte[][] pixel;
        public void show()
        {
            Console.WriteLine();
        }
        public void setPixel(ushort pixel, byte r, byte g, byte b)
        {
            this.pixel[pixel][0] = r;
            this.pixel[pixel][1] = g;
            this.pixel[pixel][2] = b;
            Console.Write(pixel.ToString("X4") + r.ToString("X2") + g.ToString("X2") + b.ToString("X2"));
        }
        public LEDStrip(ushort ledCount)
        {
            pixel = new byte[ledCount][];
            for (ushort i = 0; i < ledCount; i++)
                pixel[i] = new byte[3];
        }
    }

}