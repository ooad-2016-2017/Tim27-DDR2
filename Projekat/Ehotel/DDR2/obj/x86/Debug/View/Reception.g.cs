﻿#pragma checksum "C:\Users\mirsad\Desktop\Ehotel\DDR2\View\Reception.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6B990F49CBC73A748D1411AE4CDD6795"
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
    partial class Reception : 
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
                    global::Windows.UI.Xaml.Controls.Button element1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 23 "..\..\..\View\Reception.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element1).Click += this.Button_Click_1;
                    #line default
                }
                break;
            case 2:
                {
                    this.btnReservations = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 24 "..\..\..\View\Reception.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnReservations).Click += this.btnReservations_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.btnCheckIN = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 25 "..\..\..\View\Reception.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnCheckIN).Click += this.btnCheckIN_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.bntCheckOUT = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 26 "..\..\..\View\Reception.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.bntCheckOUT).Click += this.bntCheckOUT_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.btnLog = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 27 "..\..\..\View\Reception.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnLog).Click += this.btnLog_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.ReservationsListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
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

