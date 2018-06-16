using System.Collections.Generic;
using System.Threading;

namespace LEDControl
{
    public class LEDText
    {
        public Dictionary<char, byte[]> chars;
        LEDMatrix target;
        byte width;
        byte x;
        byte y;
        LEDColorMap colors;
        LEDColorMap backcolors;
        public LEDText(LEDMatrix matrix, byte x, byte y, byte width, LEDColorMap foregroundcolors, LEDColorMap backgroundcolors)
        {
            target = matrix;
            this.x = x;
            this.y = y;
            this.width = width;
            colors = foregroundcolors;
            backcolors = backgroundcolors;

            chars = new Dictionary<char, byte[]>();

            chars.Add(' ', new byte[] { 0, 0, 0 });
            chars.Add('!', new byte[] { 253 });
            chars.Add('"', new byte[] { 192, 0, 192 });
            chars.Add('#', new byte[] { 36, 255, 36, 255, 36 });
            chars.Add('$', new byte[] { 102, 145, 255, 137, 102 });
            chars.Add('%', new byte[] { 193, 198, 24, 99, 131 });
            chars.Add('&', new byte[] { 118, 137, 149, 98, 5 });
            chars.Add('\'', new byte[] { 192 });
            chars.Add('(', new byte[] { 60, 66, 129 });
            chars.Add(')', new byte[] { 129, 66, 60, });
            chars.Add('*', new byte[] { 18, 12, 63, 12, 18 });
            chars.Add('+', new byte[] { 4, 4, 31, 4, 4 });
            chars.Add(',', new byte[] { 5, 6 });
            chars.Add('-', new byte[] { 8, 8, 8 });
            chars.Add('.', new byte[] { 3, 3 });
            chars.Add('/', new byte[] { 1, 6, 24, 96, 128 });
            chars.Add('0', new byte[] { 126, 133, 153, 161, 126 });
            chars.Add('1', new byte[] { 65, 255, 1 });
            chars.Add('2', new byte[] { 67, 133, 137, 145, 97 });
            chars.Add('3', new byte[] { 130, 129, 145, 169, 198 });
            chars.Add('4', new byte[] { 24, 40, 72, 255, 8 });
            chars.Add('5', new byte[] { 242, 145, 145, 145, 142 });
            chars.Add('6', new byte[] { 62, 81, 145, 145, 142 });
            chars.Add('7', new byte[] { 128, 135, 152, 160, 192 });
            chars.Add('8', new byte[] { 110, 145, 145, 145, 110 });
            chars.Add('9', new byte[] { 112, 137, 137, 138, 116 });
            chars.Add(':', new byte[] { 102, 102 });
            chars.Add(';', new byte[] { 101, 102 });
            chars.Add('<', new byte[] { 8, 20, 34, 65 });
            chars.Add('=', new byte[] { 20, 20, 20, 20 });
            chars.Add('>', new byte[] { 65, 34, 20, 8 });
            chars.Add('?', new byte[] { 64, 128, 141, 144, 96 });
            chars.Add('@', new byte[] { 78, 149, 159, 129, 126 });
            chars.Add('A', new byte[] { 63, 72, 136, 72, 63 });
            chars.Add('B', new byte[] { 255, 145, 145, 145, 110 });
            chars.Add('C', new byte[] { 126, 129, 129, 129, 66 });
            chars.Add('D', new byte[] { 255, 129, 129, 129, 126 });
            chars.Add('E', new byte[] { 255, 145, 145, 145, 129 });
            chars.Add('F', new byte[] { 255, 144, 144, 144, 128 });
            chars.Add('G', new byte[] { 126, 129, 129, 137, 78 });
            chars.Add('H', new byte[] { 255, 8, 8, 8, 255 });
            chars.Add('I', new byte[] { 255 });
            chars.Add('J', new byte[] { 6, 1, 1, 1, 254 });
            chars.Add('K', new byte[] { 255, 24, 36, 66, 129 });
            chars.Add('L', new byte[] { 255, 1, 1, 1, 1 });
            chars.Add('M', new byte[] { 255, 64, 32, 64, 255 });
            chars.Add('N', new byte[] { 255, 64, 32, 16, 255 });
            chars.Add('O', new byte[] { 126, 129, 129, 129, 126 });
            chars.Add('P', new byte[] { 255, 144, 144, 144, 96 });
            chars.Add('Q', new byte[] { 126, 129, 133, 131, 127 });
            chars.Add('R', new byte[] { 127, 152, 148, 146, 97 });
            chars.Add('S', new byte[] { 102, 145, 137, 137, 102 });
            chars.Add('T', new byte[] { 128, 128, 255, 128, 128 });
            chars.Add('U', new byte[] { 254, 1, 1, 1, 254 });
            chars.Add('V', new byte[] { 252, 2, 1, 2, 252 });
            chars.Add('W', new byte[] { 255, 2, 4, 2, 255 });
            chars.Add('X', new byte[] { 129, 102, 24, 102, 129 });
            chars.Add('Y', new byte[] { 128, 64, 63, 64, 128 });
            chars.Add('Z', new byte[] { 131, 133, 153, 161, 193 });
            chars.Add('[', new byte[] { 255, 129, 129 });
            chars.Add('\\', new byte[] { 128, 96, 24, 6, 1 });
            chars.Add(']', new byte[] { 129, 129, 255 });
            chars.Add('^', new byte[] { 32, 64, 128, 64, 32 });
            chars.Add('_', new byte[] { 1, 1, 1, 1, 1 });
            chars.Add('`', new byte[] { 128, 64, 32 });
            chars.Add('a', new byte[] { 2, 21, 21, 21, 15 });
            chars.Add('b', new byte[] { 127, 9, 17, 17, 14 });
            chars.Add('c', new byte[] { 14, 17, 17, 17, 2 });
            chars.Add('d', new byte[] { 14, 17, 17, 9, 127 });
            chars.Add('e', new byte[] { 14, 21, 21, 21, 12 });
            chars.Add('f', new byte[] { 8, 63, 72, 32 });
            chars.Add('g', new byte[] { 8, 21, 21, 21, 30 });
            chars.Add('h', new byte[] { 127, 8, 16, 16, 15 });
            chars.Add('i', new byte[] { 17, 95, 1 });
            chars.Add('j', new byte[] { 2, 1, 17, 94 });
            chars.Add('k', new byte[] { 127, 4, 10, 17 });
            chars.Add('l', new byte[] { 65, 127, 1 });
            chars.Add('m', new byte[] { 31, 16, 15, 16, 15 });
            chars.Add('n', new byte[] { 31, 8, 16, 16, 15 });
            chars.Add('o', new byte[] { 14, 17, 17, 17, 14 });
            chars.Add('p', new byte[] { 31, 20, 20, 20, 8 });
            chars.Add('q', new byte[] { 8, 20, 20, 20, 31 });
            chars.Add('r', new byte[] { 31, 8, 16, 16, 8 });
            chars.Add('s', new byte[] { 9, 21, 21, 21, 2 });
            chars.Add('t', new byte[] { 16, 126, 17, 2 });
            chars.Add('u', new byte[] { 30, 1, 1, 2, 31 });
            chars.Add('v', new byte[] { 28, 2, 1, 2, 28 });
            chars.Add('w', new byte[] { 30, 1, 6, 1, 30 });
            chars.Add('x', new byte[] { 17, 10, 4, 10, 17 });
            chars.Add('y', new byte[] { 24, 5, 5, 5, 30 });
            chars.Add('z', new byte[] { 17, 19, 21, 25, 17 });
            chars.Add('{', new byte[] { 24, 255, 129 });
            chars.Add('|', new byte[] { 255 });
            chars.Add('}', new byte[] { 129, 255, 24 });
            chars.Add('~', new byte[] { 8, 16, 8, 8, 16 });

            chars.Add('Ä', new byte[] { 191, 72, 136, 72, 191 });
            chars.Add('Ö', new byte[] { 190, 65, 65, 65, 190 });
            chars.Add('Ü', new byte[] { 190, 1, 1, 1, 190 });
            chars.Add('ä', new byte[] { 2, 85, 21, 85, 15 });
            chars.Add('ö', new byte[] { 14, 81, 17, 81, 14 });
            chars.Add('ü', new byte[] { 30, 65, 1, 66, 31 });

        }
        List<byte> fulltext;
        int offset;
        protected void worker()
        {
            while (run)
            {
                writeNext();
                Thread.Sleep(sleepelay);
            }
        }
        public void automate(int speed, byte r, byte g, byte b)
        {
            sleepelay = speed;
            this.r = r;
            this.g = g;
            this.b = b;
            run = true;
            background = new Thread(new ThreadStart(worker));
            background.Start();
        }
        protected Thread background;
        public void stop()
        {
            run = false;
        }
        protected bool run;
        protected int sleepelay;
        protected byte r;
        protected byte g;
        protected byte b;
        public void setText(string text)
        {
            fulltext = new List<byte>();
            foreach (char c in text)
            {
                fulltext.Add(0);
                fulltext.AddRange(chars[c]);
            }
            fulltext.Add(0);
            fulltext.Add(0);
            fulltext.Add(0);
            fulltext.Add(0);
            fulltext.Add(0);
            offset = 0;
        }

        public void writeNext()
        {
            for (byte col = 0; col < width; col++)
            {
                if ((fulltext[(offset + col) % fulltext.Count] & 0b10000000) != 0)
                    target.setPixel((byte)(x + col), y, colors.getColor(offset + col, 0));
                else
                    target.setPixel((byte)(x + col), y, backcolors.getColor(offset + col, 0));

                if ((fulltext[(offset + col) % fulltext.Count] & 0b01000000) != 0)
                    target.setPixel((byte)(x + col), (byte)(y + 1), colors.getColor(offset + col, 1));
                else
                    target.setPixel((byte)(x + col), (byte)(y + 1), backcolors.getColor(offset + col, 1));

                if ((fulltext[(offset + col) % fulltext.Count] & 0b00100000) != 0)
                    target.setPixel((byte)(x + col), (byte)(y + 2), colors.getColor(offset + col, 2));
                else
                    target.setPixel((byte)(x + col), (byte)(y + 2), backcolors.getColor(offset + col, 2));

                if ((fulltext[(offset + col) % fulltext.Count] & 0b00010000) != 0)
                    target.setPixel((byte)(x + col), (byte)(y + 3), colors.getColor(offset + col, 3));
                else
                    target.setPixel((byte)(x + col), (byte)(y + 3), backcolors.getColor(offset + col, 3));

                if ((fulltext[(offset + col) % fulltext.Count] & 0b00001000) != 0)
                    target.setPixel((byte)(x + col), (byte)(y + 4), colors.getColor(offset + col, 4));
                else
                    target.setPixel((byte)(x + col), (byte)(y + 4), backcolors.getColor(offset + col, 4));

                if ((fulltext[(offset + col) % fulltext.Count] & 0b00000100) != 0)
                    target.setPixel((byte)(x + col), (byte)(y + 5), colors.getColor(offset + col, 5));
                else
                    target.setPixel((byte)(x + col), (byte)(y + 5), backcolors.getColor(offset + col, 5));

                if ((fulltext[(offset + col) % fulltext.Count] & 0b00000010) != 0)
                    target.setPixel((byte)(x + col), (byte)(y + 6), colors.getColor(offset + col, 6));
                else
                    target.setPixel((byte)(x + col), (byte)(y + 6), backcolors.getColor(offset + col, 6));

                if ((fulltext[(offset + col) % fulltext.Count] & 0b00000001) != 0)
                    target.setPixel((byte)(x + col), (byte)(y + 7), colors.getColor(offset + col, 7));
                else
                    target.setPixel((byte)(x + col), (byte)(y + 7), backcolors.getColor(offset + col, 7));
            }
            target.show();
            offset++;
        }
    }
}