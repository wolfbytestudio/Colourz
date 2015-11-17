﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Colourz.Controls
{
    public class SavedColourzSaver
    {

        private StackPanel stack;
        private object owner;

        public SavedColourzSaver(object owner, StackPanel stack)
        {
            this.owner = owner;
            this.stack = stack;
        }


        private static string userData = Environment.ExpandEnvironmentVariables("%AppData%");
        private static string cachePath = System.IO.Path.Combine(userData, ".colourz\\");
        private static string pathFile = cachePath + "Saved Colours.txt";

        /// <summary>
        /// Saves the colourz
        /// </summary>
        public void save()
        {
            if (!System.IO.Directory.Exists(cachePath))
            {
                System.IO.Directory.CreateDirectory(cachePath);
            }

            if (!System.IO.Directory.Exists(cachePath))
            {
                Console.WriteLine("Created directory");
                System.IO.Directory.CreateDirectory(cachePath);
            }

            System.IO.File.WriteAllBytes(cachePath  + "Saved Colours.txt", new byte[0]);
            System.IO.StreamWriter file = new System.IO.StreamWriter(cachePath + "Saved Colours.txt", true);
            
            string saveText = "";
            for(int i = 0; i < stack.Children.Count; i++)
            {
                SavedColour s = (SavedColour)stack.Children[i];

                if(i != stack.Children.Count)
                    saveText += s.hex + ";";
            }
            file.WriteLine(saveText);
            file.Flush();
            file.Close();
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
                Console.WriteLine(segment.Length);
                for (int i = 0; i < segment.Length - 1; i++)
                {

                    try
                    {
                        Color color = (Color)ColorConverter.ConvertFromString(segment[i]);

                        String hex = color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");

                        MainWindow o = (MainWindow)owner;

                        stack.Children.Add(new SavedColour(o,
                                stack, "" + color.R + ", " + color.G +
                                ", " + color.B + "", "#" + hex + ""));
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
