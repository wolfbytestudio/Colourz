﻿#pragma checksum "..\..\..\Controls\SavedColour.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6C7C03E037BC6952E6D4EE7330957E84"
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


namespace Colourz.Controls {
    
    
    /// <summary>
    /// SavedColour
    /// </summary>
    public partial class SavedColour : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\Controls\SavedColour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdBackground;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\Controls\SavedColour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblText;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Controls\SavedColour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menAll;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Controls\SavedColour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menRgb;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Controls\SavedColour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menHex;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Controls\SavedColour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menRemove;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Controls\SavedColour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem qlFirst;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Controls\SavedColour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem qlSecond;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Controls\SavedColour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem qlThird;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Controls\SavedColour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem qlFourth;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Controls\SavedColour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem qlFifth;
        
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
            System.Uri resourceLocater = new System.Uri("/Colourz;component/controls/savedcolour.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\SavedColour.xaml"
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
            this.grdBackground = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.lblText = ((System.Windows.Controls.TextBlock)(target));
            
            #line 8 "..\..\..\Controls\SavedColour.xaml"
            this.lblText.MouseEnter += new System.Windows.Input.MouseEventHandler(this.lblText_MouseEnter);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\Controls\SavedColour.xaml"
            this.lblText.MouseLeave += new System.Windows.Input.MouseEventHandler(this.lblText_MouseLeave);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\Controls\SavedColour.xaml"
            this.lblText.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.lblText_MouseUp);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\Controls\SavedColour.xaml"
            this.lblText.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.lblText_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.menAll = ((System.Windows.Controls.MenuItem)(target));
            
            #line 11 "..\..\..\Controls\SavedColour.xaml"
            this.menAll.Click += new System.Windows.RoutedEventHandler(this.menAll_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.menRgb = ((System.Windows.Controls.MenuItem)(target));
            
            #line 12 "..\..\..\Controls\SavedColour.xaml"
            this.menRgb.Click += new System.Windows.RoutedEventHandler(this.menRgb_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.menHex = ((System.Windows.Controls.MenuItem)(target));
            
            #line 13 "..\..\..\Controls\SavedColour.xaml"
            this.menHex.Click += new System.Windows.RoutedEventHandler(this.menHex_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.menRemove = ((System.Windows.Controls.MenuItem)(target));
            
            #line 14 "..\..\..\Controls\SavedColour.xaml"
            this.menRemove.Click += new System.Windows.RoutedEventHandler(this.menRemove_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.qlFirst = ((System.Windows.Controls.MenuItem)(target));
            
            #line 16 "..\..\..\Controls\SavedColour.xaml"
            this.qlFirst.Click += new System.Windows.RoutedEventHandler(this.qlFirst_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.qlSecond = ((System.Windows.Controls.MenuItem)(target));
            
            #line 17 "..\..\..\Controls\SavedColour.xaml"
            this.qlSecond.Click += new System.Windows.RoutedEventHandler(this.qlSecond_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.qlThird = ((System.Windows.Controls.MenuItem)(target));
            
            #line 18 "..\..\..\Controls\SavedColour.xaml"
            this.qlThird.Click += new System.Windows.RoutedEventHandler(this.qlThird_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.qlFourth = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\..\Controls\SavedColour.xaml"
            this.qlFourth.Click += new System.Windows.RoutedEventHandler(this.qlFourth_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.qlFifth = ((System.Windows.Controls.MenuItem)(target));
            
            #line 20 "..\..\..\Controls\SavedColour.xaml"
            this.qlFifth.Click += new System.Windows.RoutedEventHandler(this.qlFifth_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

