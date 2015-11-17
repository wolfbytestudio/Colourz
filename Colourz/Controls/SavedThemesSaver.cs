using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Colourz.Controls
{
    public class SavedThemesSaver
    {

        private Object page;
        private StackPanel owner;

        public SavedThemesSaver(Object page, StackPanel owner)
        {
            this.page = page;
            this.owner = owner;
        }

        private static string userData = Environment.ExpandEnvironmentVariables("%AppData%");
        private static string cachePath = System.IO.Path.Combine(userData, ".colourz\\");
        private static string pathFile = cachePath + "Saved Themes.txt";

        /// <summary>
        /// Saves the colourz
        /// </summary>
        public void save()
        {


            if (!System.IO.Directory.Exists(pathFile))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(pathFile);
                }
                catch
                {

                }
                
            }

            System.IO.File.WriteAllBytes(pathFile, new byte[0]);
            System.IO.StreamWriter file = new System.IO.StreamWriter(pathFile, true);

            string saveText = "";
            for (int i = 0; i < owner.Children.Count; i++)
            {
                ColourTheme s = (ColourTheme)owner.Children[i];

                saveText += s.name + ":"
                    + getHex(s.colours[0])
                    + ":" + getHex(s.colours[1])
                    + ":" + getHex(s.colours[2])
                    + ":" + getHex(s.colours[3])
                    + ":" + getHex(s.colours[4]) + ";";
            }
            file.WriteLine(saveText);
            file.Flush();
            file.Close();
        }

        public string getHex(Color c)
        {
            Color rgb1 = c;
            string hex1 = rgb1.R.ToString("X2") + rgb1.G.ToString("X2") + rgb1.B.ToString("X2");
            return hex1;
        }

        /// <summary>
        /// Loads the colourz saved
        /// </summary>
        public void load()
        {
            if (!System.IO.Directory.Exists(cachePath))
            {
                System.IO.Directory.CreateDirectory(cachePath);
            }
            if (!System.IO.File.Exists(pathFile))
            {
                System.IO.File.Create(pathFile);
            }
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(pathFile);
                string text = file.ReadLine();

                string[] segment = text.Split(';');

                for (int i = 0; i < segment.Length - 1; i++)
                {
                    string[] innerSeg = segment[i].Split(':');
                    string name = innerSeg[0];
                    Console.WriteLine();
                    Color col1 = (Color)ColorConverter.ConvertFromString("#" + innerSeg[1]);
                    Color col2 = (Color)ColorConverter.ConvertFromString("#" + innerSeg[2]);
                    Color col3 = (Color)ColorConverter.ConvertFromString("#" + innerSeg[3]);
                    Color col4 = (Color)ColorConverter.ConvertFromString("#" + innerSeg[4]);
                    Color col5 = (Color)ColorConverter.ConvertFromString("#" + innerSeg[5]);

                    ColourTheme theme = new ColourTheme(page, owner, name, col1, col2, col3, col4, col5);
                    theme.updateTheme();
                    MainWindow a = (MainWindow)page;

                    a.CTThemes.Children.Insert(0, theme);
                }
            }
            catch
            {

            }
        }
    }
}
