using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Colourz
{
    /// <summary>
    /// This class contains all of the themes
    /// </summary>
    public partial class Theme : MainWindow
    {
        public static Boolean blackTheme = true;

        public static Brush HOVER_WHITE_WRITING = new SolidColorBrush(Color.FromRgb(238, 239, 242));
        public static Brush NORMAL_WHITE_WRITING = new SolidColorBrush(Color.FromRgb(166, 167, 170));

        public static Brush NORMAL_BLACK_WRITING = new SolidColorBrush(Color.FromRgb(130, 132, 136));
        public static Brush HOVER_BLACK_WRITING = new SolidColorBrush(Color.FromRgb(10, 11, 13));

        public static Brush RECTANGLE_BLACK_LIGHT = new SolidColorBrush(Color.FromRgb(30, 32, 36));
        public static Brush RECTANGLE_BLACK_DARK = new SolidColorBrush(Color.FromRgb(10, 11, 13));

        public static Brush RECTANGLE_WHITE_LIGHT = new SolidColorBrush(Color.FromRgb(230, 232, 236));
        public static Brush RECTANGLE_WHITE_DARK = new SolidColorBrush(Color.FromRgb(190, 191, 193));


        public static Brush SPLITTER_BLACK = new SolidColorBrush(Color.FromRgb(11, 11, 12));
        public static Brush SPLITTER_WHITE = new SolidColorBrush(Color.FromRgb(211, 211, 212));

        public static Brush SELECTOR_DARK = new SolidColorBrush(Color.FromRgb(40, 42, 46));
        public static Brush SELECTOR_LIGHT = new SolidColorBrush(Color.FromRgb(210, 211, 215));

        public static Brush SEPERATE_DARK = new SolidColorBrush(Color.FromRgb(15, 15, 15));
        public static Brush SEPERATE_LIGHT = new SolidColorBrush(Color.FromRgb(215, 215, 215));

        public static Brush SCROLLABLES_DARK = new SolidColorBrush(Color.FromRgb(5, 5, 6));
        public static Brush SCROLLABLES_LIGHT = new SolidColorBrush(Color.FromRgb(165, 166, 168));


        public static Brush SCROLLERS_HOVER_LIGHT = new SolidColorBrush(Color.FromArgb(255, 125, 126, 128));
        public static Brush SCROLLERS_NORMAL_LIGHT = new SolidColorBrush(Color.FromArgb(255, 165, 166, 168));

        public static Brush SCROLLERS_HOVER_DARK = new SolidColorBrush(Color.FromArgb(255, 15, 16, 19));
        public static Brush SCROLLERS_NORMAL_DARK = new SolidColorBrush(Color.FromArgb(255, 5, 5, 6));

        public static SolidColorBrush getColourForTheme(TextBlock block, Boolean hover)
        {
            if(blackTheme)
            {
                if(hover) { return (SolidColorBrush) HOVER_WHITE_WRITING; }
                else { return (SolidColorBrush) NORMAL_WHITE_WRITING; }
            }
            else
            {
                if (hover) { return (SolidColorBrush)HOVER_BLACK_WRITING; }
                else { return (SolidColorBrush)NORMAL_BLACK_WRITING; }
            }
        }

        public static SolidColorBrush getScrollers(bool hover)
        {
            if(blackTheme)
            {
                if (hover) return (SolidColorBrush)SCROLLERS_HOVER_DARK;
                else return (SolidColorBrush)SCROLLERS_NORMAL_DARK;
            }
            else
            {
                if (hover) return (SolidColorBrush)SCROLLERS_HOVER_LIGHT;
                else return (SolidColorBrush)SCROLLERS_NORMAL_LIGHT;
            }
        }
    }
}
