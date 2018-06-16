using System;
using System.Collections.Generic;
using System.Text;

namespace LEDControl
{
    public class LEDColor
    {
        protected byte r;
        public byte R
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
            }
        }
        protected byte g;
        public byte G
        {
            get
            {
                return g;
            }
            set
            {
                g = value;
            }
        }
        protected byte b;
        public byte B
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
            }
        }
        public LEDColor(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
        public override string ToString()
        {
            return r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
        }
    }
}
