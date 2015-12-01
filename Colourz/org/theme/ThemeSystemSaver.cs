using Colourz.org;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colourz.Controls.Custom_Theme
{
    public class ThemeSystemSaver
    {

        ThemeSystem owner;

        public ThemeSystemSaver(ThemeSystem owner)
        {
            this.owner = owner;
        }

        public void save()
        {
            if (!System.IO.Directory.Exists(Constants.CACHE_PATH))
            {
                System.IO.Directory.CreateDirectory(Constants.CACHE_PATH);
            }
            System.IO.File.WriteAllBytes(Constants.CACHE_PATH + "Themes.txt", new byte[0]);
            System.IO.StreamWriter file = new System.IO.StreamWriter(Constants.CACHE_PATH + "Themes.txt", true);

            string saveText = "";
            int count = 0;
            foreach(Theme t in owner.themes)
            {
                if(count == 0 || count == 1)
                {
                    count++;
                }
                else
                {
                    saveText += t.Name + ":";
                    saveText += t.Title + ":";
                    saveText += t.SideText.DefaultText + ":";
                    saveText += t.SideText.HoverText + ":";
                    saveText += t.RectangleSide + ":";
                    saveText += t.RectangleTop + ":";
                    saveText += t.Background + ":";
                    saveText += t.Seperators + ":";
                    saveText += t.TabSelector + ":";
                    saveText += t.Scrollables + ":";
                    saveText += t.ScrollersHover + ":";
                    saveText += t.SliderKnob + ":";
                    saveText += t.SliderRight + ":";
                    saveText += ";";
                }
            }

            file.WriteLine(saveText);
            file.Flush();
            file.Close();
        }
    }
}
