using System.Drawing;

namespace CoolerMasterSharpSDK.Datatypes
{
    public class KeyColor
    {
        /// <summary>
        /// Red value of this <see cref="KeyColor"/>
        /// </summary>
        public byte R { get; set; }

        /// <summary>
        /// Green value of this <see cref="KeyColor"/>
        /// </summary>
        public byte G { get; set; }
        /// <summary>
        /// Blue value of this <see cref="KeyColor"/>
        /// </summary>
        public byte B { get; set; }

        /// <summary>
        /// <see cref="System.Drawing.Color"/> representation of this <see cref="KeyColor"/>
        /// </summary>
        public Color Color {
            get
            {
                return Color.FromArgb(R, G, B);
            }
        }

        public KeyColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public KeyColor(Color color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
        }
    }
}
