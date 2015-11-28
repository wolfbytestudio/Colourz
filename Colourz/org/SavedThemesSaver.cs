﻿using Colourz.org;
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
        

        /// <summary>
        /// Saves the colourz
        /// </summary>
        public void save()
        {
            if (!System.IO.Directory.Exists(Constants.CACHE_PATH))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(Constants.CACHE_PATH);
                }
                catch
                {

                }
                
            }

            System.IO.File.WriteAllBytes(Constants.CACHE_PATH, new byte[0]);
            System.IO.StreamWriter file = new System.IO.StreamWriter(Constants.CACHE_PATH, true);

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
            Color colour = c;

            string hex = colour.R.ToString("X2") 
                + colour.G.ToString("X2") 
                + colour.B.ToString("X2");

            return hex;
        }

        private static string pathFile = Constants.CACHE_PATH + "Saved Colours.txt";

        /// <summary>
        /// Loads the colourz saved
        /// </summary>
        public void load()
        {
            if (!System.IO.Directory.Exists(Constants.CACHE_PATH))
            {
                System.IO.Directory.CreateDirectory(Constants.CACHE_PATH);
            }
            if (!System.IO.File.Exists(pathFile))
            {
                System.IO.File.Create(pathFile);
            }
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(Constants.CACHE_PATH);
                string text = file.ReadLine();

                string[] segment = text.Split(';');

                for (int i = 0; i < segment.Length - 1; i++)
                {
                    try
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
                    catch
                    {

                    }
                   

                   
                }
            }
            catch
            {

            }
        }
    }
}
