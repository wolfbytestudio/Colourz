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

namespace Colourz.resource
{
    /// <summary>
    /// Interaction logic for ColourzSlider.xaml
    /// </summary>
    public partial class ColourSlider : UserControl
    {

        private double sliderWidth;
        private double divide = 1.937254901960784;
        private int sliderPositionX;
        public int getClick;
        public Grid mouseGrid { get; set; }
        public Boolean isDragging;
        public MainWindow owner;


        public ColourSlider(Color colour)
        {
            InitializeComponent();
            sliderWidth = recMain.Width;
            recValue.Fill = new SolidColorBrush(colour);
            divide = 255 / (recMain.Width - 10);
        }

        private void recSliderKnob_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
        }

        public void updateColours()
        {
            
            recMain.Fill = new SolidColorBrush(owner.getColourForHex(owner.theme.currentTheme.SliderRight));
            recSliderKnob.Fill = new SolidColorBrush(owner.getColourForHex(owner.theme.currentTheme.SliderKnob));

        }

        public void promptSliderMovement(double newX)
        {
            if(!isDragging) { return; }
            if (newX >= sliderWidth + 14) { newX = sliderWidth + 14; }
            if(newX <= recMain.Margin.Left + 15) { newX = 15; }

            double top = recSliderKnob.Margin.Top;
            double right = recSliderKnob.Margin.Right;
            double bottom = recSliderKnob.Margin.Bottom;

            sliderPositionX = (int) recSliderKnob.Margin.Left;

            recSliderKnob.Margin = new Thickness(newX - 20, top, right, bottom);

            double newValueWidth = recSliderKnob.Margin.Left + 5;
            if (newValueWidth < 0) { newValueWidth = 0; }
            recValue.Width = newValueWidth;
        }

        public int getValue()
        {

            int value = (int) Math.Round(sliderPositionX * divide);
            if(value > 255) { value = 255; }
            if(value < 0) {  value = 0; }
            return value;
        }

        private void recSliderKnob_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }

        public void setValue(int value)
        {
            double top = recSliderKnob.Margin.Top;
            double right = recSliderKnob.Margin.Right;
            double bottom = recSliderKnob.Margin.Bottom;
            sliderPositionX = (int) Math.Round(value / divide);
            recValue.Width = Math.Round(value / divide) + 5;
            recSliderKnob.Margin = new Thickness(sliderPositionX, top, right, bottom);
        }

        public void crementValue(int crement)
        {
            double currentValue = crement + Math.Abs((sliderPositionX * divide) + .5);
            if(currentValue >= 255)
            {
                currentValue = 255;
            }
            if(currentValue <= 0)
            {
                currentValue = 0;
            }
            setValue((int)currentValue);
        }

        public double sliderValue()
        {
            return sliderPositionX;
        }

        private void recBackboard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(Mouse.GetPosition(recBackboard).X > sliderPositionX)
            {
                crementValue(5);
            }
            else
            {
                crementValue(-5);
            }
        }

        private void recMain_MouseDown(object sender, MouseButtonEventArgs e)
        {
            crementValue(5);
        }

        private void recValue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            crementValue(-5);
        }


    }
}
