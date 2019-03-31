﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject.WpfClient.TitleServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Title", Namespace="http://schemas.datacontract.org/2004/07/FinalProject.Domain")]
    [System.SerializableAttribute()]
    public partial class Title : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<short> EndYearField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GenresField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<bool> IsAdultField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OriginalTitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PrimaryTitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> RuntimeMinutesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<short> StartYearField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleTypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<short> EndYear {
            get {
                return this.EndYearField;
            }
            set {
                if ((this.EndYearField.Equals(value) != true)) {
                    this.EndYearField = value;
                    this.RaisePropertyChanged("EndYear");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Genres {
            get {
                return this.GenresField;
            }
            set {
                if ((object.ReferenceEquals(this.GenresField, value) != true)) {
                    this.GenresField = value;
                    this.RaisePropertyChanged("Genres");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<bool> IsAdult {
            get {
                return this.IsAdultField;
            }
            set {
                if ((this.IsAdultField.Equals(value) != true)) {
                    this.IsAdultField = value;
                    this.RaisePropertyChanged("IsAdult");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OriginalTitle {
            get {
                return this.OriginalTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.OriginalTitleField, value) != true)) {
                    this.OriginalTitleField = value;
                    this.RaisePropertyChanged("OriginalTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PrimaryTitle {
            get {
                return this.PrimaryTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.PrimaryTitleField, value) != true)) {
                    this.PrimaryTitleField = value;
                    this.RaisePropertyChanged("PrimaryTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> RuntimeMinutes {
            get {
                return this.RuntimeMinutesField;
            }
            set {
                if ((this.RuntimeMinutesField.Equals(value) != true)) {
                    this.RuntimeMinutesField = value;
                    this.RaisePropertyChanged("RuntimeMinutes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<short> StartYear {
            get {
                return this.StartYearField;
            }
            set {
                if ((this.StartYearField.Equals(value) != true)) {
                    this.StartYearField = value;
                    this.RaisePropertyChanged("StartYear");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TitleId {
            get {
                return this.TitleIdField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleIdField, value) != true)) {
                    this.TitleIdField = value;
                    this.RaisePropertyChanged("TitleId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TitleType {
            get {
                return this.TitleTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleTypeField, value) != true)) {
                    this.TitleTypeField = value;
                    this.RaisePropertyChanged("TitleType");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TitleServiceReference.ITitleService")]
    public interface ITitleService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITitleService/GetTitleById", ReplyAction="http://tempuri.org/ITitleService/GetTitleByIdResponse")]
        FinalProject.WpfClient.TitleServiceReference.Title GetTitleById(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITitleService/GetTitleById", ReplyAction="http://tempuri.org/ITitleService/GetTitleByIdResponse")]
        System.Threading.Tasks.Task<FinalProject.WpfClient.TitleServiceReference.Title> GetTitleByIdAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITitleService/GetTitlesByTitle", ReplyAction="http://tempuri.org/ITitleService/GetTitlesByTitleResponse")]
        FinalProject.WpfClient.TitleServiceReference.Title[] GetTitlesByTitle(string title);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITitleService/GetTitlesByTitle", ReplyAction="http://tempuri.org/ITitleService/GetTitlesByTitleResponse")]
        System.Threading.Tasks.Task<FinalProject.WpfClient.TitleServiceReference.Title[]> GetTitlesByTitleAsync(string title);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITitleService/GetTitleRangeByTitle", ReplyAction="http://tempuri.org/ITitleService/GetTitleRangeByTitleResponse")]
        FinalProject.WpfClient.TitleServiceReference.Title[] GetTitleRangeByTitle(string title, int startIndex, int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITitleService/GetTitleRangeByTitle", ReplyAction="http://tempuri.org/ITitleService/GetTitleRangeByTitleResponse")]
        System.Threading.Tasks.Task<FinalProject.WpfClient.TitleServiceReference.Title[]> GetTitleRangeByTitleAsync(string title, int startIndex, int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITitleService/GetTitleCountByTitle", ReplyAction="http://tempuri.org/ITitleService/GetTitleCountByTitleResponse")]
        int GetTitleCountByTitle(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITitleService/GetTitleCountByTitle", ReplyAction="http://tempuri.org/ITitleService/GetTitleCountByTitleResponse")]
        System.Threading.Tasks.Task<int> GetTitleCountByTitleAsync(string id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITitleServiceChannel : FinalProject.WpfClient.TitleServiceReference.ITitleService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TitleServiceClient : System.ServiceModel.ClientBase<FinalProject.WpfClient.TitleServiceReference.ITitleService>, FinalProject.WpfClient.TitleServiceReference.ITitleService {
        
        public TitleServiceClient() {
        }
        
        public TitleServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TitleServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TitleServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TitleServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public FinalProject.WpfClient.TitleServiceReference.Title GetTitleById(string id) {
            return base.Channel.GetTitleById(id);
        }
        
        public System.Threading.Tasks.Task<FinalProject.WpfClient.TitleServiceReference.Title> GetTitleByIdAsync(string id) {
            return base.Channel.GetTitleByIdAsync(id);
        }
        
        public FinalProject.WpfClient.TitleServiceReference.Title[] GetTitlesByTitle(string title) {
            return base.Channel.GetTitlesByTitle(title);
        }
        
        public System.Threading.Tasks.Task<FinalProject.WpfClient.TitleServiceReference.Title[]> GetTitlesByTitleAsync(string title) {
            return base.Channel.GetTitlesByTitleAsync(title);
        }
        
        public FinalProject.WpfClient.TitleServiceReference.Title[] GetTitleRangeByTitle(string title, int startIndex, int count) {
            return base.Channel.GetTitleRangeByTitle(title, startIndex, count);
        }
        
        public System.Threading.Tasks.Task<FinalProject.WpfClient.TitleServiceReference.Title[]> GetTitleRangeByTitleAsync(string title, int startIndex, int count) {
            return base.Channel.GetTitleRangeByTitleAsync(title, startIndex, count);
        }
        
        public int GetTitleCountByTitle(string id) {
            return base.Channel.GetTitleCountByTitle(id);
        }
        
        public System.Threading.Tasks.Task<int> GetTitleCountByTitleAsync(string id) {
            return base.Channel.GetTitleCountByTitleAsync(id);
        }
    }
}