using Colourz.Controls.Custom_Theme.components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colourz.Controls.Custom_Theme
{
    public class Theme
    {

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private HoverableComponent sideText;
        public HoverableComponent SideText
        {
            get { return sideText; }
            set { sideText = value; }
        }

        private string rectangleSide;
        public string RectangleSide
        {
            get { return rectangleSide; }
            set { rectangleSide = value; }
        }

        private string rectangleTop;
        public string RectangleTop
        {
            get { return rectangleTop; }
            set { rectangleTop = value; }
        }

        private string background;
        public string Background
        {
            get { return background; }
            set { background = value; }
        }

        private string seperators;
        public string Seperators
        {
            get { return seperators; }
            set { seperators = value; }
        }

        private string tabSelector;
        public string TabSelector
        {
            get { return tabSelector; }
            set { tabSelector = value; }
        }

        private string scrollables;
        public string Scrollables
        {
            get { return scrollables; }
            set { scrollables = value; }
        }

        private string scrollersHover;
        public string ScrollersHover
        {
            get { return scrollersHover; }
            set { scrollersHover = value; }
        }

        private string sliderKnob;
        public string SliderKnob
        {
            get { return sliderKnob; }
            set { sliderKnob = value; }
        }

        private string sliderRight;
        public string SliderRight
        {
            get { return sliderRight; }
            set { sliderRight = value; }
        }

        public Theme( string name,
            string title, HoverableComponent sideText, string rectangleSide,
            string rectangleTop, string background, string seperators,
            string tabSelector, string scrollables, string scrollersHover,
            string sliderKnob, string sliderRight)
        {
            this.Name = name;
            this.Title = title;
            this.SideText = sideText;
            this.RectangleSide = rectangleSide;
            this.RectangleTop = rectangleTop;
            this.Background = background;
            this.Seperators = seperators;
            this.TabSelector = tabSelector;
            this.Scrollables = scrollables;
            this.ScrollersHover = scrollersHover;
            this.SliderKnob = sliderKnob;
            this.SliderRight = sliderRight;
        }
    }
}
