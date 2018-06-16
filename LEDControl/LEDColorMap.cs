using System;
using System.Collections.Generic;
using System.Text;

namespace LEDControl
{
    public class LEDColorMap
    {
        LEDColor[,] map;
        public LEDColorMap(LEDColor[,] colors, int stretch)
        {
            map = new LEDColor[colors.GetLength(0) * stretch, colors.GetLength(1) * stretch];
            // horizontal fill where colors are present
            for (int yy = 0; yy < colors.GetLength(1); yy++)
            {
                for (int xx = 0; xx < colors.GetLength(0); xx++)
                {
                    for (int x = 0; x < stretch; x++)
                    {
                        if (x == 0)
                            map[xx * stretch, yy * stretch] = new LEDColor(colors[xx, yy].R, colors[xx, yy].G, colors[xx, yy].B);
                        else
                        {
                            double firstcolor = 1 - ((double)x / stretch);
                            double secondcolor = 1 - firstcolor;
                            map[xx * stretch + x, yy * stretch] = mixer(colors[xx, yy], colors[(xx + 1) % colors.GetLength(0), yy], firstcolor, secondcolor);
                        }
                    }
                }
            }
            // now vertically fill 
            for (int x = 0; x < colors.GetLength(0) * stretch; x++)
            {
                for (int yy = 0; yy < colors.GetLength(1); yy++)
                {
                    for (int y = 1; y < stretch; y++)
                    {
                        double firstcolor = 1 - ((double)y / stretch);
                        double secondcolor = 1 - firstcolor;
                        map[x, yy * stretch + y] = mixer(map[x, yy * stretch], map[x, ((yy+1) * stretch) % map.GetLength(1)], firstcolor, secondcolor);
                    }
                }
            }
        }
        protected LEDColor mixer(LEDColor firstColor, LEDColor secondColor, double firstWeight, double secondWeight)
        {
            return new LEDColor(Convert.ToByte(firstWeight * firstColor.R + secondWeight * secondColor.R),
                                Convert.ToByte(firstWeight * firstColor.G + secondWeight * secondColor.G),
                                Convert.ToByte(firstWeight * firstColor.B + secondWeight * secondColor.B));
        }
        public LEDColor getColor(int x, int y)
        {
            return map[x % map.GetLength(0), y % map.GetLength(1)];
        }
    }
}