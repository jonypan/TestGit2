﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.237
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// This source code was auto-generated by wsdl, Version=4.0.30319.1.
// 

namespace Extend.Utilities
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "MailAPISoap", Namespace = "http://api.mail.vtcebank.vn/")]
    public partial class MailAPI : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback CheckEmailExistOperationCompleted;

        private System.Threading.SendOrPostCallback SendMailOperationCompleted;

        private System.Threading.SendOrPostCallback SendMailNewOperationCompleted;

        private System.Threading.SendOrPostCallback SendMaileBankPaygateOperationCompleted;

        private System.Threading.SendOrPostCallback SendMailMonitorOperationCompleted;

        /// <remarks/>
        public MailAPI()
        {
            this.Url = System.Configuration.ConfigurationManager.AppSettings["MAIL_GO_SERVICE.URL"];//"http://mailservice.vtcebank.vn/mailservice/MailAPI.asmx";
        }

        /// <remarks/>
        public event CheckEmailExistCompletedEventHandler CheckEmailExistCompleted;

        /// <remarks/>
        public event SendMailCompletedEventHandler SendMailCompleted;

        /// <remarks/>
        public event SendMailNewCompletedEventHandler SendMailNewCompleted;

        /// <remarks/>
        public event SendMaileBankPaygateCompletedEventHandler SendMaileBankPaygateCompleted;

        /// <remarks/>
        public event SendMailMonitorCompletedEventHandler SendMailMonitorCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://api.mail.vtcebank.vn/CheckEmailExist", RequestNamespace = "http://api.mail.vtcebank.vn/", ResponseNamespace = "http://api.mail.vtcebank.vn/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int CheckEmailExist(string Email, int IdAuthen, string CodeAuthen)
        {
            object[] results = this.Invoke("CheckEmailExist", new object[] {
                    Email,
                    IdAuthen,
                    CodeAuthen});
            return ((int)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginCheckEmailExist(string Email, int IdAuthen, string CodeAuthen, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("CheckEmailExist", new object[] {
                    Email,
                    IdAuthen,
                    CodeAuthen}, callback, asyncState);
        }

        /// <remarks/>
        public int EndCheckEmailExist(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }

        /// <remarks/>
        public void CheckEmailExistAsync(string Email, int IdAuthen, string CodeAuthen)
        {
            this.CheckEmailExistAsync(Email, IdAuthen, CodeAuthen, null);
        }

        /// <remarks/>
        public void CheckEmailExistAsync(string Email, int IdAuthen, string CodeAuthen, object userState)
        {
            if ((this.CheckEmailExistOperationCompleted == null))
            {
                this.CheckEmailExistOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheckEmailExistOperationCompleted);
            }
            this.InvokeAsync("CheckEmailExist", new object[] {
                    Email,
                    IdAuthen,
                    CodeAuthen}, this.CheckEmailExistOperationCompleted, userState);
        }

        private void OnCheckEmailExistOperationCompleted(object arg)
        {
            if ((this.CheckEmailExistCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CheckEmailExistCompleted(this, new CheckEmailExistCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://api.mail.vtcebank.vn/SendMail", RequestNamespace = "http://api.mail.vtcebank.vn/", ResponseNamespace = "http://api.mail.vtcebank.vn/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SendMail(string FromName, string FromEmail, string ToEmail, string Subject, string Message, int EventMail, long IdRequest, int DateSend, int IdAuthen, string CodeAuthen)
        {
            object[] results = this.Invoke("SendMail", new object[] {
                    FromName,
                    FromEmail,
                    ToEmail,
                    Subject,
                    Message,
                    EventMail,
                    IdRequest,
                    DateSend,
                    IdAuthen,
                    CodeAuthen});
            return ((int)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSendMail(string FromName, string FromEmail, string ToEmail, string Subject, string Message, int EventMail, long IdRequest, int DateSend, int IdAuthen, string CodeAuthen, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("SendMail", new object[] {
                    FromName,
                    FromEmail,
                    ToEmail,
                    Subject,
                    Message,
                    EventMail,
                    IdRequest,
                    DateSend,
                    IdAuthen,
                    CodeAuthen}, callback, asyncState);
        }

        /// <remarks/>
        public int EndSendMail(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }

        /// <remarks/>
        public void SendMailAsync(string FromName, string FromEmail, string ToEmail, string Subject, string Message, int EventMail, long IdRequest, int DateSend, int IdAuthen, string CodeAuthen)
        {
            this.SendMailAsync(FromName, FromEmail, ToEmail, Subject, Message, EventMail, IdRequest, DateSend, IdAuthen, CodeAuthen, null);
        }

        /// <remarks/>
        public void SendMailAsync(string FromName, string FromEmail, string ToEmail, string Subject, string Message, int EventMail, long IdRequest, int DateSend, int IdAuthen, string CodeAuthen, object userState)
        {
            if ((this.SendMailOperationCompleted == null))
            {
                this.SendMailOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendMailOperationCompleted);
            }
            this.InvokeAsync("SendMail", new object[] {
                    FromName,
                    FromEmail,
                    ToEmail,
                    Subject,
                    Message,
                    EventMail,
                    IdRequest,
                    DateSend,
                    IdAuthen,
                    CodeAuthen}, this.SendMailOperationCompleted, userState);
        }

        private void OnSendMailOperationCompleted(object arg)
        {
            if ((this.SendMailCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendMailCompleted(this, new SendMailCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://api.mail.vtcebank.vn/SendMailNew", RequestNamespace = "http://api.mail.vtcebank.vn/", ResponseNamespace = "http://api.mail.vtcebank.vn/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SendMailNew(string FromName, string FromEmail, string ToEmail, string Subject, string Message, int EventMail, long IdRequest, int DateSend, int IdAuthen, string CodeAuthen, string AccountName, long AccountID)
        {
            object[] results = this.Invoke("SendMailNew", new object[] {
                    FromName,
                    FromEmail,
                    ToEmail,
                    Subject,
                    Message,
                    EventMail,
                    IdRequest,
                    DateSend,
                    IdAuthen,
                    CodeAuthen,
                    AccountName,
                    AccountID});
            return ((int)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSendMailNew(string FromName, string FromEmail, string ToEmail, string Subject, string Message, int EventMail, long IdRequest, int DateSend, int IdAuthen, string CodeAuthen, string AccountName, long AccountID, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("SendMailNew", new object[] {
                    FromName,
                    FromEmail,
                    ToEmail,
                    Subject,
                    Message,
                    EventMail,
                    IdRequest,
                    DateSend,
                    IdAuthen,
                    CodeAuthen,
                    AccountName,
                    AccountID}, callback, asyncState);
        }

        /// <remarks/>
        public int EndSendMailNew(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }

        /// <remarks/>
        public void SendMailNewAsync(string FromName, string FromEmail, string ToEmail, string Subject, string Message, int EventMail, long IdRequest, int DateSend, int IdAuthen, string CodeAuthen, string AccountName, long AccountID)
        {
            this.SendMailNewAsync(FromName, FromEmail, ToEmail, Subject, Message, EventMail, IdRequest, DateSend, IdAuthen, CodeAuthen, AccountName, AccountID, null);
        }

        /// <remarks/>
        public void SendMailNewAsync(string FromName, string FromEmail, string ToEmail, string Subject, string Message, int EventMail, long IdRequest, int DateSend, int IdAuthen, string CodeAuthen, string AccountName, long AccountID, object userState)
        {
            if ((this.SendMailNewOperationCompleted == null))
            {
                this.SendMailNewOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendMailNewOperationCompleted);
            }
            this.InvokeAsync("SendMailNew", new object[] {
                    FromName,
                    FromEmail,
                    ToEmail,
                    Subject,
                    Message,
                    EventMail,
                    IdRequest,
                    DateSend,
                    IdAuthen,
                    CodeAuthen,
                    AccountName,
                    AccountID}, this.SendMailNewOperationCompleted, userState);
        }

        private void OnSendMailNewOperationCompleted(object arg)
        {
            if ((this.SendMailNewCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendMailNewCompleted(this, new SendMailNewCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://api.mail.vtcebank.vn/SendMaileBankPaygate", RequestNamespace = "http://api.mail.vtcebank.vn/", ResponseNamespace = "http://api.mail.vtcebank.vn/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SendMaileBankPaygate(string ToEmail, string AccountName, long AccountID, int ContentID, string Param)
        {
            object[] results = this.Invoke("SendMaileBankPaygate", new object[] {
                    ToEmail,
                    AccountName,
                    AccountID,
                    ContentID,
                    Param});
            return ((int)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSendMaileBankPaygate(string ToEmail, string AccountName, long AccountID, int ContentID, string Param, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("SendMaileBankPaygate", new object[] {
                    ToEmail,
                    AccountName,
                    AccountID,
                    ContentID,
                    Param}, callback, asyncState);
        }

        /// <remarks/>
        public int EndSendMaileBankPaygate(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }

        /// <remarks/>
        public void SendMaileBankPaygateAsync(string ToEmail, string AccountName, long AccountID, int ContentID, string Param)
        {
            this.SendMaileBankPaygateAsync(ToEmail, AccountName, AccountID, ContentID, Param, null);
        }

        /// <remarks/>
        public void SendMaileBankPaygateAsync(string ToEmail, string AccountName, long AccountID, int ContentID, string Param, object userState)
        {
            if ((this.SendMaileBankPaygateOperationCompleted == null))
            {
                this.SendMaileBankPaygateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendMaileBankPaygateOperationCompleted);
            }
            this.InvokeAsync("SendMaileBankPaygate", new object[] {
                    ToEmail,
                    AccountName,
                    AccountID,
                    ContentID,
                    Param}, this.SendMaileBankPaygateOperationCompleted, userState);
        }

        private void OnSendMaileBankPaygateOperationCompleted(object arg)
        {
            if ((this.SendMaileBankPaygateCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendMaileBankPaygateCompleted(this, new SendMaileBankPaygateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://api.mail.vtcebank.vn/SendMailMonitor", RequestNamespace = "http://api.mail.vtcebank.vn/", ResponseNamespace = "http://api.mail.vtcebank.vn/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SendMailMonitor(string FromName, string FromEmail, string ToEmail, string CcEmail, string Subject, string Message, int EventMail, long IdRequest, int IdAuthen, string CodeAuthen)
        {
            object[] results = this.Invoke("SendMailMonitor", new object[] {
                    FromName,
                    FromEmail,
                    ToEmail,
                    CcEmail,
                    Subject,
                    Message,
                    EventMail,
                    IdRequest,
                    IdAuthen,
                    CodeAuthen});
            return ((int)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSendMailMonitor(string FromName, string FromEmail, string ToEmail, string CcEmail, string Subject, string Message, int EventMail, long IdRequest, int IdAuthen, string CodeAuthen, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("SendMailMonitor", new object[] {
                    FromName,
                    FromEmail,
                    ToEmail,
                    CcEmail,
                    Subject,
                    Message,
                    EventMail,
                    IdRequest,
                    IdAuthen,
                    CodeAuthen}, callback, asyncState);
        }

        /// <remarks/>
        public int EndSendMailMonitor(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }

        /// <remarks/>
        public void SendMailMonitorAsync(string FromName, string FromEmail, string ToEmail, string CcEmail, string Subject, string Message, int EventMail, long IdRequest, int IdAuthen, string CodeAuthen)
        {
            this.SendMailMonitorAsync(FromName, FromEmail, ToEmail, CcEmail, Subject, Message, EventMail, IdRequest, IdAuthen, CodeAuthen, null);
        }

        /// <remarks/>
        public void SendMailMonitorAsync(string FromName, string FromEmail, string ToEmail, string CcEmail, string Subject, string Message, int EventMail, long IdRequest, int IdAuthen, string CodeAuthen, object userState)
        {
            if ((this.SendMailMonitorOperationCompleted == null))
            {
                this.SendMailMonitorOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendMailMonitorOperationCompleted);
            }
            this.InvokeAsync("SendMailMonitor", new object[] {
                    FromName,
                    FromEmail,
                    ToEmail,
                    CcEmail,
                    Subject,
                    Message,
                    EventMail,
                    IdRequest,
                    IdAuthen,
                    CodeAuthen}, this.SendMailMonitorOperationCompleted, userState);
        }

        private void OnSendMailMonitorOperationCompleted(object arg)
        {
            if ((this.SendMailMonitorCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendMailMonitorCompleted(this, new SendMailMonitorCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    public delegate void CheckEmailExistCompletedEventHandler(object sender, CheckEmailExistCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CheckEmailExistCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal CheckEmailExistCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public int Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    public delegate void SendMailCompletedEventHandler(object sender, SendMailCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendMailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal SendMailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public int Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    public delegate void SendMailNewCompletedEventHandler(object sender, SendMailNewCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendMailNewCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal SendMailNewCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public int Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    public delegate void SendMaileBankPaygateCompletedEventHandler(object sender, SendMaileBankPaygateCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendMaileBankPaygateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal SendMaileBankPaygateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public int Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    public delegate void SendMailMonitorCompletedEventHandler(object sender, SendMailMonitorCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendMailMonitorCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal SendMailMonitorCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public int Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
}