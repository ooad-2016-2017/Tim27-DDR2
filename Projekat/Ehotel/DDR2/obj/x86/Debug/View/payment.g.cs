﻿#pragma checksum "C:\Users\mirsad\Desktop\Ehotel\DDR2\View\Payment.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FD967E2B6EEDA1D3A855B15D6554A01E"
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
    partial class payment : 
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
                    this.btnConfirm = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 35 "..\..\..\View\Payment.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnConfirm).Click += this.btnConfirm_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.btnCancel = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 36 "..\..\..\View\Payment.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnCancel).Click += this.btnCancel_Click;
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

