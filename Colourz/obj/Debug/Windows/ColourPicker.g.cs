﻿#pragma checksum "..\..\..\Windows\ColourPicker.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "023F4AB87E6A32D5B215DB8F0FDAB7D9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Colourz.window {
    
    
    /// <summary>
    /// ColourPicker
    /// </summary>
    public partial class ColourPicker : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\Windows\ColourPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle recBackboard;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\Windows\ColourPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle recColour;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\Windows\ColourPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblBlock;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Colourz;component/windows/colourpicker.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\ColourPicker.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\..\Windows\ColourPicker.xaml"
            ((Colourz.window.ColourPicker)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            
            #line 4 "..\..\..\Windows\ColourPicker.xaml"
            ((Colourz.window.ColourPicker)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            
            #line 4 "..\..\..\Windows\ColourPicker.xaml"
            ((Colourz.window.ColourPicker)(target)).GotFocus += new System.Windows.RoutedEventHandler(this.Window_GotFocus);
            
            #line default
            #line hidden
            
            #line 4 "..\..\..\Windows\ColourPicker.xaml"
            ((Colourz.window.ColourPicker)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.Window_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.recBackboard = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 6 "..\..\..\Windows\ColourPicker.xaml"
            this.recBackboard.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.recBackboard_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.recColour = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 7 "..\..\..\Windows\ColourPicker.xaml"
            this.recColour.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.recColour_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblBlock = ((System.Windows.Controls.TextBlock)(target));
            
            #line 8 "..\..\..\Windows\ColourPicker.xaml"
            this.lblBlock.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TextBlock_MouseDown);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\Windows\ColourPicker.xaml"
            this.lblBlock.KeyDown += new System.Windows.Input.KeyEventHandler(this.lblBlock_KeyDown);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\Windows\ColourPicker.xaml"
            this.lblBlock.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.lblBlock_MouseUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

