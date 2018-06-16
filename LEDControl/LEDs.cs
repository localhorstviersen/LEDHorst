using System;

namespace LEDControl
{
    public class LEDs
    {
        private ushort ledCount;
        public ushort LEDCount
        {
            get { return ledCount; }
        }
        protected LEDColor[] pixel;
        public void show()
        {
            Console.WriteLine();
        }
        public void setPixel(ushort pixel, LEDColor color)
        {
            this.pixel[pixel] = color;
            Console.Write(pixel.ToString("X4") + color.ToString());
        }
        public void setPixel(ushort pixel)
        {
            this.pixel[pixel] = new LEDColor(0, 0, 0);
            Console.Write(pixel.ToString("X4") + "000000");
        }
        public LEDs(ushort ledCount)
        {
            pixel = new LEDColor[ledCount];
            this.ledCount = ledCount;
            for (ushort i = 0; i < ledCount; i++)
                pixel[i] = new LEDColor(0, 0, 0);
        }
    }
}