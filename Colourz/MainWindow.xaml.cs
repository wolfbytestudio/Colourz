using Colourz.Controls;
using Colourz.resource;
using Colourz.window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Colourz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// @author Zack Davidson
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Variables

        /// <summary>
        /// Checks to see if the window should be minimised
        /// </summary>
        private bool shouldMinimize;

        /// <summary>
        /// Checks to see if the window should be exited
        /// </summary>
        private bool shouldExit;

        /// <summary>
        /// Checks if the tab you're clicking on should be selected
        /// </summary>
        private bool shouldSelect;

        /// <summary>
        /// Object for tab - used for animations etc
        /// </summary>
        private Tab tab = new Tab();

        /// <summary>
        /// The red ColourSlider
        /// </summary>
        public ColourSlider redSlider = new ColourSlider(Color.FromRgb(220, 125, 125));

        /// <summary>
        /// The green ColourSlider
        /// </summary>
        public ColourSlider greenSlider = new ColourSlider(Color.FromRgb(131, 224, 119));

        /// <summary>
        /// The blue Colour slider
        /// </summary>
        public ColourSlider blueSlider = new ColourSlider(Color.FromRgb(115, 143, 225));

        /// <summary>
        /// Saved colourz saver
        /// </summary>
        public static SavedColourzSaver colourzSave;

        /// <summary>
        /// Saved 
        /// </summary>
        public static SavedThemesSaver savedTheme;

        /// <summary>
        /// The mouse X position
        /// </summary>
        private double mouseX;

        /// <summary>
        /// The mouse Y position
        /// </summary>
        private double mouseY;

        /// <summary>
        /// Checks if the selector can be dragged or not
        /// </summary>
        private bool dragSelector;
        
        /// <summary>
        /// The current tab we have selected
        /// </summary>
        private byte index = 0;

        /// <summary>
        /// Checks if we should change the text box
        /// </summary>
        private bool changeTextBox;
        
        /// <summary>
        /// The starting position for the colour selector
        /// </summary>
        private const double WHEEL_X = 237, WHEEL_Y = 235;

        /// <summary>
        /// If you should scroll down on the colour wheel
        /// </summary>
        bool scrollDownSC = true;

        /// <summary>
        /// Timer for saved scrolling on saved colours
        /// </summary>
        private DispatcherTimer timerSC = new DispatcherTimer();

        /// <summary>
        /// Check if you should scroll down on the colour themes
        /// </summary>
        bool scrollDownCT = true;

        /// <summary>
        /// Timer for saved scrolling on colour themes
        /// </summary>
        private DispatcherTimer timerCT = new DispatcherTimer();
        #endregion

        /// <summary>
        /// Updates the theme (Temporary)
        /// </summary>
        public void updateTheme()
        {
            Dispatcher.BeginInvoke(
                new Action(() => {

                    redSlider.updateColours();
                    greenSlider.updateColours();
                    blueSlider.updateColours();
                    tab.resetColours(lblColourGenerator, lblColourPicker, lblColourTheme, lblColourWheel, lblSavedColours, lblSettings);

                    if(Theme.blackTheme)
                    {
                        lblSettings.Foreground = Theme.HOVER_WHITE_WRITING;
                        recSideBar.Fill = Theme.RECTANGLE_BLACK_LIGHT;
                        recSelected.Fill = Theme.SELECTOR_DARK;
                        gridMain.Background = Theme.RECTANGLE_BLACK_DARK;
                        recTabHider.Fill = Theme.RECTANGLE_BLACK_DARK;
                        recSideBarSplit.Fill = Theme.SPLITTER_BLACK;
                        recTitleBar.Fill = Theme.RECTANGLE_BLACK_LIGHT;
                        lblTitle.Foreground = Theme.HOVER_WHITE_WRITING;
                        recSeperateTitle.Fill = Theme.SEPERATE_DARK;
                        lblCWHEX.Foreground = Theme.HOVER_WHITE_WRITING;
                        lblCWRGB.Foreground = Theme.HOVER_WHITE_WRITING;
                        lblSTheme.Foreground = Theme.HOVER_WHITE_WRITING;
                        chbSAnimations.Foreground = Theme.HOVER_WHITE_WRITING;
                        lblSSidePanelSColour.Foreground = Theme.HOVER_WHITE_WRITING;
                        lblSCGuide.Foreground = Theme.NORMAL_WHITE_WRITING;

                        txtCTScrollDown.Foreground = Theme.HOVER_WHITE_WRITING;
                        txtCTScrollUp.Foreground = Theme.HOVER_WHITE_WRITING;
                        txtSCScrollDown.Foreground = Theme.HOVER_WHITE_WRITING;
                        txtSCScrollUp.Foreground = Theme.HOVER_WHITE_WRITING;

                        txtCTScrollDown.Background = Theme.SCROLLERS_NORMAL_DARK;
                        txtCTScrollUp.Background = Theme.SCROLLERS_NORMAL_DARK;
                        txtSCScrollDown.Background = Theme.SCROLLERS_NORMAL_DARK;
                        txtSCScrollUp.Background = Theme.SCROLLERS_NORMAL_DARK;

                        scrollThemes.Background = Theme.SCROLLABLES_DARK;
                        scrSavedColours.Background = Theme.SCROLLABLES_DARK;
                    }
                    else
                    {
                        lblSettings.Foreground = Theme.HOVER_BLACK_WRITING;
                        recSideBar.Fill = Theme.RECTANGLE_WHITE_LIGHT;
                        recSelected.Fill = Theme.SELECTOR_LIGHT;
                        gridMain.Background = Theme.RECTANGLE_WHITE_DARK;
                        recTabHider.Fill = Theme.RECTANGLE_WHITE_DARK;
                        recSideBarSplit.Fill = Theme.SPLITTER_WHITE;
                        recTitleBar.Fill = Theme.RECTANGLE_WHITE_LIGHT;
                        lblTitle.Foreground = Theme.HOVER_BLACK_WRITING;
                        recSeperateTitle.Fill = Theme.SEPERATE_LIGHT;
                        lblCWHEX.Foreground = Theme.HOVER_BLACK_WRITING;
                        lblCWRGB.Foreground = Theme.HOVER_BLACK_WRITING;
                        lblSTheme.Foreground = Theme.HOVER_BLACK_WRITING;
                        chbSAnimations.Foreground = Theme.HOVER_BLACK_WRITING;
                        lblSSidePanelSColour.Foreground = Theme.HOVER_BLACK_WRITING;
                        lblSCGuide.Foreground = Theme.NORMAL_BLACK_WRITING;

                        txtCTScrollDown.Foreground = Theme.HOVER_BLACK_WRITING;
                        txtCTScrollUp.Foreground = Theme.HOVER_BLACK_WRITING;
                        txtSCScrollDown.Foreground = Theme.HOVER_BLACK_WRITING;
                        txtSCScrollUp.Foreground = Theme.HOVER_BLACK_WRITING;

                        txtCTScrollDown.Background = Theme.SCROLLERS_NORMAL_LIGHT;
                        txtCTScrollUp.Background = Theme.SCROLLERS_NORMAL_LIGHT;
                        txtSCScrollDown.Background = Theme.SCROLLERS_NORMAL_LIGHT;
                        txtSCScrollUp.Background = Theme.SCROLLERS_NORMAL_LIGHT;

                        scrollThemes.Background = Theme.SCROLLABLES_LIGHT;
                        scrSavedColours.Background = Theme.SCROLLABLES_LIGHT;
                    }

                })
            );

        }

        #region Constructor
        /// <summary>
        /// Default Constructor for MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            tab.selected = 0;

            redSlider.setValue(0);
            greenSlider.setValue(0);
            blueSlider.setValue(0);

            redSlider.Margin = new Thickness(-135, 230, 0, 0);
            greenSlider.Margin = new Thickness(-135, 330, 0, 0);
            blueSlider.Margin = new Thickness(-135, 430, 0, 0);

            redSlider.MouseDown += new MouseButtonEventHandler(sliderMouseDownRed);
            redSlider.MouseUp += new MouseButtonEventHandler(sliderMouseUp);

            greenSlider.MouseDown += new MouseButtonEventHandler(sliderMouseDownGreen);
            greenSlider.MouseUp += new MouseButtonEventHandler(sliderMouseUp);

            blueSlider.MouseDown += new MouseButtonEventHandler(sliderMouseDownBlue);
            blueSlider.MouseUp += new MouseButtonEventHandler(sliderMouseUp);

            gridColourGenerator.Children.Add(redSlider);
            gridColourGenerator.Children.Add(greenSlider);
            gridColourGenerator.Children.Add(blueSlider);

            timerSC.Tick += timerSCEvent;
            timerSC.Interval = new TimeSpan(0, 0, 0, 0, 100);

            timerCT.Tick += timerCTEvent;
            timerCT.Interval = new TimeSpan(0, 0, 0, 0, 30);

            colourzSave = new SavedColourzSaver(this, stkSavedColours);
            colourzSave.load();

            savedTheme = new SavedThemesSaver(this, CTThemes);
            savedTheme.load();
        }
        #endregion

        #region Top Components Handler
        private void cmdMinimize_MouseEnter(object sender, MouseEventArgs e)
        {
            shouldMinimize = true;
            cmdMinimize.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/minimize_hover.png", UriKind.Relative));
        }

        private void cmdMinimize_MouseLeave(object sender, MouseEventArgs e)
        {
            shouldMinimize = false;
            cmdMinimize.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/minimize_normal.png", UriKind.Relative));
        }

        private void cmdMinimize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cmdMinimize.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/minimize_mouseDown.png", UriKind.Relative));
        }

        private void cmdMinimize_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(shouldMinimize) {
                frmMain.WindowState = WindowState.Minimized;
            }
            cmdMinimize.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/minimize_normal.png", UriKind.Relative));
        }

        private void recTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            } catch { }
        }

        private void lblTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            } catch { }
        }

        private void cmdExit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cmdExit.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/exit_mouseDown.png", UriKind.Relative));
        }

        private void cmdExit_MouseEnter(object sender, MouseEventArgs e)
        {
            shouldExit = true;
            cmdExit.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/exit_hover.png", UriKind.Relative));
        }

        private void cmdExit_MouseLeave(object sender, MouseEventArgs e)
        {
            shouldExit = false;
            cmdExit.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/exit_normal.png", UriKind.Relative));
        }

        private void cmdExit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(shouldExit) 
            {
                frmMain.Close();
            }
            cmdExit.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/exit_normal.png", UriKind.Relative));
        }
        #endregion

        #region Mouse Events
        private void recColourGenerator_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { return; }
            lblColourGenerator.Foreground = Theme.getColourForTheme(new TextBlock(), true);
            shouldSelect = true;
        }

        private void recColourGenerator_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { return; }
            if(tab.selected == 1) { return; }
            lblColourGenerator.Foreground = Theme.getColourForTheme(new TextBlock(), false);
            shouldSelect = false;
        }

        private void recColourPicker_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { return; }
            lblColourPicker.Foreground = Theme.getColourForTheme(new TextBlock(), true);
            shouldSelect = true;
        }

        private void recColourPicker_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { return; }
            if (tab.selected == 2) { return; }
            lblColourPicker.Foreground = Theme.getColourForTheme(new TextBlock(), false);
            shouldSelect = false;
        }

        private void recColourTheme_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { return; }
            lblColourTheme.Foreground = Theme.getColourForTheme(new TextBlock(), true);
            shouldSelect = true;
        }

        private void recColourTheme_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { return; }
            if (tab.selected == 3) { return; }
            lblColourTheme.Foreground = Theme.getColourForTheme(new TextBlock(), false);
            shouldSelect = false;
        }

        private void recSavedColours_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { return; }
            lblSavedColours.Foreground = Theme.getColourForTheme(new TextBlock(), true);
            shouldSelect = true;
        }

        private void recSavedColours_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { return; }
            if (tab.selected == 4) { return;
            }
            lblSavedColours.Foreground = Theme.getColourForTheme(new TextBlock(), false);
            shouldSelect = false;
        }

        private void recColourWheel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { return; }
            lblColourWheel.Foreground = Theme.getColourForTheme(new TextBlock(), true);
            shouldSelect = true;
        }

        private void recSettings_MouseLeave(object sender, MouseEventArgs e)
        {
            if (tab.selected == 5) { return; }
            lblSettings.Foreground = Theme.getColourForTheme(new TextBlock(), false);
            shouldSelect = false;
        }

        private void recSettings_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { return; }
            lblSettings.Foreground = Theme.getColourForTheme(new TextBlock(), true);
            shouldSelect = true;
        }

        private void recColourWheel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (tab.selected == 0) { return; }
            lblColourWheel.Foreground = Theme.getColourForTheme(new TextBlock(), false);
            shouldSelect = false;
        }

        private void recColourGenerator_MouseUp(object sender, MouseButtonEventArgs e)
        {
            clickTab(1, "colour_generator_selected.png", iconColourGenerator, (Rectangle)sender, lblColourGenerator);
        }

        private void recColourWheel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            clickTab(0, "colour_wheel_selected.png", iconColourWheel, (Rectangle)sender, lblColourWheel);
        }

        private void recColourPicker_MouseUp(object sender, MouseButtonEventArgs e)
        {
            clickTab(2, "colour_picker_selected.png", iconColourPicker, (Rectangle)sender, lblColourPicker);
        }

        private void recColourTheme_MouseUp(object sender, MouseButtonEventArgs e)
        {
            clickTab(3, "colour_theme_selected.png", iconColourTheme,(Rectangle)sender, lblColourTheme);
        }

        private void recSavedColours_MouseUp(object sender, MouseButtonEventArgs e)
        {
            clickTab(4, "saved_colour_selected.png", iconSavedColours, (Rectangle)sender, lblSavedColours);
        }

        private void recSettings_MouseUp(object sender, MouseButtonEventArgs e)
        {
            clickTab(5, "settings_icon_selected.png", iconSettings, (Rectangle)sender, lblSettings);
        }

        /// <summary>
        /// Handles the clicking of a new tab
        /// </summary>
        /// <param name="selected">the selected tab index</param>
        /// <param name="imageSource">the image source</param>
        /// <param name="image">The image itself</param>
        /// <param name="sender">The sender position</param>
        /// <param name="text">The textblock to change</param>
        public void clickTab(int selected, string imageSource, Image image, Rectangle sender, TextBlock text)
        {
            if (Animation.doingAnimation) { return; }
            if (shouldSelect)
            {
                Rectangle rec = sender;
                resetImages();
                image.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/" + imageSource, UriKind.Relative));
                tab.sender = rec;
                tab.resetColours(lblColourGenerator, lblColourPicker, lblColourTheme, lblColourWheel, lblSavedColours, lblSettings);
                tab.selected = selected;
                tab.moveComponents(recSelected);
                tab.moveComponents(recSelectedColour);
                text.Foreground = Theme.getColourForTheme(new TextBlock(), true);
                tabSelected.SelectedIndex = selected;
            }
        }
        #endregion

        /// <summary>
        /// Resets all the image icons
        /// </summary>
        private void resetImages()
        {
            iconColourWheel.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/colour_wheel_normal.png", UriKind.Relative));
            iconColourGenerator.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/colour_generator_normal.png", UriKind.Relative));
            iconColourPicker.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/colour_picker_normal.png", UriKind.Relative));
            iconColourTheme.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/colour_theme_normal.png", UriKind.Relative));
            iconSavedColours.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/saved_colour_normal.png", UriKind.Relative));
            iconSettings.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/settings_icon_normal.png", UriKind.Relative));
        }

        private void imgSelector_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dragSelector = true;
        }

        private void imgWheel_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.GetPosition(gridColourWheel).X;
            mouseY = e.GetPosition(gridColourWheel).Y;
            moveSelector(mouseX, mouseY);
        }

        /// <summary>
        /// Moves the selector to a certain position
        /// </summary>
        /// <param name="x">the new X coordinates the selector should take</param>
        /// <param name="y">the new Y coordinates the selector should take</param>
        private void moveSelector(double x, double y)
        {
            if (dragSelector)
            {
                if (Math.Sqrt(
                    Math.Pow(WHEEL_X - (x - 5), 2)
                    + Math.Pow(WHEEL_Y - (y - 5), 2)) >= 230)
                {
                    return;
                }
                imgSelector.Margin = new Thickness(x, y, imgSelector.Margin.Right, imgSelector.Margin.Bottom);
                txtCWHEX.Text = "#" + recColour.Fill.ToString().Substring(3);

                Color col = (Color)ColorConverter.ConvertFromString(recColour.Fill.ToString());
                txtCWRGB.Text = col.R + ", " + col.G + ", " + col.B;
            }
        }

        private void imgSelector_MouseUp(object sender, MouseButtonEventArgs e)
        {
            dragSelector = false;
        }

        private void imgSelector_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.GetPosition(gridColourWheel).X;
            mouseY = e.GetPosition(gridColourWheel).Y;
            if (dragSelector)
            {

                if (Math.Sqrt(
                    Math.Pow(WHEEL_X - imgSelector.Margin.Left, 2) 
                    + Math.Pow(WHEEL_Y - imgSelector.Margin.Top, 2)) >= 228)
                {
                    return;
                }

                imgSelector.Margin = new Thickness(mouseX - 10, mouseY - 9, imgSelector.Margin.Right, imgSelector.Margin.Bottom);
                try
                {
                    byte[] pixels = new byte[4];
                    double x = imgSelector.Margin.Left;
                    double y = imgSelector.Margin.Top;
                    
                    BitmapSource bitmapSource = imgWheel.Source as BitmapSource;
                    int stride = (bitmapSource.PixelWidth * bitmapSource.Format.BitsPerPixel + 7) / 8;
                    bitmapSource.CopyPixels(new Int32Rect((int)x, (int)y, 1, 1), pixels, stride, 0);
                    CroppedBitmap cbs = new CroppedBitmap(bitmapSource, new Int32Rect((int)x, (int)y, 1, 1));

                    recColour.Fill = new SolidColorBrush(Color.FromArgb(255, pixels[2], pixels[1], pixels[0]));
                    Color newCol = calculateOpacity();

                    txtCWHEX.Text = getHexForColour(newCol);
                    txtCWRGB.Text = newCol.R + ", " + newCol.G + ", " + newCol.B;
                }
                catch { }
            }
        }

        private void imgWheel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            dragSelector = false;
        }

        private void gridColourWheel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            dragSelector = false;
        }

        private void sldCWBrightness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            recColour.Opacity = sldCWBrightness.Value / 100;
            Color col = calculateOpacity();

            txtCWHEX.Text = getHexForColour(col);

            txtCWRGB.Text = col.R + ", " + col.G + ", " + col.B;
        }

        private void gridColourGenerator_MouseMove(object sender, MouseEventArgs e)
        {
            if(changeTextBox)
            {
                updateColourTextBoxes();
            }
        }

        /// <summary>
        /// Updates the colour text boxes
        /// </summary>
        public void updateColourTextBoxes()
        {
            txtCGRed.Text = redSlider.getValue().ToString();
            txtCGGreen.Text = greenSlider.getValue().ToString();
            txtCGBlue.Text = blueSlider.getValue().ToString();


            if (index == 0)
            {
                redSlider.promptSliderMovement(Mouse.GetPosition(gridColourGenerator).X);
            }
            else if (index == 1)
            {
                greenSlider.promptSliderMovement(Mouse.GetPosition(gridColourGenerator).X);
            }
            else if (index == 2)
            {
                blueSlider.promptSliderMovement(Mouse.GetPosition(gridColourGenerator).X);
            }

            updateCGColour();
        }

        
        private void sliderMouseDownRed(object sender, MouseButtonEventArgs e)
        {
            changeTextBox = true;
            index = 0;
            updateColourTextBoxes();
        }

        private void sliderMouseDownGreen(object sender, MouseButtonEventArgs e)
        {
            changeTextBox = true;
            index = 1;
            updateColourTextBoxes();
        }

        private void sliderMouseDownBlue(object sender, MouseButtonEventArgs e)
        {
            changeTextBox = true;
            index = 2;
            updateColourTextBoxes();
        }

        private void sliderMouseUp(object sender, MouseButtonEventArgs e)
        {
            changeTextBox = false;
            updateColourTextBoxes();
        }

        /// <summary>
        /// Updates the colour generator
        /// </summary>
        private void updateCGColour()
        {

            Color generateColour = Color.FromRgb(
                (byte) redSlider.getValue(),
                (byte)greenSlider.getValue(),
                (byte)blueSlider.getValue());

            recCGColour.Fill = new SolidColorBrush(generateColour);

            Color rgb = (Color)recCGColour.Fill.GetValue(SolidColorBrush.ColorProperty);

            string hex = rgb.R.ToString("X2") + rgb.G.ToString("X2") + rgb.B.ToString("X2");
            txtCGHex.Text = getHexForRectangle(recCGColour);
            txtCGRGB.Text = rgb.R + ", " + rgb.G + ", " + rgb.B;

            recCGBright.Fill = new SolidColorBrush(getDifferentShade(-40, null));
            recCGBrighter.Fill = new SolidColorBrush(getDifferentShade(-80, null));
            recCGBrightest.Fill = new SolidColorBrush(getDifferentShade(-120, null));


            recCGDark.Fill = new SolidColorBrush(getDifferentShade(40, null));
            recCGDarker.Fill = new SolidColorBrush(getDifferentShade(80, null));
            recCGDarkest.Fill = new SolidColorBrush(getDifferentShade(120, null));
        }

        /// <summary>
        /// Gets a different shade of colour depending on value
        /// </summary>
        /// <param name="value">The next shade of colour to increment/decrement by</param>
        /// <returns>the new shaded colour</returns>
        public Color getDifferentShade(int value, Rectangle rec)
        {
            Color c;
            if(rec != null)
            {
                c = (Color)rec.Fill.GetValue(SolidColorBrush.ColorProperty);
            }
            else
            {
                c = (Color)recCGColour.Fill.GetValue(SolidColorBrush.ColorProperty);
            }
           

            int newR = c.R - value;
            if (newR < 0) newR = 0;
            else if (newR > 255) newR = 255;

            int newG = c.G - value;
            if (newG < 0) newG = 0;
            else if (newG > 255) newG = 255;

            int newB = c.B - value;
            if (newB < 0) newB = 0;
            else if (newB > 255) newB = 255;

            c = Color.FromRgb((byte)newR, (byte)newG, (byte)newB);
            return c;
        }

        private void txtCGRGB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string colour = txtCGRGB.Text;
                string[] segment = colour.Split(' ');

                string red = segment[0].Substring(0, segment[0].Length - 1);
                string green = segment[1].Substring(0, segment[1].Length - 1);
                string blue = segment[2];

                Color generateColour = Color.FromRgb(byte.Parse(red), byte.Parse(green), byte.Parse(blue));
                recCGColour.Fill = new SolidColorBrush(generateColour);

                redSlider.setValue(int.Parse(red));
                greenSlider.setValue(int.Parse(green));
                blueSlider.setValue(int.Parse(blue));

                Color rgb = (Color)recCGColour.Fill.GetValue(SolidColorBrush.ColorProperty);

                String hex = rgb.R.ToString("X2") + rgb.G.ToString("X2") + rgb.B.ToString("X2");
                txtCGHex.Text = "#" + hex;
                txtCGRGB.Text = rgb.R + ", " + rgb.G + ", " + rgb.B;


                txtCGRed.Text = red;
                txtCGGreen.Text = green;
                txtCGBlue.Text = blue;
            }
            catch
            {
                
            }
        }

        private void txtCGHex_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml(txtCGHex.Text);
                Color generateColour = Color.FromRgb(col.R, col.G, col.B);
                recCGColour.Fill = new SolidColorBrush(generateColour);

                redSlider.setValue(col.R);
                greenSlider.setValue(col.G);
                blueSlider.setValue(col.B);

                Color rgb = (Color)recCGColour.Fill.GetValue(SolidColorBrush.ColorProperty);

                txtCGHex.Text = "#" + getHexForColour(rgb);
                txtCGRGB.Text = getRgbForColour(rgb);

                txtCGRed.Text = rgb.R.ToString();
                txtCGGreen.Text = rgb.G.ToString();
                txtCGBlue.Text = rgb.B.ToString();
            } catch { }
        }

        private void txtCGRed_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(changeTextBox == true) { return; }
            try
            {
                int value = Convert.ToInt32(txtCGRed.Text);
                if(value < 0)
                {
                    value = 0;
                }
                else if(value > 255)
                {
                    value = 255;
                }
                redSlider.setValue(value);
                updateCGColour();
            }
            catch(Exception ec)
            {
                Console.WriteLine(ec.StackTrace);
            }
        }

        private void txtCGGreen_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (changeTextBox == true)
            {
                return;
            }
            try
            {
                int value = Convert.ToInt32(txtCGGreen.Text);
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > 255)
                {
                    value = 255;
                }
                greenSlider.setValue(value);
                updateCGColour();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.StackTrace);
            }
        }

        private void txtCGBlue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (changeTextBox == true)
            {
                return;
            }
            try
            {
                int value = Convert.ToInt32(txtCGBlue.Text);
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > 255)
                {
                    value = 255;
                }
                blueSlider.setValue(value);
                updateCGColour();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.StackTrace);
            }
        }

        private void gridColourGenerator_MouseUp(object sender, MouseButtonEventArgs e)
        {
            redSlider.isDragging = false;
            greenSlider.isDragging = false;
            blueSlider.isDragging = false;
        }

        private void cmbTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbTheme.SelectedIndex == 0)
            {
                Theme.blackTheme = true;
            }
            else
            {
                Theme.blackTheme = false;
            }

            updateTheme();
        }

        private void gridMain_MouseUp(object sender, MouseButtonEventArgs e)
        {
            redSlider.isDragging = false;
            greenSlider.isDragging = false;
            blueSlider.isDragging = false;
        }

        private void gridMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (changeTextBox)
            {
                txtCGRed.Text = redSlider.getValue().ToString();
                txtCGGreen.Text = greenSlider.getValue().ToString();
                txtCGBlue.Text = blueSlider.getValue().ToString();


                if (index == 0)
                {
                    redSlider.promptSliderMovement(Mouse.GetPosition(gridColourGenerator).X);
                }
                else if (index == 1)
                {
                    greenSlider.promptSliderMovement(Mouse.GetPosition(gridColourGenerator).X);
                }
                else if (index == 2)
                {
                    blueSlider.promptSliderMovement(Mouse.GetPosition(gridColourGenerator).X);
                }

                updateCGColour();
            }
        }

        private void chbSAnimations_Click(object sender, RoutedEventArgs e)
        {
            if(chbSAnimations.IsChecked.Equals(true))
            {
                Animation.disableAnimation = true;
            }
            else
            {
                Animation.disableAnimation = false;
            }
        }

        private void cmdSaveTheme_Click(object sender, RoutedEventArgs e)
        {
            ColourTheme theme = new ColourTheme(this, CTThemes, txtThemeName.Text,
                (Color)recCT1.Fill.GetValue(SolidColorBrush.ColorProperty),
                (Color)recCT2.Fill.GetValue(SolidColorBrush.ColorProperty),
                (Color)recCT3.Fill.GetValue(SolidColorBrush.ColorProperty),
                (Color)recCT4.Fill.GetValue(SolidColorBrush.ColorProperty),
                (Color)recCT5.Fill.GetValue(SolidColorBrush.ColorProperty));
            theme.updateTheme();
            CTThemes.Children.Insert(0, theme);
            savedTheme.save();
            loadTheme("Theme Name", "FFFFFF", "B6B6B6", "7C7C7C", "494949", "131313");
        }

        private void txtCT1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                recCT1.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(txtCT1.Text));
            }
            catch { }
        }

        private void txtCT2_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                recCT2.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(txtCT2.Text));
            } catch { }
        }

        private void txtCT3_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                recCT3.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(txtCT3.Text));
            }
            catch { }
        }

        private void txtCT4_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                recCT4.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(txtCT4.Text));
            }
            catch { }
        }

        private void txtCT5_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                recCT5.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(txtCT5.Text));
            }
            catch { }
        }

        private void txtSSelectorColour_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Color colour = (Color) ColorConverter.ConvertFromString("#" + txtSSelectorColour.Text);
                recSelectedColour.Fill = new SolidColorBrush(colour);
            }
            catch
            {
                recSelectedColour.Fill = new SolidColorBrush(Color.FromRgb(33, 99, 230));
            }
        }

        private void cmdCGReset_Click(object sender, RoutedEventArgs e)
        {
            redSlider.setValue(0);
            greenSlider.setValue(0);
            blueSlider.setValue(0);

            txtCGRed.Text = "0";
            txtCGGreen.Text = "0";
            txtCGBlue.Text = "0";

            updateCGColour();
        }

        private void txtSCScrollDown_MouseEnter(object sender, MouseEventArgs e)
        {

            txtSCScrollDown.Background = Theme.getScrollers(true);
            scrollDownSC = true;
            startSC();
        }

        private void txtSCScrollDown_MouseLeave(object sender, MouseEventArgs e)
        {
            txtSCScrollDown.Background = Theme.getScrollers(false);
            stopSC();
        }

        private void txtSCScrollUp_MouseEnter(object sender, MouseEventArgs e)
        {
            txtSCScrollUp.Background = Theme.getScrollers(true);
            scrollDownSC = false;
            startSC();
        }

        private void txtSCScrollUp_MouseLeave(object sender, MouseEventArgs e)
        {
            txtSCScrollUp.Background = Theme.getScrollers(false);
            stopSC();
        }


        /// <summary>
        /// Saved colours scroll timer start
        /// </summary>
        public void startSC()
        {
            timerSC.Start();
        }

        /// <summary>
        /// Saved colours scroll timer stop
        /// </summary>
        public void stopSC()
        {
            timerSC.Stop();
        }

        private void timerSCEvent(object sender, EventArgs e)
        {
            if(scrollDownSC)
            {
                scrSavedColours.LineDown();
            }
            else
            {
                scrSavedColours.LineUp();
            }
        }

        private void txtCTScrollDown_MouseEnter(object sender, MouseEventArgs e)
        {
            txtCTScrollDown.Background = Theme.getScrollers(true);
            scrollDownCT = true;
            startCT();
        }

        private void txtCTScrollDown_MouseLeave(object sender, MouseEventArgs e)
        {
            txtCTScrollDown.Background = Theme.getScrollers(false);
            stopCT();
        }

        private void txtCTScrollUp_MouseEnter(object sender, MouseEventArgs e)
        {
            txtCTScrollUp.Background = Theme.getScrollers(true);
            scrollDownCT = false;
            startCT();
        }

        private void txtCTScrollUp_MouseLeave(object sender, MouseEventArgs e)
        {
            txtCTScrollUp.Background = Theme.getScrollers(false);
            stopCT();
        }



        /// <summary>
        /// Colour theme scroll timer start
        /// </summary>
        public void startCT()
        {
            timerCT.Start();
        }

        /// <summary>
        /// Colour theme scroll timer stop
        /// </summary>
        public void stopCT()
        {
            timerCT.Stop();
        }

        private void timerCTEvent(object sender, EventArgs e)
        {
            if (scrollDownCT)
            {
                scrollThemes.LineDown();
            }
            else
            {
                scrollThemes.LineUp();
            }
        }

        private void txtSavedColours_MouseEnter(object sender, MouseEventArgs e)
        {
            return;
        }

        private void cmdCTReset_Click(object sender, RoutedEventArgs e)
        {
            loadTheme("Theme Name","FFFFFF", "B6B6B6", "7C7C7C", "494949", "131313");
        }

        private void cmdCTClear_Click(object sender, RoutedEventArgs e)
        {
            CTThemes.Children.RemoveRange(0, CTThemes.Children.Count);
        }

        private void cmdSCDeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            foreach(SavedColour t in SavedColour.selectedColours)
            {
                stkSavedColours.Children.Remove(t);
            }
            colourzSave.save();
        }

        private void btnCWSave_Click(object sender, RoutedEventArgs e)
        {
            saveColourWheelColour();
        }

        /// <summary>
        /// Saves the colour wheel colour
        /// </summary>
        private void saveColourWheelColour()
        {
            Color color = calculateOpacity();

            stkSavedColours.Children.Add(new SavedColour(this,
                    stkSavedColours, getRgbForColour(color), "#" + getHexForColour(color) + ""));

            colourzSave.save();
        }

        private void wolfbyteEnter(object sender, MouseEventArgs e)
        {
            txtWolfbyte.Foreground = new SolidColorBrush(Color.FromArgb(255, 21, 148, 195));
            imgWolfbyte.OpacityMask = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        }

        private void wolfbyteLeave(object sender, MouseEventArgs e)
        {
            txtWolfbyte.Foreground = new SolidColorBrush(Color.FromArgb(127, 21, 148, 195));
            imgWolfbyte.OpacityMask = new SolidColorBrush(Color.FromArgb(127, 0, 0, 0));
        }

        private void wolfyteDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            } catch { }
        }

        private void cmdSCClear_Click(object sender, RoutedEventArgs e)
        {
            stkSavedColours.Children.Clear();
        }

        private void cmdCGSaveColour_Click(object sender, RoutedEventArgs e)
        {
            saveColourGenerator();
        }

        /// <summary>
        /// Gets the hex code for a colour
        /// </summary>
        /// <param name="colour">the colour</param>
        /// <returns>the hex for that colour</returns>
        private string getHexForColour(Color colour)
        {
            string hex = colour.R.ToString("X2")
                + colour.G.ToString("X2") 
                + colour.B.ToString("X2");
            return "#" + hex;
        }

        /// <summary>
        /// Gets the hex code for a rectangle
        /// </summary>
        /// <param name="rec">the rectangle</param>
        /// <returns>the hex code</returns>
        private string getHexForRectangle(Rectangle rec)
        {
            Color col = (Color)rec.Fill.GetValue(SolidColorBrush.ColorProperty);
            return getHexForColour(col);
        }

        /// <summary>
        /// Saves the colour for the generator
        /// </summary>
        private void saveColourGenerator()
        {
            try
            {
                Color rgb = Color.FromRgb(Convert.ToByte(redSlider.getValue().ToString()),
                    Convert.ToByte(greenSlider.getValue().ToString()),
                    Convert.ToByte(blueSlider.getValue().ToString()));


                stkSavedColours.Children.Add(new SavedColour(this,
                    stkSavedColours, "" + getRgbForColour(rgb) + "", getHexForColour(rgb) + ""));
                colourzSave.save();
            }
            catch
            {
                MessageBox.Show(this, "Error saving colour. Code: 0x000001");
            }
        }

        private void cmdColourPickerStart_Click(object sender, RoutedEventArgs e)
        {
            if(!ColourPicker.pickerShown)
            {
                clickTab(4, "saved_colour_selected.png", iconSavedColours, recSavedColours, lblSavedColours);

                window.ColourPicker picker = new window.ColourPicker();
                picker.owner = this;
                picker.Owner = this;
                picker.Show();
                ColourPicker.pickerShown = true;
            }

        }

        /// <summary>
        /// Loads the a new theme
        /// </summary>
        /// <param name="title">The title of the theme</param>
        /// <param name="first">The first colour hex code</param>
        /// <param name="second">The second colour hex code</param>
        /// <param name="third">The third colour hex code</param>
        /// <param name="fourth">The fourth colour hex code</param>
        /// <param name="fifth">The fifth colour hex code</param>
        public void loadTheme(string title, string first, string second, string third, string fourth, string fifth)
        {
            txtThemeName.Text = title;
            txtCT1.Text = "#" + first;
            txtCT2.Text = "#" + second;
            txtCT3.Text = "#" + third;
            txtCT4.Text = "#" + fourth;
            txtCT5.Text = "#" + fifth;
        }

        private void gridColourGenerator_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                switch(tab.selected)
                {
                    case 0:
                        saveColourWheelColour();
                        break;
                    case 1:
                        saveColourGenerator();
                        break;
                }
            }
            
        }

        private void scrSavedColours_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                foreach (SavedColour t in stkSavedColours.Children)
                {
                    t.select();
                }
            }
        }

        private void cmdSelectAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (SavedColour t in stkSavedColours.Children)
            {
                t.select();
            }
        }

        private void cmdDeselectAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (SavedColour t in stkSavedColours.Children)
            {
                t.unselect();
            }
        }

        private void cgDarkSave_Click(object sender, RoutedEventArgs e)
        {
            saveColourForRectangle(recCGDark);
        }

        /// <summary>
        /// Saves a colour based on the rectangle colour
        /// </summary>
        /// <param name="s">the rectangle</param>
        public void saveColourForRectangle(Rectangle s)
        {
            Color col = (Color)s.Fill.GetValue(SolidColorBrush.ColorProperty);

            stkSavedColours.Children.Add(new SavedColour(this,
                stkSavedColours, "" + col.R + ", " + col.G +
                ", " + col.B + "", getHexForRectangle(s) + ""));
            colourzSave.save();
        }

        /// <summary>
        /// Gets rgb string format for the rectangle
        /// </summary>
        /// <param name="s">the rectangle</param>
        /// <returns>rgb string format</returns>
        public string getRGBForRectangle(Rectangle s)
        {
            Color col = (Color)s.Fill.GetValue(SolidColorBrush.ColorProperty);
            string rgb = col.R + ", " + col.G +
                    ", " + col.B;
            return rgb;
        }

        /// <summary>
        /// Gets rgb string format for the colour
        /// </summary>
        /// <param name="c">the color</param>
        /// <returns>rgb string format</returns>
        public string getRgbForColour(Color c)
        {
            Color col = c;
            string rgb = col.R + ", " + col.G +
                    ", " + col.B;
            return rgb;
        }

        private void cgLightMenu_Click(object sender, RoutedEventArgs e)
        {
            saveColourForRectangle(recCGBright);
        }

        private void cgBrighter_Click(object sender, RoutedEventArgs e)
        {
            saveColourForRectangle(recCGBrighter);
        }

        private void cgDarkerSave_Click(object sender, RoutedEventArgs e)
        {
            saveColourForRectangle(recCGDarker);
        }

        private void cgDarkestSave_Click(object sender, RoutedEventArgs e)
        {
            saveColourForRectangle(recCGDarkest);
        }

        private void cgLightest_Click(object sender, RoutedEventArgs e)
        {
            saveColourForRectangle(recCGBrightest);
        }

        private void cgNormal_Click(object sender, RoutedEventArgs e)
        {
            saveColourForRectangle(recCGColour);
        }

        private void cgDarkestHex_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getHexForRectangle(recCGDarkest));
        }

        private void cgDarkestRGB_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getRGBForRectangle(recCGDarkest));
        }

        private void cgBrightestHex_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getHexForRectangle(recCGBrightest));
        }

        private void cgBrightestGB_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getRGBForRectangle(recCGBrightest));
        }

        private void cgDarkerHex_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getHexForRectangle(recCGDarker));
        }

        private void cgDarkerGB_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getRGBForRectangle(recCGDarker));
        }

        private void cgDarkHex_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getHexForRectangle(recCGDark));
        }

        private void cgDarkRGB_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getRGBForRectangle(recCGDark));
        }

        private void cgBrighterHex_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getHexForRectangle(recCGBrighter));
        }

        private void cgBrighterRGB_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getRGBForRectangle(recCGBrighter));
        }

        private void cgBrightHex_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getHexForRectangle(recCGBright));
        }

        private void cgBrightRGB_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getRGBForRectangle(recCGBright));
        }

        private void cgNormalHex_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getHexForRectangle(recCGColour));
        }

        private void cgNormalRGB_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(getRGBForRectangle(recCGColour));
        }

        private void imgWheel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dragSelector = true;
            mouseX = e.GetPosition(gridColourWheel).X;
            mouseY = e.GetPosition(gridColourWheel).Y;
            moveSelector(mouseX, mouseY);
        }

        private void txtSCScrollUp_MouseUp(object sender, MouseButtonEventArgs e)
        {
            scrSavedColours.LineUp();
        }

        private void txtSCScrollDown_MouseUp(object sender, MouseButtonEventArgs e)
        {
            scrSavedColours.LineDown();
        }

        private void qlDarkestFirst_Click(object sender, RoutedEventArgs e)
        {
            txtCT1.Text = getHexForRectangle(recCGDarkest);
        }

        private void qlDarkestSecond_Click(object sender, RoutedEventArgs e)
        {
            txtCT2.Text = getHexForRectangle(recCGDarkest);
        }

        private void qlDarkestThird_Click(object sender, RoutedEventArgs e)
        {
            txtCT3.Text = getHexForRectangle(recCGDarkest);
        }

        private void qlDarkestFourth_Click(object sender, RoutedEventArgs e)
        {
            txtCT4.Text = getHexForRectangle(recCGDarkest);
        }

        private void qlDarkestFifth_Click(object sender, RoutedEventArgs e)
        {
            txtCT5.Text = getHexForRectangle(recCGDarkest);
        }

        private void qlDarkerFirst_Click(object sender, RoutedEventArgs e)
        {
            txtCT1.Text = getHexForRectangle(recCGDarker);
        }

        private void qlDarkerSecond_Click(object sender, RoutedEventArgs e)
        {
            txtCT2.Text = getHexForRectangle(recCGDarker);
        }

        private void qlDarkerThird_Click(object sender, RoutedEventArgs e)
        {
            txtCT3.Text = getHexForRectangle(recCGDarker);
        }

        private void qlDarkerFourth_Click(object sender, RoutedEventArgs e)
        {
            txtCT4.Text = getHexForRectangle(recCGDarker);
        }

        private void qlDarkerFifth_Click(object sender, RoutedEventArgs e)
        {
            txtCT5.Text = getHexForRectangle(recCGDarker);
        }

        private void qlDarkFirst_Click(object sender, RoutedEventArgs e)
        {
            txtCT1.Text = getHexForRectangle(recCGDark);
        }

        private void qlDarkSecond_Click(object sender, RoutedEventArgs e)
        {
            txtCT2.Text = getHexForRectangle(recCGDark);
        }

        private void qlDarkThird_Click(object sender, RoutedEventArgs e)
        {
            txtCT3.Text = getHexForRectangle(recCGDark);
        }

        private void qlDarkFourth_Click(object sender, RoutedEventArgs e)
        {
            txtCT4.Text = getHexForRectangle(recCGDark);
        }

        private void qlDarkFifth_Click(object sender, RoutedEventArgs e)
        {
            txtCT5.Text = getHexForRectangle(recCGDark);
        }

        private void qlNormalFirst_Click(object sender, RoutedEventArgs e)
        {
            txtCT1.Text = getHexForRectangle(recCGColour);
        }

        private void qlNormalSecond_Click(object sender, RoutedEventArgs e)
        {
            txtCT2.Text = getHexForRectangle(recCGColour);
        }

        private void qlNormalThird_Click(object sender, RoutedEventArgs e)
        {
            txtCT3.Text = getHexForRectangle(recCGColour);
        }

        private void qlNormalFourth_Click(object sender, RoutedEventArgs e)
        {
            txtCT4.Text = getHexForRectangle(recCGColour);
        }

        private void qlNormalFifth_Click(object sender, RoutedEventArgs e)
        {
            txtCT5.Text = getHexForRectangle(recCGColour);
        }

        private void qlBrightFirst_Click(object sender, RoutedEventArgs e)
        {
            txtCT1.Text = getHexForRectangle(recCGBright);
        }

        private void qlBrightSecond_Click(object sender, RoutedEventArgs e)
        {
            txtCT2.Text = getHexForRectangle(recCGBright);
        }

        private void qlBrightThird_Click(object sender, RoutedEventArgs e)
        {
            txtCT3.Text = getHexForRectangle(recCGBright);
        }

        private void qlBrightFourth_Click(object sender, RoutedEventArgs e)
        {
            txtCT4.Text = getHexForRectangle(recCGBright);
        }

        private void qlBrightFifth_Click(object sender, RoutedEventArgs e)
        {
            txtCT5.Text = getHexForRectangle(recCGBright);
        }

        private void qlBrighterFirst_Click(object sender, RoutedEventArgs e)
        {
            txtCT1.Text = getHexForRectangle(recCGBrighter);
        }

        private void qlBrighterSecond_Click(object sender, RoutedEventArgs e)
        {
            txtCT2.Text = getHexForRectangle(recCGBrighter);
        }

        private void qlBrighterThird_Click(object sender, RoutedEventArgs e)
        {
            txtCT3.Text = getHexForRectangle(recCGBrighter);
        }

        private void qlBrighterFourth_Click(object sender, RoutedEventArgs e)
        {
            txtCT4.Text = getHexForRectangle(recCGBrighter);
        }

        private void qlBrighterFifth_Click(object sender, RoutedEventArgs e)
        {
            txtCT5.Text = getHexForRectangle(recCGBrighter);
        }

        private void qlBrightestFirst_Click(object sender, RoutedEventArgs e)
        {
            txtCT1.Text = getHexForRectangle(recCGBrightest);
        }

        private void qlBrightestSecond_Click(object sender, RoutedEventArgs e)
        {
            txtCT2.Text = getHexForRectangle(recCGBrightest);
        }

        private void qlBrightestThird_Click(object sender, RoutedEventArgs e)
        {
            txtCT3.Text = getHexForRectangle(recCGBrightest);
        }

        private void qlBrightestFourth_Click(object sender, RoutedEventArgs e)
        {
            txtCT4.Text = getHexForRectangle(recCGBrightest);
        }

        private void qlBrightestFifth_Click(object sender, RoutedEventArgs e)
        {
            txtCT5.Text = getHexForRectangle(recCGBrightest);
        }

        private void txtCTScrollDown_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CTThemes.LineDown();
        }

        private void txtCTScrollUp_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CTThemes.LineUp();
        }

        /// <summary>
        /// Calculates the new colour of the colour wheel rectangle
        /// this takes in account of the black background
        /// </summary>
        /// <returns></returns>
        public Color calculateOpacity()
        {
            Color one = ((SolidColorBrush)recColour.Fill).Color;
            Color two = Colors.Black;

            double opacity = sldCWBrightness.Value / 100;

            byte finalRed = (byte)Math.Round(opacity * one.R + (1 - opacity) * two.R);
            byte finalGreen = (byte)Math.Round(opacity * one.G + (1 - opacity) * two.G);
            byte finalBlue = (byte)Math.Round(opacity * one.B + (1 - opacity) * two.B);

            return Color.FromRgb(finalRed,finalGreen,finalBlue);
        }
    }
}