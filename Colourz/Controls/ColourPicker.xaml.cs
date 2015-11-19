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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Forms;
using Colourz.Controls;

namespace Colourz.window
{
    /// <summary>
    /// Interaction logic for ColourPicker.xaml
    /// </summary>
    public partial class ColourPicker : Window
    {

        public MainWindow owner { get; set; }

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        static public System.Drawing.Color getPixelColor(int x, int y)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);
            System.Drawing.Color color = System.Drawing.Color.FromArgb(
                         (int)(pixel & 0x0000FF),
                         (int)(pixel & 0x00FF00) >> 8,
                         (int)(pixel & 0xFF0000) >> 16);
            return color;
        }

        private DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public ColourPicker()
        {
            InitializeComponent();
            startColourPicking();
        }

        private void recBackboard_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void recColour_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            } catch { }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            }
            catch { }
            
        }

        private void startColourPicking()
        {
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            dispatcherTimer.Start();
        }

        private System.Windows.Input.KeyEventArgs keyEvent;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            System.Drawing.Color colour = getPixelColor(
                System.Windows.Forms.Control.MousePosition.X,
                System.Windows.Forms.Control.MousePosition.Y);
            red = colour.R;
            green = colour.G;
            blue = colour.B;
            recColour.Fill = new SolidColorBrush(Color.FromRgb(colour.R, colour.G, colour.B));
            //owner.recCGColour.Fill = new SolidColorBrush(Color.FromRgb(red, green, blue));

            owner.redSlider.setValue(red);
            owner.txtCGRed.Text = red.ToString();

            owner.greenSlider.setValue(green);
            owner.txtCGGreen.Text = green.ToString();

            owner.blueSlider.setValue(blue);
            owner.txtCGBlue.Text = blue.ToString();
        }

        private byte red, green, blue;

        private void lblBlock_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            this.keyEvent = e;
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F7)
            {
                dispatcherTimer.Start();
                this.Close();
            }
            if (e.Key == Key.F5)
            {
                Color rgb = Color.FromRgb(Convert.ToByte(red),
                    Convert.ToByte(green),
                    Convert.ToByte(blue));

                String hex =  rgb.R.ToString("X2") 
                    + rgb.G.ToString("X2") 
                    + rgb.B.ToString("X2");

                owner.stkSavedColours.Children.Add(new SavedColour(owner,
                    owner.stkSavedColours,
                    "" + red.ToString() + ", " + green.ToString() +
                    ", " + blue.ToString() + "", "#" + hex + ""));
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow.pickerShown = false;
            dispatcherTimer.Stop();
        }

        private void lblBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            dispatcherTimer.Start();
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }


    }
}
