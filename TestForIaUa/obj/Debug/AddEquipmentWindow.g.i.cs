﻿#pragma checksum "..\..\AddEquipmentWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EE7BEC287F1375D0684B83C2740B7745649C68C4"
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
using TestForIaUa;


namespace TestForIaUa {
    
    
    /// <summary>
    /// AddEquipmentWindow
    /// </summary>
    public partial class AddEquipmentWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\AddEquipmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel mainStackPanel;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\AddEquipmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel secondStackPanel;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AddEquipmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelModel;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\AddEquipmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAddNewModel;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\AddEquipmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxModel;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\AddEquipmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\AddEquipmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxDescription;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\AddEquipmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAdd;
        
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
            System.Uri resourceLocater = new System.Uri("/TestForIaUa;component/addequipmentwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddEquipmentWindow.xaml"
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
            this.mainStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.secondStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.labelModel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.buttonAddNewModel = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\AddEquipmentWindow.xaml"
            this.buttonAddNewModel.Click += new System.Windows.RoutedEventHandler(this.buttonAddNewModel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ComboBoxModel = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.textBoxDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.buttonAdd = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\AddEquipmentWindow.xaml"
            this.buttonAdd.Click += new System.Windows.RoutedEventHandler(this.buttonAdd_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

