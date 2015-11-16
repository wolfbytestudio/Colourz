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



        public String hex;
        private String rgb;
        private StackPanel owner;
        private bool selected;

        public SavedColour(StackPanel owner,String rgb, String hex)
        {
            this.hex = hex;
            this.rgb = rgb;
            this.owner = owner;
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
            owner.Children.Remove(this);
        }

        private void lblText_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    if (selected)
                    {
                        selectedColours.Remove(this);
                        selected = false;
                    }
                    else
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
                }
            }
            catch
            {

            }

        }

        public static List<SavedColour> selectedColours = new List<SavedColour>();
    }
}
