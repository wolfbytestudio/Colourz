using Colourz.Controls.Custom_Theme;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Colourz.Windows
{
    /// <summary>
    /// Interaction logic for ThemeEditor.xaml
    /// </summary>
    public partial class ThemeEditor : Window
    {

        MainWindow owner;
        public static bool windowShowing = false;

        public ThemeEditor(MainWindow owner)
        {
            InitializeComponent();
            this.owner = owner;
            windowShowing = true;
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 3);
        }

        private void lblTitle_MouseDown(object sender, MouseButtonEventArgs e)
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

        public void populate(List<Theme> themes)
        {
            cmdList.Items.Clear();
            for (int i = 0; i < themes.Count; i++ )
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = themes[i].Name;
                cmdList.Items.Add(item);
            }
            cmdList.SelectedIndex = 0;
        }

        public void loadTheme(Theme t)
        {
            txtName.Text = t.Name;
            txtTitleColour.Text = t.Title;
            txtTextColourDefault.Text = t.SideText.DefaultText;
            txtTextColourHover.Text = t.SideText.HoverText;
            txtLeftPanel.Text = t.RectangleSide;
            txtTitleBar.Text = t.RectangleTop;
            txtBackgroundColour.Text = t.Background;
            txtSeperatorColour.Text = t.Seperators;
            txtTab.Text = t.TabSelector;
            txtScrollables.Text = t.Scrollables;
            txtScrollablesHover.Text = t.ScrollersHover;
            txtSliderKnob.Text = t.SliderKnob;
            txtSliderRight.Text = t.SliderRight;
        }

        private void recTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void txtWolfbyte_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void imgWolfbyte_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void cmdMinimize_MouseEnter(object sender, MouseEventArgs e)
        {
            cmdMinimize.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/minimize_hover.png", UriKind.Relative));
        }

        private void cmdMinimize_MouseLeave(object sender, MouseEventArgs e)
        {
            cmdMinimize.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/minimize_normal.png", UriKind.Relative));
        }

        private void cmdMinimize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cmdMinimize.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/minimize_mouseDown.png", UriKind.Relative));
        }

        private void cmdMinimize_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            cmdMinimize.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/minimize_normal.png", UriKind.Relative));
        }

        private void cmdExit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cmdExit.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/exit_mouseDown.png", UriKind.Relative));
        }

        private void cmdExit_MouseEnter(object sender, MouseEventArgs e)
        {
            cmdExit.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/exit_hover.png", UriKind.Relative));
        }

        private void cmdExit_MouseLeave(object sender, MouseEventArgs e)
        {
            cmdExit.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/exit_normal.png", UriKind.Relative));
        }

        private void cmdExit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            cmdExit.Source = new BitmapImage(new Uri(@"/Colourz;component/resource/exit_normal.png", UriKind.Relative));
        }

        public Color getColourForHex(string hex)
        {
            Color col = (Color)ColorConverter.ConvertFromString(hex);
            return col;
        }

        private void setColour(TextBox hex, Rectangle targetPreview)
        {
            Color c = Color.FromRgb(0,0,0);
            try
            {
                c = getColourForHex(hex.Text);
                targetPreview.Fill = new SolidColorBrush(c);
            }
            catch
            {

            }
        }

        public SolidColorBrush getSCBForTextBox(TextBox hex)
        {
            try
            {
                SolidColorBrush brush;
                Color c = getColourForHex(hex.Text);
                brush = new SolidColorBrush(c);
                return brush;
            }
            catch
            {
                return new SolidColorBrush(Colors.Black);

            }


        }

        private void txtTitleColour_TextChanged(object sender, TextChangedEventArgs e)
        {
            setColour(txtTitleColour, recTitleColour);
            try
            {
                lblTitleCol.Foreground = getSCBForTextBox(txtTitleColour);
            }
            catch
            {

            }
        }

        private void txtTextColourDefault_TextChanged(object sender, TextChangedEventArgs e)
        {
            setColour(txtTextColourDefault, recTextColourDefault);
            try
            {
                lblTextNormalCol.Foreground = getSCBForTextBox(txtTextColourDefault);
            } catch { }
        }

        private void txtTextColourHover_TextChanged(object sender, TextChangedEventArgs e)
        {
            setColour(txtTextColourHover, recTextColourHover);
            try
            {
                lblTextColHover.Foreground = getSCBForTextBox(txtTextColourHover);
            } catch { }
        }

        private void txtLeftPanel_TextChanged(object sender, TextChangedEventArgs e)
        {
            setColour(txtLeftPanel, recLeftPanelColour);
            try
            {
                recTabPanelCol.Fill = getSCBForTextBox(txtLeftPanel);
            }
            catch { }
        }

        private void txtTitleBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            setColour(txtTitleBar, recTitleBarColour);
            try
            {
                recTitleBarCol.Fill = getSCBForTextBox(txtTitleBar);
            }
            catch { }
        }

        private void txtBackgroundColour_TextChanged(object sender, TextChangedEventArgs e)
        {
            setColour(txtBackgroundColour, recBackgroundColour);
            try
            {
                recBackgroundCol.Fill = getSCBForTextBox(txtBackgroundColour);
            }
            catch { }
        }

        private void txtSeperatorColour_TextChanged(object sender, TextChangedEventArgs e)
        {
            setColour(txtSeperatorColour, recSeperatorColour);
            try
            {
                recSeperatorCol.Fill = getSCBForTextBox(txtSeperatorColour);
                recSeperatorsCol.Fill = getSCBForTextBox(txtSeperatorColour);
            }
            catch { }
        }

        private void txtTab_TextChanged(object sender, TextChangedEventArgs e)
        {
            setColour(txtTab, recTab);
            try
            {
                recTabSelectedCol.Fill = getSCBForTextBox(txtTab);
            }
            catch { }
        }

        private void txtScrollables_TextChanged(object sender, TextChangedEventArgs e)
        {
            setColour(txtScrollables, recScrollables);
            try
            {
                recScrollablesCol.Fill = getSCBForTextBox(txtScrollables);
                recScrollableTwo.Background = getSCBForTextBox(txtScrollables);
            }
            catch { }
        }

        private void txtScrollablesHover_TextChanged(object sender, TextChangedEventArgs e)
        {
            setColour(txtScrollablesHover, recScrollablesHover);
            try
            {
                recScrollableHoverCol.Background = getSCBForTextBox(txtScrollablesHover);
            }
            catch { }
        }

        private void txtSliderKnob_TextChanged(object sender, TextChangedEventArgs e)
        {
            setColour(txtSliderKnob, recSliderKnob);
            try
            {
                recSldKnob.Fill = getSCBForTextBox(txtSliderKnob);
            }
            catch { }
        }

        private void txtSliderRight_TextChanged(object sender, TextChangedEventArgs e)
        {
            setColour(txtSliderRight, recSliderRight);
            try
            {
                recRightSide.Fill = getSCBForTextBox(txtSliderRight);
            }
            catch { }
        }

        private void resetStroke()
        {
            recBackgroundCol.Stroke = new SolidColorBrush(Colors.Transparent);
            recRightSide.Stroke = new SolidColorBrush(Colors.Transparent);
            recValue.Stroke = new SolidColorBrush(Colors.Transparent);
            recSldKnob.Stroke = new SolidColorBrush(Colors.Transparent);
            recTitleBarCol.Stroke = new SolidColorBrush(Colors.Transparent);
            recTitleCol.Stroke = new SolidColorBrush(Colors.Transparent);
            recTabPanelCol.Stroke = new SolidColorBrush(Colors.Transparent);
            recTabSelectedCol.Stroke = new SolidColorBrush(Colors.Transparent);
            recSeperatorsCol.Stroke = new SolidColorBrush(Colors.Transparent);
            recScrollablesCol.Stroke = new SolidColorBrush(Colors.Transparent);
            recScrollablesTwoCol.Stroke = new SolidColorBrush(Colors.Transparent);
            recSeperatorCol.Stroke = new SolidColorBrush(Colors.Transparent);
            recNormalTextCol.Stroke = new SolidColorBrush(Colors.Transparent);
        }

        private void txtTitleColour_GotFocus(object sender, RoutedEventArgs e)
        {
            resetStroke();
            recTitleCol.Stroke = new SolidColorBrush(Colors.Magenta);
        }

       

        private void txtTextColourDefault_GotFocus(object sender, RoutedEventArgs e)
        {
            resetStroke();
            recNormalTextCol.Stroke = new SolidColorBrush(Colors.Magenta);
        }

        private void txtTextColourHover_GotFocus(object sender, RoutedEventArgs e)
        {
            resetStroke();
            recTabSelectedCol.Stroke = new SolidColorBrush(Colors.Magenta);
        }

        private void txtLeftPanel_GotFocus(object sender, RoutedEventArgs e)
        {
            resetStroke();
            recTabPanelCol.Stroke = new SolidColorBrush(Colors.Magenta);
        }

        private void txtTitleBar_GotFocus(object sender, RoutedEventArgs e)
        {
            resetStroke();
            recTitleBarCol.Stroke = new SolidColorBrush(Colors.Magenta);
        }

        private void txtBackgroundColour_GotFocus(object sender, RoutedEventArgs e)
        {
            resetStroke();
            recBackgroundCol.Stroke = new SolidColorBrush(Colors.Magenta);
        }

        private void txtSeperatorColour_GotFocus(object sender, RoutedEventArgs e)
        {
            resetStroke();
            recSeperatorsCol.Stroke = new SolidColorBrush(Colors.Magenta);
            recSeperatorCol.Stroke = new SolidColorBrush(Colors.Magenta);
        }

        private void txtTab_GotFocus(object sender, RoutedEventArgs e)
        {
            resetStroke();
            recTabSelectedCol.Stroke = new SolidColorBrush(Colors.Magenta);
        }

        private void txtScrollables_GotFocus(object sender, RoutedEventArgs e)
        {
            resetStroke();
            recScrollablesCol.Stroke = new SolidColorBrush(Colors.Magenta);
            
        }

        private void txtScrollablesHover_GotFocus(object sender, RoutedEventArgs e)
        {
            resetStroke();
            recScrollablesTwoCol.Stroke = new SolidColorBrush(Colors.Magenta);
        }

        private void txtSliderKnob_GotFocus(object sender, RoutedEventArgs e)
        {
            resetStroke();
            recSldKnob.Stroke = new SolidColorBrush(Colors.Magenta);
        }

        private void txtSliderRight_GotFocus(object sender, RoutedEventArgs e)
        {
            resetStroke();
            recRightSide.Stroke = new SolidColorBrush(Colors.Magenta);
        }


        /// <summary>
        /// A new time dispatcher
        /// </summary>
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();

        /// <summary>
        /// This handles the movement of the rectangle
        /// </summary>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lblAlert.Visibility = Visibility.Hidden;
            dispatcherTimer.Stop();
        }

        private void sendAlert(string alert)
        {
            lblAlert.Visibility = Visibility.Visible;
            lblAlert.Text = alert;
            dispatcherTimer.Start();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            sendAlert("Your theme has been saved!");
            owner.theme.addTheme(new Controls.Custom_Theme.Theme(
                txtName.Text, txtTitleColour.Text, 
                new Controls.Custom_Theme.components.HoverableComponent(
                    txtTextColourDefault.Text, txtTextColourHover.Text), txtLeftPanel.Text,
                txtTitleBar.Text, txtBackgroundColour.Text, txtSeperatorColour.Text, txtTab.Text, txtScrollables.Text,
                txtScrollablesHover.Text, txtSliderKnob.Text, txtSliderRight.Text
                ));

            ComboBoxItem c = new ComboBoxItem();
            c.Content = txtName.Text;

            Dispatcher.BeginInvoke(
            new Action(() =>
            {

                owner.cmbTheme.Items.Add(c);
            }));

            populate(owner.theme.themes);

            owner.theme.saveThemes();

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            string themeName = cmdList.Text;
            loadTheme(owner.theme.getThemeByName(themeName));
        }

        private void frmEditor_Closed(object sender, EventArgs e)
        {
            windowShowing = false;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (cmdList.SelectedIndex == 0 || cmdList.SelectedIndex == 1)
            {
                sendAlert("You cannot delete default themes!");
                return;
            }
            if (owner.cmbTheme.SelectedIndex == cmdList.SelectedIndex)
            {
                sendAlert("Theme Currently in use!");
                return;
            }
            else
            {
                ComboBoxItem selected = (ComboBoxItem)cmdList.Items[cmdList.SelectedIndex];
                Theme toDelete = owner.theme.getThemeByName(selected.Content.ToString());
                sendAlert("\'" + toDelete.Name + "\' has been deleted!");
                owner.theme.themes.Remove(toDelete);
                this.populate(owner.theme.themes);
                owner.populateThemeList();
                owner.cmbTheme.SelectedIndex = 0;
            }
            owner.theme.saveThemes();
        }

        private void btnImportTheme_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Enter your code (should look something like: 'Dark Theme:#FFFFFF:#A6A.....')", "Import Theme", "Default", -1, -1);
                string[] segments = input.Split(':');

                txtName.Text = segments[0];
                txtTitleColour.Text = segments[1];
                txtTextColourDefault.Text = segments[2];
                txtTextColourHover.Text = segments[3];
                txtLeftPanel.Text = segments[4];
                txtTitleBar.Text = segments[5];
                txtBackgroundColour.Text = segments[6];
                txtSeperatorColour.Text = segments[7];
                txtTab.Text = segments[8];
                txtScrollables.Text = segments[9];
                txtScrollablesHover.Text = segments[10];
                txtSliderKnob.Text = segments[11];
                txtSliderRight.Text = segments[12];
            }
            catch
            {
                sendAlert("Error importing theme!");
            }
           
        }

        private void btnExportTheme_Click(object sender, RoutedEventArgs e)
        {
            string text;
            text = 
                txtName.Text + ":" +
                txtTitleColour.Text + ":" +
                txtTextColourDefault.Text + ":" +
                txtTextColourHover.Text + ":" +
                txtLeftPanel.Text + ":" +
                txtTitleBar.Text + ":" +
                txtBackgroundColour.Text + ":" +
                txtSeperatorColour.Text + ":" +
                txtTab.Text + ":" +
                txtScrollables.Text + ":" +
                txtScrollablesHover.Text + ":" +
                txtSliderKnob.Text + ":" +
                txtSliderRight.Text + ":";

            try
            {
                Clipboard.SetText(text);
                sendAlert("Theme has been copied to your clipboard");
            }
            catch
            {
                sendAlert("Error exporting theme");
            }
            
        }
    }
}
