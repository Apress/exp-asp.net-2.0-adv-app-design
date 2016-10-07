﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50215.44
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50215.44.
// 
namespace TestApp.Proxies {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    // CODEGEN: The optional WSDL extension element 'method' from namespace 'http://www.w3.org/2000/wsdl/suds' was not handled.
    // CODEGEN: The optional WSDL extension element 'class' from namespace 'http://www.w3.org/2000/wsdl/suds' was not handled.
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="JITABinding", Namespace="http://schemas.microsoft.com/clr/nsassem/ESDemo/Serviced%2C%20Version%3D1.0.0.0%2" +
        "C%20Culture%3Dneutral%2C%20PublicKeyToken%3De46b361384c3aa00")]
    public partial class JITAService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetCreateStampRequestOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public JITAService() {
            this.Url = TestApp.Properties.Settings.Default.TestApp_Proxies_JITAService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetCreateStampRequestCompletedEventHandler GetCreateStampRequestCompleted;
        
        /// <remarks/>
        [System.Web.Services.WebMethodAttribute(MessageName="GetCreateStampRequest")]
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://schemas.microsoft.com/clr/nsassem/ESDemo.JITA/Serviced#GetCreateStamp", RequestNamespace="http://schemas.microsoft.com/clr/nsassem/ESDemo.JITA/Serviced", ResponseNamespace="http://schemas.microsoft.com/clr/nsassem/ESDemo.JITA/Serviced")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public System.DateTime GetCreateStamp() {
            object[] results = this.Invoke("GetCreateStampRequest", new object[0]);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        public void GetCreateStampRequestAsync() {
            this.GetCreateStampRequestAsync(null);
        }
        
        /// <remarks/>
        public void GetCreateStampRequestAsync(object userState) {
            if ((this.GetCreateStampRequestOperationCompleted == null)) {
                this.GetCreateStampRequestOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCreateStampRequestOperationCompleted);
            }
            this.InvokeAsync("GetCreateStampRequest", new object[0], this.GetCreateStampRequestOperationCompleted, userState);
        }
        
        private void OnGetCreateStampRequestOperationCompleted(object arg) {
            if ((this.GetCreateStampRequestCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCreateStampRequestCompleted(this, new GetCreateStampRequestCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if ((((wsUri.Port >= 1024) 
                        && (wsUri.Port <= 5000)) 
                        && (string.Compare(wsUri.Host, "localHost", true) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    public delegate void GetCreateStampRequestCompletedEventHandler(object sender, GetCreateStampRequestCompletedEventArgs e);
    
    /// <remarks/>
    public partial class GetCreateStampRequestCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCreateStampRequestCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.DateTime Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.DateTime)(this.results[0]));
            }
        }
    }
}
