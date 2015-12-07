using Colourz.org;
using Colourz.Org.language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Colourz.Org
{
    public class Settings
    {

        private MainWindow owner;
        private static string pathFile = Constants.CACHE_PATH + "Settings.txt";


        public Settings(MainWindow owner)
        {
            this.owner = owner;
        }


        public void load()
        {
            check();

            System.IO.StreamReader file = new System.IO.StreamReader(pathFile, true);

            string line;

            while ((line = file.ReadLine()) != null)
            {
               if(line.StartsWith("lan: "))
               {
                   string lan = line.Split(' ')[1];
                   try
                   {
                       owner.lngHandler.language = (Language)Enum.Parse(typeof(Language), lan, true);
                       owner.lngHandler.updateLanguage();
                   }
                   catch
                   {
                       owner.lngHandler.language = Language.ENGLISH;
                       owner.lngHandler.updateLanguage();
                   }

               }

               if (line.StartsWith("themeindex: "))
               {
                   string seg = line.Split(' ')[1];

                   try
                   {
                       owner.cmbTheme.SelectedIndex = int.Parse(seg);
                   }
                   catch
                   {
                       owner.cmbTheme.SelectedIndex = 0;
                   }
               }

               if (line.StartsWith("disablesideanimation: "))
               {
                   string seg = line.Split(' ')[1];

                   try
                   {
                       owner.chbSAnimations.IsChecked = bool.Parse(seg);
                   }
                   catch
                   {
                       owner.chbSAnimations.IsChecked = false;
                   }
               }

               if (line.StartsWith("sidepanelcolour: "))
               {
                   string seg = line.Split(' ')[1];

                   try
                   {
                       owner.txtSSelectorColour.Text = seg;
                   }
                   catch
                   {
                       owner.txtSSelectorColour.Text = "2163E6";
                   }
               }

               if (line.StartsWith("colourgen: "))
               {
                   string seg = line.Split(' ')[1];

                   try
                   {
                       owner.txtCGHex.Text = seg;
                       owner.updateColourTextBoxes();
                   }
                   catch
                   {
                       owner.txtCGHex.Text = "#000000";
                   }
               }
            }

        }

        public void save()
        {
            check();

            System.IO.File.WriteAllBytes(pathFile, new byte[0]);
            System.IO.StreamWriter file = new System.IO.StreamWriter(pathFile, true);

            file.WriteLine("lan: " + owner.lngHandler.language.ToString().ToUpper());
            file.WriteLine("themeindex: " + owner.cmbTheme.SelectedIndex);
            file.WriteLine("disablesideanimation: " + owner.chbSAnimations.IsChecked);
            file.WriteLine("sidepanelcolour: " + owner.txtSSelectorColour.Text);
            file.WriteLine("colourgen: " + owner.txtCGHex.Text);

            file.Flush();
            file.Close();
        }

        /// <summary>
        /// Checks if the directory and file exists
        /// </summary>
        public void check()
        {
            if (!System.IO.Directory.Exists(Constants.CACHE_PATH))
            {
                System.IO.Directory.CreateDirectory(Constants.CACHE_PATH);
            }
            if (!System.IO.File.Exists(pathFile))
            {
                System.IO.File.Create(pathFile);
            }
        }


    }
}
