﻿#pragma checksum "..\..\..\view\file_video_view.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C1AA627700C458AB6353589DD0DF84875659F9FADB41B332A655E7A7E39296F7"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
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
using pm_client.view;


namespace pm_client.view {
    
    
    /// <summary>
    /// file_video_view
    /// </summary>
    public partial class file_video_view : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\view\file_video_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Playbutton;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\view\file_video_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Pausebutton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\view\file_video_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exitbutton;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\view\file_video_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement mePlayer;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\view\file_video_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblProgressStatus;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\view\file_video_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sliProgress;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\view\file_video_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar pbVolume;
        
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
            System.Uri resourceLocater = new System.Uri("/pm_client;component/view/file_video_view.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\view\file_video_view.xaml"
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
            
            #line 10 "..\..\..\view\file_video_view.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.Grid_MouseWheel);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Playbutton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\view\file_video_view.xaml"
            this.Playbutton.Click += new System.Windows.RoutedEventHandler(this.Playbutton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Pausebutton = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\view\file_video_view.xaml"
            this.Pausebutton.Click += new System.Windows.RoutedEventHandler(this.Pausebutton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Exitbutton = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\view\file_video_view.xaml"
            this.Exitbutton.Click += new System.Windows.RoutedEventHandler(this.Exitbutton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.mePlayer = ((System.Windows.Controls.MediaElement)(target));
            
            #line 37 "..\..\..\view\file_video_view.xaml"
            this.mePlayer.Loaded += new System.Windows.RoutedEventHandler(this.mePlayer_Loaded);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lblProgressStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.sliProgress = ((System.Windows.Controls.Slider)(target));
            
            #line 61 "..\..\..\view\file_video_view.xaml"
            this.sliProgress.AddHandler(System.Windows.Controls.Primitives.Thumb.DragStartedEvent, new System.Windows.Controls.Primitives.DragStartedEventHandler(this.sliProgress_DragStarted));
            
            #line default
            #line hidden
            
            #line 61 "..\..\..\view\file_video_view.xaml"
            this.sliProgress.AddHandler(System.Windows.Controls.Primitives.Thumb.DragCompletedEvent, new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.sliProgress_DragCompleted));
            
            #line default
            #line hidden
            
            #line 61 "..\..\..\view\file_video_view.xaml"
            this.sliProgress.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.sliProgress_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.pbVolume = ((System.Windows.Controls.ProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

