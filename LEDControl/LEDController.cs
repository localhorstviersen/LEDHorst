using System;
using System.Collections.Generic;
using System.Drawing;

namespace LEDControl
{
    public class LEDController
    {
        private List<LEDStrip> strips;
        public LEDStrip[] Strips
        {
            get
            { return strips.ToArray(); }
        }
        private void sendStrip(byte stripID)
        {
            Console.Write("STR" + stripID);
            for (ushort i = 0; i < strips[stripID].LEDCount; i++)
            {
                Console.Write("#" + strips[stripID].Colors[i].ToString());
            }
            Console.WriteLine();
        }
        private void sendBrightness(byte stripID, byte brightness)
        {
            Console.WriteLine("BRI" + stripID + "#" + strips[stripID].Brightness);
        }
        private byte registerStrip(LEDStrip strip)
        {
            strips.Add(strip);
            Console.WriteLine("REG{0}#{1}#{2}#{3}#{4}#{5}", nextid, strip.LEDCount, strip.LEDPin, strip.DMAChannel, strip.Brightness, strip.Channel);
            return nextid++;
        }
        private byte nextid;
        public LEDController()
        {
            nextid = 0;
            strips = new List<LEDStrip>();
        }
        public class LEDStrip
        {
            private ushort ledCount;
            public ushort LEDCount
            {
                get { return ledCount; }
            }
            private byte ledPin;
            public byte LEDPin
            {
                get { return ledPin; }
            }
            private byte dmaChannel;
            public byte DMAChannel
            {
                get { return dmaChannel; }
            }
            private byte brightness;
            public byte Brightness
            {
                get { return brightness; }
                set
                {
                    brightness = value;
                    controller.sendBrightness(controllerID, brightness);
                }
            }
            private byte channel;
            public byte Channel
            {
                get { return channel; }
            }
            public void Send()
            {
                controller.sendStrip(controllerID);
            }
            private LEDController  controller;
            private byte controllerID;
            public RGBColor[] Colors;
            public LEDStrip(ushort ledCount, byte ledPin, byte dmaChannel, byte brightness, byte channel, LEDController controller)
            {
                Colors = new RGBColor[ledCount];
                this.ledCount = ledCount;
                this.ledPin = ledPin;
                this.dmaChannel = dmaChannel;
                this.brightness = Brightness;
                this.channel = channel;
                this.controller = controller;
                controllerID = controller.registerStrip(this);
            }
        }
    }
}