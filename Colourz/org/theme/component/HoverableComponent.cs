using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colourz.Controls.Custom_Theme.components
{
    public class HoverableComponent
    {

        private string defaultText;
        public string DefaultText
        {
            get { return defaultText; }
            set { defaultText = value; }
        }

        private string hoverText;
        public string HoverText
        {
            get { return hoverText; }
            set { hoverText = value; }
        }

        public HoverableComponent(string defaultText, string hoverText)
        {
            DefaultText = defaultText;
            HoverText = hoverText;
            Console.WriteLine("initilised");
        }
    }
}
