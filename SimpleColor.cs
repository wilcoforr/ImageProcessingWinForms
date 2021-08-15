using System.Drawing;

namespace ImageProcessing
{
    /// <summary>
    /// SimpleColor color = new SimpleColor(row[rIndex], row[gIndex], row[bIndex]);
    /// </summary>
    public struct SimpleColor
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public SimpleColor(byte initialRGB)
        {
            Red = initialRGB;
            Green = initialRGB;
            Blue = initialRGB;
        }

        public SimpleColor(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public Color ConvertToSystemDrawingColor()
        {
            return Color.FromArgb(Red, Green, Blue);
        }
    }
}
