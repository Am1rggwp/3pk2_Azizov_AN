using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PZ_10
{
    public class NotePadState
    {
        public string Text { get; set; }
        public double FontSize { get; set; }
        public FontStyle FontStyle { get; set; }
        public FontWeight FontWeight { get; internal set; }
        public TextDecorationCollection TextDecorations { get; internal set; }
        public double FontSize1 { get; }

        public NotePadState(string text, double fontSize, FontStyle fontStyle, FontWeight fontWeight)
        {
            Text = text;
            FontSize = fontSize;
            FontStyle = fontStyle;
            FontWeight = fontWeight;

        }

        
    }
}
