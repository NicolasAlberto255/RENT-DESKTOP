﻿#pragma checksum "..\..\..\..\Windows\AddServicioImagen.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AE336F1B24C66315F6145664F2998401167DDCD6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RENT.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace RENT.Windows {
    
    
    /// <summary>
    /// AddServicioImagen
    /// </summary>
    public partial class AddServicioImagen : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\Windows\AddServicioImagen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imagenSelected;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Windows\AddServicioImagen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GuardarBtn;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Windows\AddServicioImagen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox uplListImagenes;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Windows\AddServicioImagen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox imagenesListBox;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Windows\AddServicioImagen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idServicioTxt;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\Windows\AddServicioImagen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox serviciosListBox;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\..\..\Windows\AddServicioImagen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CargarBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RENT;component/windows/addservicioimagen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\AddServicioImagen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.imagenSelected = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.GuardarBtn = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\Windows\AddServicioImagen.xaml"
            this.GuardarBtn.Click += new System.Windows.RoutedEventHandler(this.GuardarBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.uplListImagenes = ((System.Windows.Controls.ListBox)(target));
            
            #line 57 "..\..\..\..\Windows\AddServicioImagen.xaml"
            this.uplListImagenes.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.uplListImagenes_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.imagenesListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.idServicioTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.serviciosListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 91 "..\..\..\..\Windows\AddServicioImagen.xaml"
            this.serviciosListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.serviciosListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 165 "..\..\..\..\Windows\AddServicioImagen.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).Drop += new System.Windows.DragEventHandler(this.Rectangle_Drop);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 177 "..\..\..\..\Windows\AddServicioImagen.xaml"
            ((System.Windows.Controls.StackPanel)(target)).Drop += new System.Windows.DragEventHandler(this.Rectangle_Drop);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CargarBtn = ((System.Windows.Controls.Button)(target));
            
            #line 198 "..\..\..\..\Windows\AddServicioImagen.xaml"
            this.CargarBtn.Click += new System.Windows.RoutedEventHandler(this.CargarBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
