﻿#pragma checksum "..\..\WindowContainer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1740296E58D9E57058D00175345951A7"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34014
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using SimpTyper;
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
    /// WindowContainer
    /// </summary>
    public partial class WindowContainer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\WindowContainer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SimpTyper.WindowContainer Window_main;
        
        #line default
        #line hidden
        
        
        #line 303 "..\..\WindowContainer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid main_grid;
        
        #line default
        #line hidden
        
        
        #line 304 "..\..\WindowContainer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PART_ContentHostClearButton;
        
        #line default
        #line hidden
        
        
        #line 326 "..\..\WindowContainer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Maximize_button;
        
        #line default
        #line hidden
        
        
        #line 327 "..\..\WindowContainer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Minimize_button;
        
        #line default
        #line hidden
        
        
        #line 328 "..\..\WindowContainer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label artical_title;
        
        #line default
        #line hidden
        
        
        #line 338 "..\..\WindowContainer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Artical;
        
        #line default
        #line hidden
        
        
        #line 367 "..\..\WindowContainer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InputBox;
        
        #line default
        #line hidden
        
        
        #line 368 "..\..\WindowContainer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label words;
        
        #line default
        #line hidden
        
        
        #line 369 "..\..\WindowContainer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label timer_label;
        
        #line default
        #line hidden
        
        
        #line 387 "..\..\WindowContainer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label type_speed;
        
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
            System.Uri resourceLocater = new System.Uri("/SimpTyper;component/windowcontainer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowContainer.xaml"
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
            this.Window_main = ((SimpTyper.WindowContainer)(target));
            
            #line 11 "..\..\WindowContainer.xaml"
            this.Window_main.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Window_main_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 13 "..\..\WindowContainer.xaml"
            this.Window_main.SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            
            #line 13 "..\..\WindowContainer.xaml"
            this.Window_main.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.main_grid = ((System.Windows.Controls.Grid)(target));
            
            #line 303 "..\..\WindowContainer.xaml"
            this.main_grid.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PART_ContentHostClearButton = ((System.Windows.Controls.Button)(target));
            
            #line 304 "..\..\WindowContainer.xaml"
            this.PART_ContentHostClearButton.Click += new System.Windows.RoutedEventHandler(this.Close_Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Maximize_button = ((System.Windows.Controls.Button)(target));
            
            #line 326 "..\..\WindowContainer.xaml"
            this.Maximize_button.Click += new System.Windows.RoutedEventHandler(this.Maximize_button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Minimize_button = ((System.Windows.Controls.Button)(target));
            
            #line 327 "..\..\WindowContainer.xaml"
            this.Minimize_button.Click += new System.Windows.RoutedEventHandler(this.Minimize_button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.artical_title = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Artical = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.InputBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 367 "..\..\WindowContainer.xaml"
            this.InputBox.Loaded += new System.Windows.RoutedEventHandler(this.InputBox_Loaded);
            
            #line default
            #line hidden
            
            #line 367 "..\..\WindowContainer.xaml"
            this.InputBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.InputBox_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 367 "..\..\WindowContainer.xaml"
            this.InputBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.InputBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.words = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.timer_label = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.type_speed = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

