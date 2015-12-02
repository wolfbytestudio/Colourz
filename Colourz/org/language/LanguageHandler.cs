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

                owner.lblCWSave1.Text = "F5 to save this colour";
                owner.lblCWSave1.FontSize = 18;
                owner.lblCWSave2.Text = "F6 to save this colour";
                owner.lblCWSave2.FontSize = 18;
                owner.lblCWSave3.Text = "F4 to save this colour";
                owner.lblCWSave3.FontSize = 18;
                owner.cmdCGSaveColour.Content = "Save Colour (F5)";
                owner.cmdCGReset.Content = "Reset";

                owner.cgNormal.Header = "Save Colour";
                owner.cgDarkSave.Header = "Save Colour";
                owner.cgDarkerSave.Header = "Save Colour";
                owner.cgDarkestSave.Header = "Save Colour";
                owner.cgLightMenu.Header = "Save Colour";
                owner.cgBrighter.Header = "Save Colour";
                owner.cgLightest.Header = "Save Colour";

                owner.cgNormalHex.Header = "Copy HEX to Clipboard";
                owner.cgDarkHex.Header = "Copy HEX to Clipboard";
                owner.cgDarkerHex.Header = "Copy HEX to Clipboard";
                owner.cgDarkestHex.Header = "Copy HEX to Clipboard";
                owner.cgBrightHex.Header = "Copy HEX to Clipboard";
                owner.cgBrighterHex.Header = "Copy HEX to Clipboard";
                owner.cgBrightestHex.Header = "Copy HEX to Clipboard";

                owner.cgNormalRGB.Header = "Copy RGB to Clipboard";
                owner.cgBrightRGB.Header = "Copy RGB to Clipboard";
                owner.cgBrighterRGB.Header = "Copy RGB to Clipboard";
                owner.cgBrightestRGB.Header = "Copy RGB to Clipboard";
                owner.cgDarkRGB.Header = "Copy RGB to Clipboard";
                owner.cgDarkerRGB.Header = "Copy RGB to Clipboard";
                owner.cgDarkestRGB.Header = "Copy RGB to Clipboard";

                owner.cgNormalQL.Header = "Quick load";
                owner.cgBrightQL.Header = "Quick load";
                owner.cgBrighterQL.Header = "Quick load";
                owner.cgBrightestQL.Header = "Quick load";
                owner.cgDarkQL.Header = "Quick load";
                owner.cgDarkerQL.Header = "Quick load";
                owner.cgDarkestQL.Header = "Quick load";

                owner.qlNormalFirst.Header = "First theme colour";
                owner.qlDarkFirst.Header = "First theme colour";
                owner.qlDarkerFirst.Header = "First theme colour";
                owner.qlDarkestFirst.Header = "First theme colour";
                owner.qlBrightFirst.Header = "First theme colour";
                owner.qlBrighterFirst.Header = "First theme colour";
                owner.qlBrightestFirst.Header = "First theme colour";

                owner.qlNormalSecond.Header = "Second theme colour";
                owner.qlDarkSecond.Header = "Second theme colour";
                owner.qlDarkerSecond.Header = "Second theme colour";
                owner.qlDarkestSecond.Header = "Second theme colour";
                owner.qlBrightSecond.Header = "Second theme colour";
                owner.qlBrighterSecond.Header = "Second theme colour";
                owner.qlBrightestSecond.Header = "Second theme colour";

                owner.qlNormalThird.Header = "Third theme colour";
                owner.qlDarkThird.Header = "Third theme colour";
                owner.qlDarkerThird.Header = "Third theme colour";
                owner.qlDarkestThird.Header = "Third theme colour";
                owner.qlBrightThird.Header = "Third theme colour";
                owner.qlBrighterThird.Header = "Third theme colour";
                owner.qlBrightestThird.Header = "Third theme colour";

                owner.qlNormalFourth.Header = "Fourth theme colour";
                owner.qlDarkFourth.Header = "Fourth theme colour";
                owner.qlDarkerFourth.Header = "Fourth theme colour";
                owner.qlDarkestFourth.Header = "Fourth theme colour";
                owner.qlBrightFourth.Header = "Fourth theme colour";
                owner.qlBrighterFourth.Header = "Fourth theme colour";
                owner.qlBrightestFourth.Header = "Fourth theme colour";

                owner.qlNormalFifth.Header = "Fifth theme colour";
                owner.qlDarkFifth.Header = "Fifth theme colour";
                owner.qlDarkerFifth.Header = "Fifth theme colour";
                owner.qlDarkestFifth.Header = "Fifth theme colour";
                owner.qlBrightFifth.Header = "Fifth theme colour";
                owner.qlBrighterFifth.Header = "Fifth theme colour";
                owner.qlBrightestFifth.Header = "Fifth theme colour";

                owner.cmdColourPickerStart.Content = "Start colour picker";

                owner.cmdCTClear.Content = "Clear Themes";
                owner.cmdSaveTheme.Content = "Save Theme";

                owner.cmdCTReset.Content = "Reset";

            }
            else if (language == Language.SPANISH)
            {

                owner.cmdCTReset.Content = "Reiniciar";

                owner.cmdSaveTheme.Content = "Guardar Tema";
                owner.cmdCTClear.Content = "Borrar Temas";

                owner.cmdColourPickerStart.Content = "Iniciar selector de color";

                owner.qlNormalFifth.Header = "Quinto tema del color";
                owner.qlDarkFifth.Header = "Quinto tema del color";
                owner.qlDarkerFifth.Header = "Quinto tema del color";
                owner.qlDarkestFifth.Header = "Quinto tema del color";
                owner.qlBrightFifth.Header = "Quinto tema del color";
                owner.qlBrighterFifth.Header = "Quinto tema del color";
                owner.qlBrightestFifth.Header = "Quinto tema del color";

                owner.qlNormalFourth.Header = "Cuarto tema de color";
                owner.qlDarkFourth.Header = "Cuarto tema de color";
                owner.qlDarkerFourth.Header = "Cuarto tema de color";
                owner.qlDarkestFourth.Header = "Cuarto tema de color";
                owner.qlBrightFourth.Header = "Cuarto tema de color";
                owner.qlBrighterFourth.Header = "Cuarto tema de color";
                owner.qlBrightestFourth.Header = "Cuarto tema de color";

                owner.qlNormalThird.Header = "Tercer tema de color";
                owner.qlDarkThird.Header = "Tercer tema de color";
                owner.qlDarkerThird.Header = "Tercer tema de color";
                owner.qlDarkestThird.Header = "Tercer tema de color";
                owner.qlBrightThird.Header = "Tercer tema de color";
                owner.qlBrighterThird.Header = "Tercer tema de color";
                owner.qlBrightestThird.Header = "Tercer tema de color";

                owner.qlNormalSecond.Header = "Segundo color del tema";
                owner.qlDarkSecond.Header = "Segundo color del tema";
                owner.qlDarkerSecond.Header = "Segundo color del tema";
                owner.qlDarkestSecond.Header = "Segundo color del tema";
                owner.qlBrightSecond.Header = "Segundo color del tema";
                owner.qlBrighterSecond.Header = "Segundo color del tema";
                owner.qlBrightestSecond.Header = "Segundo color del tema";

                owner.qlNormalFirst.Header = "Primero color del tema";
                owner.qlDarkFirst.Header = "Primero color del tema";
                owner.qlDarkerFirst.Header = "Primero color del tema";
                owner.qlDarkestFirst.Header = "Primero color del tema";
                owner.qlBrightFirst.Header = "Primero color del tema";
                owner.qlBrighterFirst.Header = "Primero color del tema";
                owner.qlBrightestFirst.Header = "Primero color del tema";

                owner.cgNormalQL.Header = "Carga rápida";
                owner.cgBrightQL.Header = "Carga rápida";
                owner.cgBrighterQL.Header = "Carga rápida";
                owner.cgBrightestQL.Header = "Carga rápida";
                owner.cgDarkQL.Header = "Carga rápida";
                owner.cgDarkerQL.Header = "Carga rápida";
                owner.cgDarkestQL.Header = "Carga rápida";


                owner.cgNormalRGB.Header = "Copie al Portapapeles RGB";
                owner.cgBrightRGB.Header = "Copie al Portapapeles RGB";
                owner.cgBrighterRGB.Header = "Copie al Portapapeles RGB";
                owner.cgBrightestRGB.Header = "Copie al Portapapeles RGB";
                owner.cgDarkRGB.Header = "Copie al Portapapeles RGB";
                owner.cgDarkerRGB.Header = "Copie al Portapapeles RGB";
                owner.cgDarkestRGB.Header = "Copie al Portapapeles RGB";


                owner.cgNormalHex.Header = "Copiar al Portapapeles HEX";
                owner.cgDarkHex.Header = "Copiar al Portapapeles HEX";
                owner.cgDarkerHex.Header = "Copiar al Portapapeles HEX";
                owner.cgDarkestHex.Header = "Copiar al Portapapeles HEX";
                owner.cgBrightHex.Header = "Copiar al Portapapeles HEX";
                owner.cgBrighterHex.Header = "Copiar al Portapapeles HEX";
                owner.cgBrightestHex.Header = "Copiar al Portapapeles HEX";

                owner.cgNormal.Header = "Guardar Color";
                owner.cgDarkSave.Header = "Guardar Color";
                owner.cgDarkerSave.Header = "Guardar Color";
                owner.cgDarkestSave.Header = "Guardar Color";
                owner.cgLightMenu.Header = "Guardar Color";
                owner.cgBrighter.Header = "Guardar Color";
                owner.cgLightest.Header = "Guardar Color";

                owner.cmdCGReset.Content = "Reiniciar";
                owner.cmdCGSaveColour.Content = "Guardar Color (F5)";
                owner.lblCWSave1.Text = "F5 Pulse para guardar este color";
                owner.lblCWSave1.FontSize = 14;
                owner.lblCWSave2.Text = "F6 Pulse para guardar este color";
                owner.lblCWSave2.FontSize = 14;
                owner.lblCWSave3.Text = "F4 Pulse para guardar este color";
                owner.lblCWSave3.FontSize = 14;
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
