namespace LEDControl
{
    public struct RGBColor
    {
        public byte R;
        public byte G;
        public byte B;
        public override string ToString()
        {
            return R.ToString("X2") + G.ToString("X2") + B.ToString("X2");
        }
    }
}
