﻿#pragma checksum "..\..\..\..\Windows\ListUsuarios.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7488814C3D4688282965E92D88029041B3B858C0"
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
    /// ListUsuarios
    /// </summary>
    public partial class ListUsuarios : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\Windows\ListUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgUsuarios;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Windows\ListUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button idBtn;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Windows\ListUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cedulabtn;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Windows\ListUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMessage;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Windows\ListUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox cedulaFindTxt;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\..\Windows\ListUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idFindTxt;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\Windows\ListUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cargarUsuariobtn;
        
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
            System.Uri resourceLocater = new System.Uri("/RENT;component/windows/listusuarios.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\ListUsuarios.xaml"
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
            this.dgUsuarios = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.idBtn = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\Windows\ListUsuarios.xaml"
            this.idBtn.Click += new System.Windows.RoutedEventHandler(this.idBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cedulabtn = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\..\Windows\ListUsuarios.xaml"
            this.cedulabtn.Click += new System.Windows.RoutedEventHandler(this.cedulaBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblMessage = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.cedulaFindTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.idFindTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 107 "..\..\..\..\Windows\ListUsuarios.xaml"
            this.idFindTxt.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ValidacionDeNumeros);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cargarUsuariobtn = ((System.Windows.Controls.Button)(target));
            
            #line 123 "..\..\..\..\Windows\ListUsuarios.xaml"
            this.cargarUsuariobtn.Click += new System.Windows.RoutedEventHandler(this.cargarUsuariobtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

