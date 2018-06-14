#!/usr/bin/env python3

from neopixel import *
import sys
import time

# LED strip configuration:
LED_COUNT      = 256     # Number of LED pixels.
LED_PIN        = 18      # GPIO pin connected to the pixels (18 uses PWM!).
LED_FREQ_HZ    = 800000  # LED signal frequency in hertz (usually 800khz)
LED_DMA        = 10      # DMA channel to use for generating signal (try 10)
LED_BRIGHTNESS = 16      # Set to 0 for darkest and 255 for brightest
LED_INVERT     = False   # True to invert the signal (when using NPN transistor level shift)
LED_CHANNEL    = 0       # set to '1' for GPIOs 13, 19, 41, 45 or 53

if __name__ == '__main__':
    strip = Adafruit_NeoPixel(LED_COUNT, LED_PIN, LED_FREQ_HZ, LED_DMA, LED_INVERT, LED_BRIGHTNESS, LED_CHANNEL)
    strip.begin()
    while True:
        for line in iter(sys.stdin.readline, b''):
            try:
                data = bytearray.fromhex(line.strip())
            except:
                for i in range(strip.numPixels()):
                    strip.setPixelColor(i, Color(0, 0, 0))
                strip.show();
                sys.exit();
            for i in range(len(data) / 5):
                strip.setPixelColor(data[0 + i * 5] * 256 + data[1 + i * 5], Color(data[3 + i * 5], data[2 + i * 5], data[4 + i * 5]))
            strip.show()
            buff = ''
