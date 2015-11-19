using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Colourz
{
    /// <summary>
    /// This class will handle animations for the passed rectangles in it's constructors
    /// @author Zack Davidson
    /// </summary>
    public class Animation
    {

        /// <summary>
        /// Checks if the animations are disabled or not
        /// </summary>
        public static bool disableAnimation = false;

        /// <summary>
        /// Checks if the animations are currently active
        /// </summary>
        public static bool doingAnimation = false;

        #region private variables
        /// <summary>
        /// The old position aka saved
        /// </summary>
        private double old;

        /// <summary>
        /// The target position to move to
        /// </summary>
        private double target;

        /// <summary>
        /// The current position of the rectangle
        /// </summary>
        private double current;

        /// <summary>
        /// The rectangle object
        /// </summary>
        private Rectangle rectangle;

        /// <summary>
        /// A new time dispatcher
        /// </summary>
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();

        #endregion

        #region Construtor
        public Animation(Rectangle rectangle, double old, double target)
        {
            this.rectangle = rectangle;
            this.old = old;
            this.current = old;
            this.target = target;
        }
        #endregion

        #region Animation Starter
        /// <summary>
        /// Starts the animation
        /// and generates the dispatcher timer attributes
        /// </summary>
        public void startAnimation()
        {
            if (disableAnimation)
            {
                double x = rectangle.Margin.Left;
                double bottom = rectangle.Margin.Bottom;
                double right = rectangle.Margin.Right;
                rectangle.Margin = new Thickness(x, target, bottom, right);
                doingAnimation = false;
            } 
            else
            {
                dispatcherTimer.Tick += dispatcherTimer_Tick;
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
                dispatcherTimer.Start();
            }

        }
        #endregion

        #region Animation Handler
        /// <summary>
        /// This handles the movement of the rectangle
        /// </summary>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if(target == old)
            {
                doingAnimation = false;
                dispatcherTimer.Stop();
                return;
            }

            int speed = 0;
            double x = rectangle.Margin.Left;
            double bottom = rectangle.Margin.Bottom;
            double right = rectangle.Margin.Right;
            if(old > target)
            {
                if(current <= target)
                {

                    rectangle.Margin = new Thickness(x, target, bottom, right);
                    doingAnimation = false;
                    dispatcherTimer.Stop();
                    return;
                }
                speed = (int)(old - target) / 7;
                if((current - speed) < target)
                {
                    speed = 1;
                }
                current -= speed;
            }
            else if(old < target)
            {
                if (current >= target)
                {
                    rectangle.Margin = new Thickness(x, target, bottom, right);
                    doingAnimation = false;
                    dispatcherTimer.Stop();
                    return;
                }
                speed = (int)(target - old) / 7;
                if ((speed + current) > target)
                {
                    speed = 1;
                }
                current += speed;
                
            }
            rectangle.Margin = new Thickness(x, current, bottom, right);
        }
    #endregion

    }
}
