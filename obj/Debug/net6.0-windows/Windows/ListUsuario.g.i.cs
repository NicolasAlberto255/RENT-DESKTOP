#pragma checksum "..\..\..\..\Windows\ListUsuario.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "182F501C4438E6F66FF68968B6C2D933FBD0CA06"
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
    /// ListUsuario
    /// </summary>
    public partial class ListUsuario : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Windows\ListUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cargarUsuariobtn;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Windows\ListUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgUsuarios;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Windows\ListUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button idbtn;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Windows\ListUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idFindtxt;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Windows\ListUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nombrebtn;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Windows\ListUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nombreFindtxt;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Windows\ListUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button apellidobtn;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Windows\ListUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox apellidoFindtxt;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Windows\ListUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cedulabtn;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Windows\ListUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox cedulaFindtxt;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Windows\ListUsuario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMessage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RENT;component/windows/listusuario.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\ListUsuario.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cargarUsuariobtn = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\Windows\ListUsuario.xaml"
            this.cargarUsuariobtn.Click += new System.Windows.RoutedEventHandler(this.cargarUsuariobtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgUsuarios = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.idbtn = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Windows\ListUsuario.xaml"
            this.idbtn.Click += new System.Windows.RoutedEventHandler(this.idbtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.idFindtxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.nombrebtn = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\Windows\ListUsuario.xaml"
            this.nombrebtn.Click += new System.Windows.RoutedEventHandler(this.nombrebtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.nombreFindtxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.apellidobtn = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\Windows\ListUsuario.xaml"
            this.apellidobtn.Click += new System.Windows.RoutedEventHandler(this.apellidobtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.apellidoFindtxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.cedulabtn = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\Windows\ListUsuario.xaml"
            this.cedulabtn.Click += new System.Windows.RoutedEventHandler(this.cedulabtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.cedulaFindtxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.lblMessage = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

