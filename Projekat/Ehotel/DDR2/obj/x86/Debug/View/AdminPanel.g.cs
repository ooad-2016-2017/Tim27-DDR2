﻿#pragma checksum "C:\Users\mirsad\Desktop\Ehotel\DDR2\View\AdminPanel.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5CFBE7AD271EC3E0AA022E081CB16297"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DDR2.View
{
    partial class AdminPanel : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 20 "..\..\..\View\AdminPanel.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.textBlock).SelectionChanged += this.textBlock_SelectionChanged;
                    #line default
                }
                break;
            case 2:
                {
                    this.btnRez = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 22 "..\..\..\View\AdminPanel.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnRez).Click += this.btnRez_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.btnStaff = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 23 "..\..\..\View\AdminPanel.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnStaff).Click += this.btnStaff_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.btnRooms = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 24 "..\..\..\View\AdminPanel.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnRooms).Click += this.btnRooms_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.btnGuests = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 25 "..\..\..\View\AdminPanel.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnGuests).Click += this.btnGuests_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.btnStatistics = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 26 "..\..\..\View\AdminPanel.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnStatistics).Click += this.btnStatistics_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.btnMonthly = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 27 "..\..\..\View\AdminPanel.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnMonthly).Click += this.btnMonthly_Click;
                    #line default
                }
                break;
            case 8:
                {
                    this.btnProfile = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 28 "..\..\..\View\AdminPanel.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnProfile).Click += this.btnProfile_Click_1;
                    #line default
                }
                break;
            case 9:
                {
                    this.btnLog = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 29 "..\..\..\View\AdminPanel.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnLog).Click += this.btnLog_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

