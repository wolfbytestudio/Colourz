using Colourz.Controls.Custom_Theme.components;
using Colourz.org;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colourz.Controls.Custom_Theme
{
    public class ThemeSystem
    {

        public static string fileName = Constants.CACHE_PATH + "Themes.txt";

        public List<Theme> themes = new List<Theme>();

        public Theme currentTheme;

        public ThemeSystem()
        {
            try
            {
                if (!System.IO.Directory.Exists(Constants.CACHE_PATH))
                {
                    System.IO.Directory.CreateDirectory(Constants.CACHE_PATH);
                }

                if (!System.IO.File.Exists(fileName))
                {
                    System.IO.File.Create(fileName);
                }
            }
            catch { }

            loadDefaultThemes();

            currentTheme = getThemeByName("dark");
            
        }

        public void loadDefaultThemes()
        {
            HoverableComponent dark = new HoverableComponent("#A6A7AA", "#EEEFF2");

            themes.Add(new Theme(
                "Dark", "#FFFFFF", dark,
                "#1E2024", "#1E2024", "#0A0B0D", "#0F0F0F", "#282A2E", "#050506", "#0F1013",
                "#F0F2F5", "#2D2E30"));

            HoverableComponent light = new HoverableComponent("#6E7074", "#1E2024");
            themes.Add(new Theme(
                "Light", "#000000", light,
                "#E6E8EC", "#E6E8EC", "#BEBFC1", "#D3D3D4", "#D2D3D7", "#A5A6A8", "#7D7E80",
                "#16181E", "#96979B"));
            
        }

        public Theme getThemeByName(string name)
        {
            name = name.ToLower();
            foreach(Theme t in themes)
            {
                string newName = t.Name.ToLower();
                if(newName.Equals(name))
                {
                    Console.WriteLine("found theme");
                    return t;
                }
            }
            return null;
        }

        public void addTheme(Theme theme)
        {
            string newName = theme.Name.ToLower();

            if(newName == "dark" || newName == "light")
            {
                return;
            }
            themes.Add(theme);
        }

    }
}
