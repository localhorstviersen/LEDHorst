using LEDControl;
using System;
using System.Threading;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            LEDs strip = new LEDs(256);
            /*for (int r = 0; r < 256; r += 16)
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
            }*/

            LEDMatrix m = new LEDMatrix(strip, 0, 16, 16, LEDMatrix.Corner.TopRight, LEDMatrix.Orientation.Rows);

            m.setPixel(0, 0, 255, 0, 0);
            m.show();
            //Thread.Sleep(2000);
            
            m.setPixel(15,0, 0, 0, 255);
            m.show();
            //Thread.Sleep(2000);
            
            m.setPixel(15, 15, 255, 255, 255);
            m.show();
            //Thread.Sleep(2000);

            m.setPixel(0, 15, 0, 255, 0);
            m.show();
            //Thread.Sleep(2000);

            m.drawRectangle(0, 0, 16, 16, 255, 0, 0);
            m.show();
            //Thread.Sleep(2000);

            m.drawRectangle(1, 1, 14, 14, 0, 255, 0);
            m.show();
            //Thread.Sleep(2000);

            m.drawRectangle(2, 2, 12, 12, 0, 0, 255);
            m.show();
            //Thread.Sleep(2000);

            m.drawRectangle(3, 3, 10, 10, 255, 0, 0);
            m.show();
            //Thread.Sleep(2000);

            m.drawRectangle(4, 4, 8, 8, 0, 255, 0);
            m.show();
            //Thread.Sleep(2000);

            m.drawRectangle(5, 5, 6, 6, 0, 0, 255);
            m.show();
            //Thread.Sleep(2000);

            m.fillRectangle(0, 0, 8, 16, 255, 0, 0);
            m.show();
            //Thread.Sleep(2000);

            m.fillRectangle(8, 0, 8, 16, 0, 255, 0);
            m.show();
            Thread.Sleep(2000);

            m.fillRectangle(0, 0,16, 16, 0, 0, 0);
            m.show();

            LEDText txt = new LEDText(m, 0, 0, 16);
            txt.setText("BIF21");

            LEDText txt2 = new LEDText(m, 0, 8, 16);
            txt2.setText("WTF was ist den das hier! PENIS!!!");

            while (true)
            {
                txt.writeNext(255,0,0);
                txt2.writeNext(0, 0, 255);
                Thread.Sleep(50);
                txt2.writeNext(0, 255, 0);
                Thread.Sleep(50);
            }



            Console.WriteLine("END");
        }
    }
}
