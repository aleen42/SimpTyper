﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "690831C55B63388C3B81D1E99DC21A97"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34014
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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


namespace SimpTyper {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SimpTyper.MainWindow Window_main;
        
        #line default
        #line hidden
        
        
        #line 917 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PART_ContentHostClearButton;
        
        #line default
        #line hidden
        
        
        #line 939 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Maximize_button;
        
        #line default
        #line hidden
        
        
        #line 940 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Minimize_button;
        
        #line default
        #line hidden
        
        
        #line 943 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LeftPart;
        
        #line default
        #line hidden
        
        
        #line 946 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Addbutton;
        
        #line default
        #line hidden
        
        
        #line 947 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ListBox_Grid;
        
        #line default
        #line hidden
        
        
        #line 951 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Innergrid;
        
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
            System.Uri resourceLocater = new System.Uri("/SimpTyper;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.Window_main = ((SimpTyper.MainWindow)(target));
            
            #line 11 "..\..\MainWindow.xaml"
            this.Window_main.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Window_main_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 13 "..\..\MainWindow.xaml"
            this.Window_main.Loaded += new System.Windows.RoutedEventHandler(this.Window_main_Loaded);
            
            #line default
            #line hidden
            
            #line 14 "..\..\MainWindow.xaml"
            this.Window_main.SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            
            #line 14 "..\..\MainWindow.xaml"
            this.Window_main.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 908 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridSplitter)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.GridSplitter_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PART_ContentHostClearButton = ((System.Windows.Controls.Button)(target));
            
            #line 917 "..\..\MainWindow.xaml"
            this.PART_ContentHostClearButton.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Maximize_button = ((System.Windows.Controls.Button)(target));
            
            #line 939 "..\..\MainWindow.xaml"
            this.Maximize_button.Click += new System.Windows.RoutedEventHandler(this.Maximize_button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Minimize_button = ((System.Windows.Controls.Button)(target));
            
            #line 940 "..\..\MainWindow.xaml"
            this.Minimize_button.Click += new System.Windows.RoutedEventHandler(this.Minimize_button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LeftPart = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            
            #line 944 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).Loaded += new System.Windows.RoutedEventHandler(this.TextBox_Loaded);
            
            #line default
            #line hidden
            
            #line 944 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterArticals_TextChanged);
            
            #line default
            #line hidden
            
            #line 944 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).GotFocus += new System.Windows.RoutedEventHandler(this.FilterArticals_GotFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Addbutton = ((System.Windows.Controls.Button)(target));
            
            #line 946 "..\..\MainWindow.xaml"
            this.Addbutton.Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ListBox_Grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            
            #line 950 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.AddTitle_grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Innergrid = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

