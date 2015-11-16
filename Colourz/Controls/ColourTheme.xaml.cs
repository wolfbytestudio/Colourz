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
    /// Interaction logic for ColourTheme.xaml
    /// </summary>
    public partial class ColourTheme : UserControl
    {

        public String name;
        public Object page;
        public Color[] colours = new Color[4];
        public StackPanel owner;
        
        public ColourTheme(Object page, StackPanel owner, String name, params Color[] colours)
        {
            InitializeComponent();
            this.page = page;
            this.owner = owner;
            this.name = name;
            this.colours = colours;
        }

        public void updateTheme()
        {
            recFirst.Fill = new SolidColorBrush(colours[0]);
            recSecond.Fill = new SolidColorBrush(colours[1]);
            recThird.Fill = new SolidColorBrush(colours[2]);
            recFourth.Fill = new SolidColorBrush(colours[3]);
            recFifth.Fill = new SolidColorBrush(colours[4]);
            txtThemeName.Text = name;
        }

        private void recFirst_MouseEnter(object sender, MouseEventArgs e)
        {
            recFirst.Opacity = .65;
        }

        private void recFirst_MouseLeave(object sender, MouseEventArgs e)
        {
            recFirst.Opacity = 1;
        }

        private void recSecond_MouseEnter(object sender, MouseEventArgs e)
        {
            recSecond.Opacity = .65;
        }

        private void recSecond_MouseLeave(object sender, MouseEventArgs e)
        {
            recSecond.Opacity = 1;
        }

        private void recThird_MouseEnter(object sender, MouseEventArgs e)
        {
            recThird.Opacity = .65;
        }

        private void recThird_MouseLeave(object sender, MouseEventArgs e)
        {
            recThird.Opacity = 1;
        }

        private void recFourth_MouseEnter(object sender, MouseEventArgs e)
        {
            recFourth.Opacity = .65;
        }

        private void recFourth_MouseLeave(object sender, MouseEventArgs e)
        {
            recFourth.Opacity = 1;
        }

        private void recFifth_MouseEnter(object sender, MouseEventArgs e)
        {
            recFifth.Opacity = .65;
        }

        private void recFifth_MouseLeave(object sender, MouseEventArgs e)
        {
            recFifth.Opacity = 1;
        }

        private void recFirst_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
        }

        private void men1Hex_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getHex(0));
        }

        private void men1RGB_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getRGB(0));
        }

        public string getHex(int index)
        {
            String hex = colours[index].R.ToString("X2") + colours[index].G.ToString("X2") + colours[index].B.ToString("X2");
            return "#" + hex;
        }

        public string getRGB(int index)
        {
            string rgb = "";
            rgb += colours[index].R + ", ";
            rgb += colours[index].G + ", ";
            rgb += colours[index].B;
            return rgb;
        }

        private void recMenuItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            owner.Children.Remove(this);
        }

        private void men2Hex_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getHex(1));
        }

        private void men2RGB_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getRGB(1));
        }

        private void men3Hex_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getHex(2));
        }

        private void men3RGB_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getRGB(2));
        }

        private void men4Hex_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getHex(3));
        }

        private void men4RGB_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getRGB(3));
        }

        private void men5Hex_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getHex(4));
        }

        private void men5RGB_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getRGB(4));
        }

        private void txtExit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            owner.Children.Remove(this);
            MainWindow.savedTheme.save();
        }

        private void txtExit_MouseEnter(object sender, MouseEventArgs e)
        {
            txtExit.Foreground = new SolidColorBrush(Color.FromRgb(255, 65, 65));
            txtExit.Background = new SolidColorBrush(Color.FromArgb(180, 0, 0, 0));
        }

        private void txtExit_MouseLeave(object sender, MouseEventArgs e)
        {
            txtExit.Foreground = new SolidColorBrush(Color.FromRgb(255, 152, 152));
            txtExit.Background = new SolidColorBrush(Color.FromArgb(85, 0, 0, 0));
        }

        private void txtEdit_MouseEnter(object sender, MouseEventArgs e)
        {
            txtEdit.Foreground = new SolidColorBrush(Color.FromRgb(28, 224, 255));
            txtEdit.Background = new SolidColorBrush(Color.FromArgb(180, 0, 0, 0));
        }

        private void txtEdit_MouseLeave(object sender, MouseEventArgs e)
        {
            txtEdit.Foreground = new SolidColorBrush(Color.FromRgb(156, 214, 255));
            txtEdit.Background = new SolidColorBrush(Color.FromArgb(85, 0, 0, 0));
        }

        private void txtEdit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow owner = (MainWindow)page;
            String hexFirst = colours[0].R.ToString("X2") + colours[0].G.ToString("X2") + colours[0].B.ToString("X2");
            String hexSecond = colours[1].R.ToString("X2") + colours[1].G.ToString("X2") + colours[1].B.ToString("X2");
            String hexThird = colours[2].R.ToString("X2") + colours[2].G.ToString("X2") + colours[2].B.ToString("X2");
            String hexFourth = colours[3].R.ToString("X2") + colours[3].G.ToString("X2") + colours[3].B.ToString("X2");
            String hexFifth = colours[4].R.ToString("X2") + colours[4].G.ToString("X2") + colours[4].B.ToString("X2");
            owner.loadTheme(name, hexFirst, hexSecond, hexThird, hexFourth, hexFifth);
        }
    }
}
