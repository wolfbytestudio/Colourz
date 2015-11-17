using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Colourz.Controls
{
    /// <summary>
    /// Interaction logic for SavedColour.xaml
    /// </summary>
    public partial class SavedColour : UserControl
    {



        public string hex;
        private string rgb;
        private StackPanel stack;
        private object owner;
        private bool selected;

        public SavedColour(object owner, StackPanel stack, string rgb, string hex)
        {
            this.owner = owner;
            this.hex = hex;
            this.rgb = rgb;
            this.stack = stack;
            selected = false;
            InitializeComponent();

            lblText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex));
            lblText.Text = "RGB("+rgb+") Hex("+hex+")";
        }



        private void lblText_MouseEnter(object sender, MouseEventArgs e)
        {
            if(Theme.blackTheme)
            {

                lblText.Background = new SolidColorBrush(Color.FromRgb(10, 11, 13));
            }
            else
            {
                lblText.Background = new SolidColorBrush(Color.FromRgb(190, 191, 193));
            }
            
        }

        private void lblText_MouseLeave(object sender, MouseEventArgs e)
        {
            if(selected)
            {
                return;
            }
            else
            {
                lblText.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            }
            
        }

        private void menAll_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(lblText.Text);
        }

        private void menRgb_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(rgb);
        }

        private void menHex_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(hex);
        }

        private void menRemove_Click(object sender, RoutedEventArgs e)
        {
            stack.Children.Remove(this);
        }

        bool rightClicked = false;
        bool alreadySelected = false;

        private void lblText_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (rightClicked)
                {
                    Console.WriteLine("Right mouse pressed");
                    selectedColours.Remove(this);
                    selected = false;
                }
                else
                {

                    if (!selected)
                    {
                        select();
                    }
                    else
                    {
                        unselect();
                    }
                }
            }
            catch
            {

            }
            
        }

        public static List<SavedColour> selectedColours = new List<SavedColour>();

        public void select()
        {
            selected = true;
            selectedColours.Add(this);
            if (Theme.blackTheme)
            {

                lblText.Background = new SolidColorBrush(Color.FromRgb(10, 11, 13));
            }
            else
            {
                lblText.Background = new SolidColorBrush(Color.FromRgb(190, 191, 193));
            }
        }

        public void unselect()
        {
            selected = false;
            selectedColours.Remove(this);
            if (selected)
            {
                return;
            }
            else
            {
                lblText.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            }
        }

        private void lblText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                if(selected == true)
                {
                    alreadySelected = true;
                }
                else
                {
                    selectedColours.Remove(this);
                    selected = false;
                    rightClicked = true;
                    alreadySelected = false;
                }

            }
            else
            {
                rightClicked = false;
                alreadySelected = false;
            }
            
        }

        private void qlFirst_Click(object sender, RoutedEventArgs e)
        {
            MainWindow o = (MainWindow)owner;
            o.txtCT1.Text = hex;
        }

        private void qlSecond_Click(object sender, RoutedEventArgs e)
        {
            MainWindow o = (MainWindow)owner;
            o.txtCT2.Text = hex;
        }

        private void qlThird_Click(object sender, RoutedEventArgs e)
        {
            MainWindow o = (MainWindow)owner;
            o.txtCT3.Text = hex;
        }

        private void qlFourth_Click(object sender, RoutedEventArgs e)
        {
            MainWindow o = (MainWindow)owner;
            o.txtCT4.Text = hex;
        }

        private void qlFifth_Click(object sender, RoutedEventArgs e)
        {
            MainWindow o = (MainWindow)owner;
            o.txtCT5.Text = hex;
        }
    }
}
