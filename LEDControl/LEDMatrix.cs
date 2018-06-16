namespace LEDControl
{
    public class LEDMatrix
    {
        public enum Corner { TopLeft, TopRight, BottomLeft, BottomRight };
        public enum Orientation { Colums, Rows };
        protected ushort offset;
        LEDs target;
        protected ushort[,] map;
        public LEDMatrix(LEDs leds, ushort startPixel, byte width, byte height, Corner firstPixelPosition, Orientation secondPixelPosition)
        {
            offset = startPixel;
            target = leds;
            map = new ushort[width, height];
            if (firstPixelPosition == Corner.TopRight)
            {
                byte x = (byte)(width - 1);
                byte y = 0;
                ushort led = offset;
                do
                {
                    map[x, y] = led++;
                    // 321
                    // 456
                    // 987
                    if (secondPixelPosition == Orientation.Rows)
                    {
                        if (y % 2 == 0)
                        {
                            if (x > 0)
                                x--;
                            else
                                y++;
                        }
                        else
                        {
                            if (x < (byte)(width - 1))
                                x++;
                            else
                                y++;
                        }
                    }
                    // 761
                    // 852
                    // 943
                    else // (secondPixelPosition == Orientation.Colums)
                    {
                        if (x % 2 == width % 2)
                        {
                            if (y > 0)
                                y--;
                            else
                                x--;
                        }
                        else
                        {
                            if (y < (byte)(height - 1))
                                y++;
                            else
                                x--;
                        }
                    }
                } while (led < offset + width * height);
            }
            else if (firstPixelPosition == Corner.TopLeft)
            {
                byte x = 0;
                byte y = 0;
                ushort led = offset;
                do
                {
                    map[x, y] = led++;
                    // 123
                    // 654
                    // 789
                    if (secondPixelPosition == Orientation.Rows)
                    {
                        if (y % 2 == 0)
                        {
                            if (x < (byte)(width - 1))
                                x++;
                            else
                                y++;
                        }
                        else
                        {
                            if (x > 0)
                                x--;
                            else
                                y++;
                        }
                    }
                    // 167
                    // 258
                    // 349
                    else // (secondPixelPosition == Orientation.Colums)
                    {
                        if (x % 2 == 0)
                        {
                            if (y < (byte)(height - 1))
                                y++;
                            else
                                x++;
                        }
                        else
                        {
                            if (y > 0)
                                y--;
                            else
                                x++;
                        }
                    }
                } while (led < offset + width * height);
            }
            else if (firstPixelPosition == Corner.BottomLeft)
            {
                byte x = 0;
                byte y = (byte)(height - 1);
                ushort led = offset;
                do
                {
                    map[x, y] = led++;
                    // 789
                    // 654
                    // 123
                    if (secondPixelPosition == Orientation.Rows)
                    {
                        if (y % 2 == height % 2)
                        {
                            if (x < (byte)(width - 1))
                                x++;
                            else
                                y--;
                        }
                        else
                        {
                            if (x > 0)
                                x--;
                            else
                                y--;
                        }
                    }
                    // 349
                    // 258
                    // 167
                    else // (secondPixelPosition == Orientation.Colums)
                    {
                        if (x % 2 == 0)
                        {
                            if (y > 0)
                                y--;
                            else
                                x++;
                        }
                        else
                        {
                            if (y < (byte)(height - 1))
                                y++;
                            else
                                x++;
                        }
                    }
                } while (led < offset + width * height);
            }
            else // (firstPixelPosition == Corner.BottomRight)
            {
                byte x = (byte)(width - 1);
                byte y = (byte)(height - 1);
                ushort led = offset;
                do
                {
                    map[x, y] = led++;
                    // 987
                    // 456
                    // 321
                    if (secondPixelPosition == Orientation.Rows)
                    {
                        if (y % 2 == height % 2)
                        {
                            if (x > 0)
                                x--;
                            else
                                y--;
                        }
                        else
                        {
                            if (x < (byte)(width - 1))
                                x++;
                            else
                                y--;
                        }
                    }
                    // 943
                    // 852
                    // 761
                    else // (secondPixelPosition == Orientation.Colums)
                    {
                        if (x % 2 == width % 2)
                        {
                            if (y > 0)
                                y--;
                            else
                                x--;
                        }
                        else
                        {
                            if (y < (byte)(height - 1))
                                y++;
                            else
                                x--;
                        }
                    }
                } while (led < offset + width * height);
            }
        }
        public void setPixel(byte x, byte y, LEDColor color)
        {
            target.setPixel((ushort)(offset + map[x, y]), color);
        }
        public void setPixel(byte x, byte y)
        {
            target.setPixel((ushort)(offset + map[x, y]));
        }
        public void drawRectangle(byte x, byte y, byte width, byte height, LEDColor color)
        {
            for (byte tx = x; tx < x + width; tx++)
            {
                setPixel(tx, y, color);
                setPixel(tx, (byte)(y + height - 1), color);
            }
            for (byte ty = y; ty < y + height; ty++)
            {
                setPixel(x, ty, color);
                setPixel((byte)(x + width - 1), ty, color);
            }
        }
        public void fillRectangle(byte x, byte y, byte width, byte height, LEDColor color)
        {
            for (byte tx = x; tx < x + width; tx++)
                for (byte ty = y; ty < y + height; ty++)
                    setPixel(tx, ty, color);
        }
        public void show()
        {
            target.show();
        }
    }
}
