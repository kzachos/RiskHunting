// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.17020
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace RiskHunting.hofService {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Web-Based Hall of Fame ServiceSoap", Namespace="http://10.200.51.10/")]
    public partial class WebBasedHallofFameService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback RetrievePersonaSimpleOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrievePersonaSimpleBrokenOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrievePersonaFromTypeSimpleOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrievePersonaFromTypesSimpleOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrieveSinglePersonaSimpleOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrievePersonaAdvancedOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrieveAllPersonasOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrieveAllPersonasFromTypeOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrieveAllPersonasFromTypesOperationCompleted;
        
        /// CodeRemarks
        public WebBasedHallofFameService() {
            this.Url = "http://achernar.soi.city.ac.uk/HallOfFame/HallOfFameService/Service1.asmx";
        }
        
        public WebBasedHallofFameService(string url) {
            this.Url = url;
        }
        
        /// CodeRemarks
        public event RetrievePersonaSimpleCompletedEventHandler RetrievePersonaSimpleCompleted;
        
        /// CodeRemarks
        public event RetrievePersonaSimpleBrokenCompletedEventHandler RetrievePersonaSimpleBrokenCompleted;
        
        /// CodeRemarks
        public event RetrievePersonaFromTypeSimpleCompletedEventHandler RetrievePersonaFromTypeSimpleCompleted;
        
        /// CodeRemarks
        public event RetrievePersonaFromTypesSimpleCompletedEventHandler RetrievePersonaFromTypesSimpleCompleted;
        
        /// CodeRemarks
        public event RetrieveSinglePersonaSimpleCompletedEventHandler RetrieveSinglePersonaSimpleCompleted;
        
        /// CodeRemarks
        public event RetrievePersonaAdvancedCompletedEventHandler RetrievePersonaAdvancedCompleted;
        
        /// CodeRemarks
        public event RetrieveAllPersonasCompletedEventHandler RetrieveAllPersonasCompleted;
        
        /// CodeRemarks
        public event RetrieveAllPersonasFromTypeCompletedEventHandler RetrieveAllPersonasFromTypeCompleted;
        
        /// CodeRemarks
        public event RetrieveAllPersonasFromTypesCompletedEventHandler RetrieveAllPersonasFromTypesCompleted;
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://10.200.51.10/RetrievePersonaSimple", RequestNamespace="http://10.200.51.10/", ResponseNamespace="http://10.200.51.10/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RetrievePersonaSimple() {
            object[] results = this.Invoke("RetrievePersonaSimple", new object[0]);
            return ((string)(results[0]));
        }
        
        /// CodeRemarks
        public void RetrievePersonaSimpleAsync() {
            this.RetrievePersonaSimpleAsync(null);
        }
        
        /// CodeRemarks
        public void RetrievePersonaSimpleAsync(object userState) {
            if ((this.RetrievePersonaSimpleOperationCompleted == null)) {
                this.RetrievePersonaSimpleOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrievePersonaSimpleOperationCompleted);
            }
            this.InvokeAsync("RetrievePersonaSimple", new object[0], this.RetrievePersonaSimpleOperationCompleted, userState);
        }
        
        private void OnRetrievePersonaSimpleOperationCompleted(object arg) {
            if ((this.RetrievePersonaSimpleCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrievePersonaSimpleCompleted(this, new RetrievePersonaSimpleCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://10.200.51.10/RetrievePersonaSimpleBroken", RequestNamespace="http://10.200.51.10/", ResponseNamespace="http://10.200.51.10/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RetrievePersonaSimpleBroken() {
            object[] results = this.Invoke("RetrievePersonaSimpleBroken", new object[0]);
            return ((string)(results[0]));
        }
        
        /// CodeRemarks
        public void RetrievePersonaSimpleBrokenAsync() {
            this.RetrievePersonaSimpleBrokenAsync(null);
        }
        
        /// CodeRemarks
        public void RetrievePersonaSimpleBrokenAsync(object userState) {
            if ((this.RetrievePersonaSimpleBrokenOperationCompleted == null)) {
                this.RetrievePersonaSimpleBrokenOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrievePersonaSimpleBrokenOperationCompleted);
            }
            this.InvokeAsync("RetrievePersonaSimpleBroken", new object[0], this.RetrievePersonaSimpleBrokenOperationCompleted, userState);
        }
        
        private void OnRetrievePersonaSimpleBrokenOperationCompleted(object arg) {
            if ((this.RetrievePersonaSimpleBrokenCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrievePersonaSimpleBrokenCompleted(this, new RetrievePersonaSimpleBrokenCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://10.200.51.10/RetrievePersonaFromTypeSimple", RequestNamespace="http://10.200.51.10/", ResponseNamespace="http://10.200.51.10/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RetrievePersonaFromTypeSimple(string type) {
            object[] results = this.Invoke("RetrievePersonaFromTypeSimple", new object[] {
                        type});
            return ((string)(results[0]));
        }
        
        /// CodeRemarks
        public void RetrievePersonaFromTypeSimpleAsync(string type) {
            this.RetrievePersonaFromTypeSimpleAsync(type, null);
        }
        
        /// CodeRemarks
        public void RetrievePersonaFromTypeSimpleAsync(string type, object userState) {
            if ((this.RetrievePersonaFromTypeSimpleOperationCompleted == null)) {
                this.RetrievePersonaFromTypeSimpleOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrievePersonaFromTypeSimpleOperationCompleted);
            }
            this.InvokeAsync("RetrievePersonaFromTypeSimple", new object[] {
                        type}, this.RetrievePersonaFromTypeSimpleOperationCompleted, userState);
        }
        
        private void OnRetrievePersonaFromTypeSimpleOperationCompleted(object arg) {
            if ((this.RetrievePersonaFromTypeSimpleCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrievePersonaFromTypeSimpleCompleted(this, new RetrievePersonaFromTypeSimpleCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://10.200.51.10/RetrievePersonaFromTypesSimple", RequestNamespace="http://10.200.51.10/", ResponseNamespace="http://10.200.51.10/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RetrievePersonaFromTypesSimple(string types) {
            object[] results = this.Invoke("RetrievePersonaFromTypesSimple", new object[] {
                        types});
            return ((string)(results[0]));
        }
        
        /// CodeRemarks
        public void RetrievePersonaFromTypesSimpleAsync(string types) {
            this.RetrievePersonaFromTypesSimpleAsync(types, null);
        }
        
        /// CodeRemarks
        public void RetrievePersonaFromTypesSimpleAsync(string types, object userState) {
            if ((this.RetrievePersonaFromTypesSimpleOperationCompleted == null)) {
                this.RetrievePersonaFromTypesSimpleOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrievePersonaFromTypesSimpleOperationCompleted);
            }
            this.InvokeAsync("RetrievePersonaFromTypesSimple", new object[] {
                        types}, this.RetrievePersonaFromTypesSimpleOperationCompleted, userState);
        }
        
        private void OnRetrievePersonaFromTypesSimpleOperationCompleted(object arg) {
            if ((this.RetrievePersonaFromTypesSimpleCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrievePersonaFromTypesSimpleCompleted(this, new RetrievePersonaFromTypesSimpleCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://10.200.51.10/RetrieveSinglePersonaSimple", RequestNamespace="http://10.200.51.10/", ResponseNamespace="http://10.200.51.10/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RetrieveSinglePersonaSimple(string name) {
            object[] results = this.Invoke("RetrieveSinglePersonaSimple", new object[] {
                        name});
            return ((string)(results[0]));
        }
        
        /// CodeRemarks
        public void RetrieveSinglePersonaSimpleAsync(string name) {
            this.RetrieveSinglePersonaSimpleAsync(name, null);
        }
        
        /// CodeRemarks
        public void RetrieveSinglePersonaSimpleAsync(string name, object userState) {
            if ((this.RetrieveSinglePersonaSimpleOperationCompleted == null)) {
                this.RetrieveSinglePersonaSimpleOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrieveSinglePersonaSimpleOperationCompleted);
            }
            this.InvokeAsync("RetrieveSinglePersonaSimple", new object[] {
                        name}, this.RetrieveSinglePersonaSimpleOperationCompleted, userState);
        }
        
        private void OnRetrieveSinglePersonaSimpleOperationCompleted(object arg) {
            if ((this.RetrieveSinglePersonaSimpleCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrieveSinglePersonaSimpleCompleted(this, new RetrieveSinglePersonaSimpleCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://10.200.51.10/RetrievePersonaAdvanced", RequestNamespace="http://10.200.51.10/", ResponseNamespace="http://10.200.51.10/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RetrievePersonaAdvanced(string searchCriteria) {
            object[] results = this.Invoke("RetrievePersonaAdvanced", new object[] {
                        searchCriteria});
            return ((string)(results[0]));
        }
        
        /// CodeRemarks
        public void RetrievePersonaAdvancedAsync(string searchCriteria) {
            this.RetrievePersonaAdvancedAsync(searchCriteria, null);
        }
        
        /// CodeRemarks
        public void RetrievePersonaAdvancedAsync(string searchCriteria, object userState) {
            if ((this.RetrievePersonaAdvancedOperationCompleted == null)) {
                this.RetrievePersonaAdvancedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrievePersonaAdvancedOperationCompleted);
            }
            this.InvokeAsync("RetrievePersonaAdvanced", new object[] {
                        searchCriteria}, this.RetrievePersonaAdvancedOperationCompleted, userState);
        }
        
        private void OnRetrievePersonaAdvancedOperationCompleted(object arg) {
            if ((this.RetrievePersonaAdvancedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrievePersonaAdvancedCompleted(this, new RetrievePersonaAdvancedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://10.200.51.10/RetrieveAllPersonas", RequestNamespace="http://10.200.51.10/", ResponseNamespace="http://10.200.51.10/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RetrieveAllPersonas() {
            object[] results = this.Invoke("RetrieveAllPersonas", new object[0]);
            return ((string)(results[0]));
        }
        
        /// CodeRemarks
        public void RetrieveAllPersonasAsync() {
            this.RetrieveAllPersonasAsync(null);
        }
        
        /// CodeRemarks
        public void RetrieveAllPersonasAsync(object userState) {
            if ((this.RetrieveAllPersonasOperationCompleted == null)) {
                this.RetrieveAllPersonasOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrieveAllPersonasOperationCompleted);
            }
            this.InvokeAsync("RetrieveAllPersonas", new object[0], this.RetrieveAllPersonasOperationCompleted, userState);
        }
        
        private void OnRetrieveAllPersonasOperationCompleted(object arg) {
            if ((this.RetrieveAllPersonasCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrieveAllPersonasCompleted(this, new RetrieveAllPersonasCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://10.200.51.10/RetrieveAllPersonasFromType", RequestNamespace="http://10.200.51.10/", ResponseNamespace="http://10.200.51.10/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RetrieveAllPersonasFromType(string type) {
            object[] results = this.Invoke("RetrieveAllPersonasFromType", new object[] {
                        type});
            return ((string)(results[0]));
        }
        
        /// CodeRemarks
        public void RetrieveAllPersonasFromTypeAsync(string type) {
            this.RetrieveAllPersonasFromTypeAsync(type, null);
        }
        
        /// CodeRemarks
        public void RetrieveAllPersonasFromTypeAsync(string type, object userState) {
            if ((this.RetrieveAllPersonasFromTypeOperationCompleted == null)) {
                this.RetrieveAllPersonasFromTypeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrieveAllPersonasFromTypeOperationCompleted);
            }
            this.InvokeAsync("RetrieveAllPersonasFromType", new object[] {
                        type}, this.RetrieveAllPersonasFromTypeOperationCompleted, userState);
        }
        
        private void OnRetrieveAllPersonasFromTypeOperationCompleted(object arg) {
            if ((this.RetrieveAllPersonasFromTypeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrieveAllPersonasFromTypeCompleted(this, new RetrieveAllPersonasFromTypeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://10.200.51.10/RetrieveAllPersonasFromTypes", RequestNamespace="http://10.200.51.10/", ResponseNamespace="http://10.200.51.10/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RetrieveAllPersonasFromTypes(string types) {
            object[] results = this.Invoke("RetrieveAllPersonasFromTypes", new object[] {
                        types});
            return ((string)(results[0]));
        }
        
        /// CodeRemarks
        public void RetrieveAllPersonasFromTypesAsync(string types) {
            this.RetrieveAllPersonasFromTypesAsync(types, null);
        }
        
        /// CodeRemarks
        public void RetrieveAllPersonasFromTypesAsync(string types, object userState) {
            if ((this.RetrieveAllPersonasFromTypesOperationCompleted == null)) {
                this.RetrieveAllPersonasFromTypesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrieveAllPersonasFromTypesOperationCompleted);
            }
            this.InvokeAsync("RetrieveAllPersonasFromTypes", new object[] {
                        types}, this.RetrieveAllPersonasFromTypesOperationCompleted, userState);
        }
        
        private void OnRetrieveAllPersonasFromTypesOperationCompleted(object arg) {
            if ((this.RetrieveAllPersonasFromTypesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrieveAllPersonasFromTypesCompleted(this, new RetrieveAllPersonasFromTypesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// CodeRemarks
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
    }
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void RetrievePersonaSimpleCompletedEventHandler(object sender, RetrievePersonaSimpleCompletedEventArgs e);
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrievePersonaSimpleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrievePersonaSimpleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// CodeRemarks
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void RetrievePersonaSimpleBrokenCompletedEventHandler(object sender, RetrievePersonaSimpleBrokenCompletedEventArgs e);
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrievePersonaSimpleBrokenCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrievePersonaSimpleBrokenCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// CodeRemarks
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void RetrievePersonaFromTypeSimpleCompletedEventHandler(object sender, RetrievePersonaFromTypeSimpleCompletedEventArgs e);
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrievePersonaFromTypeSimpleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrievePersonaFromTypeSimpleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// CodeRemarks
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void RetrievePersonaFromTypesSimpleCompletedEventHandler(object sender, RetrievePersonaFromTypesSimpleCompletedEventArgs e);
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrievePersonaFromTypesSimpleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrievePersonaFromTypesSimpleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// CodeRemarks
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void RetrieveSinglePersonaSimpleCompletedEventHandler(object sender, RetrieveSinglePersonaSimpleCompletedEventArgs e);
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrieveSinglePersonaSimpleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrieveSinglePersonaSimpleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// CodeRemarks
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void RetrievePersonaAdvancedCompletedEventHandler(object sender, RetrievePersonaAdvancedCompletedEventArgs e);
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrievePersonaAdvancedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrievePersonaAdvancedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// CodeRemarks
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void RetrieveAllPersonasCompletedEventHandler(object sender, RetrieveAllPersonasCompletedEventArgs e);
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrieveAllPersonasCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrieveAllPersonasCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// CodeRemarks
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void RetrieveAllPersonasFromTypeCompletedEventHandler(object sender, RetrieveAllPersonasFromTypeCompletedEventArgs e);
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrieveAllPersonasFromTypeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrieveAllPersonasFromTypeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// CodeRemarks
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    public delegate void RetrieveAllPersonasFromTypesCompletedEventHandler(object sender, RetrieveAllPersonasFromTypesCompletedEventArgs e);
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrieveAllPersonasFromTypesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrieveAllPersonasFromTypesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// CodeRemarks
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}
