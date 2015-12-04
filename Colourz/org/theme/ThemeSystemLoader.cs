using Colourz.org;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Colourz.Controls.Custom_Theme
{
    public class ThemeSystemLoader
    {

        ThemeSystem owner;
        private static string pathFile = Constants.CACHE_PATH + "Themes.txt";

        public ThemeSystemLoader(ThemeSystem owner)
        {
            this.owner = owner;
        }

        public void load()
        {
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(pathFile);
                string text = file.ReadLine();

                string[] segment = text.Split(';');
                Console.WriteLine(segment.Length);
                for (int i = 0; i < segment.Length - 1; i++)
                {
                    string[] parts = segment[i].Split(':');

                    owner.themes.Add(new Theme(parts[0], parts[1],
                        new components.HoverableComponent(parts[2], parts[3]),
                        parts[4], parts[5], parts[6], parts[7], parts[8], parts[9], parts[10], parts[11], parts[12]));

                }
            }
            catch
            {
            }
        }


    }
}
