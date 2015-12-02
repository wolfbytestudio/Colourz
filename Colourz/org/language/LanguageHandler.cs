using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Colourz.Org.language
{
    public class LanguageHandler
    {
        private MainWindow owner;

        public Language language;

        public LanguageHandler(MainWindow owner)
        {
            this.owner = owner;
        }

        public void updateLanguage()
        {
            if (language == Language.ENGLISH)
            {
                owner.lblColourGenerator.Text = "Colour Generator";
                owner.lblColourTheme.Text = "Colour Theme";
                owner.lblColourPicker.Text = "Colour Picker";
                owner.lblColourWheel.Text = "Colour Wheel";
                owner.lblSavedColours.Text = "Saved Colours";
                owner.lblSettings.Text = "Settings";
                owner.lblSTheme.Content = "Theme: ";
                owner.cmdThemeEditor.Content = "Theme Editor";
                owner.chbSAnimations.Content = " Disable side panel animations";
                owner.lblSSidePanelSColour.Content = "Side panel selected colour:";

                owner.cmdSelectAll.Content = "Select All";
                owner.cmdSCDeleteSelected.Content = "Delete Selected";
                owner.cmdDeselectAll.Content = "Deselect All";
                owner.cmdSCClear.Content = "Clear";
                owner.lblLanguages.Text = "Languages";
                owner.txtSSelectorColour.Margin = new System.Windows.Thickness(
                232, 84, 0, 0);
            }
            else if (language == Language.SPANISH)
            {
                owner.lblColourGenerator.Text = "Generador de Color";
                owner.lblColourTheme.Text = "Tema de Color";
                owner.lblColourPicker.Text = "Selector de Color";
                owner.lblColourWheel.Text = "Rueda de Color";
                owner.lblSavedColours.Text = "Colores Guardados";
                owner.lblSettings.Text = "Ajustes";
                owner.lblSTheme.Content = "Tema: ";
                owner.cmdThemeEditor.Content = "Editor de Temas"; 
                owner.chbSAnimations.Content = " Animaciones panel lateral Desactivar";
                owner.lblSSidePanelSColour.Content = "Panel lateral del color seleccionado:";
                owner.cmdSelectAll.Content = "Seleccionar Todo";
                owner.cmdSCDeleteSelected.Content = "Eliminar Seleccionado";
                owner.cmdDeselectAll.Content = "Deseleccionar Todos";
                owner.cmdSCClear.Content = "Claro";
                owner.lblLanguages.Text = "Idiomas";
                owner.txtSSelectorColour.Margin = new System.Windows.Thickness(
                    309, 84, 0, 0);
            }
        }
    }
}
