using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Colourz
{
    /// <summary>
    /// Handles the tabs
    /// @author Zack Davidson
    /// </summary>
    public class Tab
    {

        #region Variables
        /// <summary>
        /// Checks what tab has been selected
        /// </summary>
        public int selected { get; set; }

        /// <summary>
        /// The rectangle being sent
        /// </summary>
        public Rectangle sender;
        #endregion

        /// <summary>
        /// Starts an animation for the rectangles
        /// </summary>
        /// <param name="rec">The rectangle being moved</param>
        public void moveComponents(Rectangle rec)
        {
            MainWindow.doingAnimation = true;
            Animation animation = new Animation(rec, rec.Margin.Top, getNextMoveValue());
            animation.startAnimation();
        }

        /// <summary>
        /// Resets all parameter textblock 
        /// colours to their original gray colour
        /// </summary>
        /// <param name="text"></param>
        public void resetColours(params TextBlock[] text)
        {
            foreach(TextBlock comp in text)
            {
                comp.Foreground = Theme.getColourForTheme(comp, false);
            }
        }

        /// <summary>
        /// Gets the selectors next y value to take
        /// </summary>
        /// <returns>The new Y value to take</returns>
        public int getNextMoveValue()
        {
            return (int) sender.Margin.Top;
        }

    }

}
