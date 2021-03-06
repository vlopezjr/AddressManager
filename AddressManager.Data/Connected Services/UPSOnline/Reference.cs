﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AddressManager.Data.UPSOnline {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Response", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Response : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ConsigneeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Address1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Address2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Zip5Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Zip4Field;
        
        private int ClassificationField;
        
        private int StatusField;
        
        private int CountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Consignee {
            get {
                return this.ConsigneeField;
            }
            set {
                if ((object.ReferenceEquals(this.ConsigneeField, value) != true)) {
                    this.ConsigneeField = value;
                    this.RaisePropertyChanged("Consignee");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Address1 {
            get {
                return this.Address1Field;
            }
            set {
                if ((object.ReferenceEquals(this.Address1Field, value) != true)) {
                    this.Address1Field = value;
                    this.RaisePropertyChanged("Address1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Address2 {
            get {
                return this.Address2Field;
            }
            set {
                if ((object.ReferenceEquals(this.Address2Field, value) != true)) {
                    this.Address2Field = value;
                    this.RaisePropertyChanged("Address2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string City {
            get {
                return this.CityField;
            }
            set {
                if ((object.ReferenceEquals(this.CityField, value) != true)) {
                    this.CityField = value;
                    this.RaisePropertyChanged("City");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string State {
            get {
                return this.StateField;
            }
            set {
                if ((object.ReferenceEquals(this.StateField, value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string Zip5 {
            get {
                return this.Zip5Field;
            }
            set {
                if ((object.ReferenceEquals(this.Zip5Field, value) != true)) {
                    this.Zip5Field = value;
                    this.RaisePropertyChanged("Zip5");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string Zip4 {
            get {
                return this.Zip4Field;
            }
            set {
                if ((object.ReferenceEquals(this.Zip4Field, value) != true)) {
                    this.Zip4Field = value;
                    this.RaisePropertyChanged("Zip4");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=7)]
        public int Classification {
            get {
                return this.ClassificationField;
            }
            set {
                if ((this.ClassificationField.Equals(value) != true)) {
                    this.ClassificationField = value;
                    this.RaisePropertyChanged("Classification");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=8)]
        public int Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=9)]
        public int Count {
            get {
                return this.CountField;
            }
            set {
                if ((this.CountField.Equals(value) != true)) {
                    this.CountField = value;
                    this.RaisePropertyChanged("Count");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UPSOnline.UPSOnlineSoap")]
    public interface UPSOnlineSoap {
        
        // CODEGEN: Generating message contract since element name addr1 from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ValidateClassifyAddressXML", ReplyAction="*")]
        AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLResponse ValidateClassifyAddressXML(AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ValidateClassifyAddressXML", ReplyAction="*")]
        System.Threading.Tasks.Task<AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLResponse> ValidateClassifyAddressXMLAsync(AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ValidateClassifyAddress", ReplyAction="*")]
        AddressManager.Data.UPSOnline.ValidateClassifyAddressResponse ValidateClassifyAddress(AddressManager.Data.UPSOnline.ValidateClassifyAddressRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ValidateClassifyAddress", ReplyAction="*")]
        System.Threading.Tasks.Task<AddressManager.Data.UPSOnline.ValidateClassifyAddressResponse> ValidateClassifyAddressAsync(AddressManager.Data.UPSOnline.ValidateClassifyAddressRequest request);
        
        // CODEGEN: Generating message contract since element name addr1 from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassifyAddressXML", ReplyAction="*")]
        AddressManager.Data.UPSOnline.ClassifyAddressXMLResponse ClassifyAddressXML(AddressManager.Data.UPSOnline.ClassifyAddressXMLRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassifyAddressXML", ReplyAction="*")]
        System.Threading.Tasks.Task<AddressManager.Data.UPSOnline.ClassifyAddressXMLResponse> ClassifyAddressXMLAsync(AddressManager.Data.UPSOnline.ClassifyAddressXMLRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassifyAddress", ReplyAction="*")]
        AddressManager.Data.UPSOnline.ClassifyAddressResponse ClassifyAddress(AddressManager.Data.UPSOnline.ClassifyAddressRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassifyAddress", ReplyAction="*")]
        System.Threading.Tasks.Task<AddressManager.Data.UPSOnline.ClassifyAddressResponse> ClassifyAddressAsync(AddressManager.Data.UPSOnline.ClassifyAddressRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ValidateClassifyAddressXMLRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ValidateClassifyAddressXML", Namespace="http://tempuri.org/", Order=0)]
        public AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLRequestBody Body;
        
        public ValidateClassifyAddressXMLRequest() {
        }
        
        public ValidateClassifyAddressXMLRequest(AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ValidateClassifyAddressXMLRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string addr1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string addr2;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string city;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string state;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string zip5;
        
        public ValidateClassifyAddressXMLRequestBody() {
        }
        
        public ValidateClassifyAddressXMLRequestBody(string addr1, string addr2, string city, string state, string zip5) {
            this.addr1 = addr1;
            this.addr2 = addr2;
            this.city = city;
            this.state = state;
            this.zip5 = zip5;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ValidateClassifyAddressXMLResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ValidateClassifyAddressXMLResponse", Namespace="http://tempuri.org/", Order=0)]
        public AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLResponseBody Body;
        
        public ValidateClassifyAddressXMLResponse() {
        }
        
        public ValidateClassifyAddressXMLResponse(AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ValidateClassifyAddressXMLResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public AddressManager.Data.UPSOnline.Response ValidateClassifyAddressXMLResult;
        
        public ValidateClassifyAddressXMLResponseBody() {
        }
        
        public ValidateClassifyAddressXMLResponseBody(AddressManager.Data.UPSOnline.Response ValidateClassifyAddressXMLResult) {
            this.ValidateClassifyAddressXMLResult = ValidateClassifyAddressXMLResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ValidateClassifyAddressRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ValidateClassifyAddress", Namespace="http://tempuri.org/", Order=0)]
        public AddressManager.Data.UPSOnline.ValidateClassifyAddressRequestBody Body;
        
        public ValidateClassifyAddressRequest() {
        }
        
        public ValidateClassifyAddressRequest(AddressManager.Data.UPSOnline.ValidateClassifyAddressRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ValidateClassifyAddressRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string addr1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string addr2;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string city;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string state;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string zip5;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string zip4;
        
        public ValidateClassifyAddressRequestBody() {
        }
        
        public ValidateClassifyAddressRequestBody(string addr1, string addr2, string city, string state, string zip5, string zip4) {
            this.addr1 = addr1;
            this.addr2 = addr2;
            this.city = city;
            this.state = state;
            this.zip5 = zip5;
            this.zip4 = zip4;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ValidateClassifyAddressResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ValidateClassifyAddressResponse", Namespace="http://tempuri.org/", Order=0)]
        public AddressManager.Data.UPSOnline.ValidateClassifyAddressResponseBody Body;
        
        public ValidateClassifyAddressResponse() {
        }
        
        public ValidateClassifyAddressResponse(AddressManager.Data.UPSOnline.ValidateClassifyAddressResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ValidateClassifyAddressResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int ValidateClassifyAddressResult;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string addr1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string addr2;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string city;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string state;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string zip5;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string zip4;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public int status;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=8)]
        public int classification;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=9)]
        public int count;
        
        public ValidateClassifyAddressResponseBody() {
        }
        
        public ValidateClassifyAddressResponseBody(int ValidateClassifyAddressResult, string addr1, string addr2, string city, string state, string zip5, string zip4, int status, int classification, int count) {
            this.ValidateClassifyAddressResult = ValidateClassifyAddressResult;
            this.addr1 = addr1;
            this.addr2 = addr2;
            this.city = city;
            this.state = state;
            this.zip5 = zip5;
            this.zip4 = zip4;
            this.status = status;
            this.classification = classification;
            this.count = count;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ClassifyAddressXMLRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ClassifyAddressXML", Namespace="http://tempuri.org/", Order=0)]
        public AddressManager.Data.UPSOnline.ClassifyAddressXMLRequestBody Body;
        
        public ClassifyAddressXMLRequest() {
        }
        
        public ClassifyAddressXMLRequest(AddressManager.Data.UPSOnline.ClassifyAddressXMLRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ClassifyAddressXMLRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string addr1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string addr2;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string city;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string state;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string zip5;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string zip4;
        
        public ClassifyAddressXMLRequestBody() {
        }
        
        public ClassifyAddressXMLRequestBody(string addr1, string addr2, string city, string state, string zip5, string zip4) {
            this.addr1 = addr1;
            this.addr2 = addr2;
            this.city = city;
            this.state = state;
            this.zip5 = zip5;
            this.zip4 = zip4;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ClassifyAddressXMLResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ClassifyAddressXMLResponse", Namespace="http://tempuri.org/", Order=0)]
        public AddressManager.Data.UPSOnline.ClassifyAddressXMLResponseBody Body;
        
        public ClassifyAddressXMLResponse() {
        }
        
        public ClassifyAddressXMLResponse(AddressManager.Data.UPSOnline.ClassifyAddressXMLResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ClassifyAddressXMLResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public AddressManager.Data.UPSOnline.Response ClassifyAddressXMLResult;
        
        public ClassifyAddressXMLResponseBody() {
        }
        
        public ClassifyAddressXMLResponseBody(AddressManager.Data.UPSOnline.Response ClassifyAddressXMLResult) {
            this.ClassifyAddressXMLResult = ClassifyAddressXMLResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ClassifyAddressRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ClassifyAddress", Namespace="http://tempuri.org/", Order=0)]
        public AddressManager.Data.UPSOnline.ClassifyAddressRequestBody Body;
        
        public ClassifyAddressRequest() {
        }
        
        public ClassifyAddressRequest(AddressManager.Data.UPSOnline.ClassifyAddressRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ClassifyAddressRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string addr1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string addr2;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string city;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string state;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string zip5;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string zip4;
        
        public ClassifyAddressRequestBody() {
        }
        
        public ClassifyAddressRequestBody(string addr1, string addr2, string city, string state, string zip5, string zip4) {
            this.addr1 = addr1;
            this.addr2 = addr2;
            this.city = city;
            this.state = state;
            this.zip5 = zip5;
            this.zip4 = zip4;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ClassifyAddressResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ClassifyAddressResponse", Namespace="http://tempuri.org/", Order=0)]
        public AddressManager.Data.UPSOnline.ClassifyAddressResponseBody Body;
        
        public ClassifyAddressResponse() {
        }
        
        public ClassifyAddressResponse(AddressManager.Data.UPSOnline.ClassifyAddressResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ClassifyAddressResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int ClassifyAddressResult;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int classification;
        
        public ClassifyAddressResponseBody() {
        }
        
        public ClassifyAddressResponseBody(int ClassifyAddressResult, int classification) {
            this.ClassifyAddressResult = ClassifyAddressResult;
            this.classification = classification;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UPSOnlineSoapChannel : AddressManager.Data.UPSOnline.UPSOnlineSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UPSOnlineSoapClient : System.ServiceModel.ClientBase<AddressManager.Data.UPSOnline.UPSOnlineSoap>, AddressManager.Data.UPSOnline.UPSOnlineSoap {
        
        public UPSOnlineSoapClient() {
        }
        
        public UPSOnlineSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UPSOnlineSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UPSOnlineSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UPSOnlineSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLResponse AddressManager.Data.UPSOnline.UPSOnlineSoap.ValidateClassifyAddressXML(AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLRequest request) {
            return base.Channel.ValidateClassifyAddressXML(request);
        }
        
        public AddressManager.Data.UPSOnline.Response ValidateClassifyAddressXML(string addr1, string addr2, string city, string state, string zip5) {
            AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLRequest inValue = new AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLRequest();
            inValue.Body = new AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLRequestBody();
            inValue.Body.addr1 = addr1;
            inValue.Body.addr2 = addr2;
            inValue.Body.city = city;
            inValue.Body.state = state;
            inValue.Body.zip5 = zip5;
            AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLResponse retVal = ((AddressManager.Data.UPSOnline.UPSOnlineSoap)(this)).ValidateClassifyAddressXML(inValue);
            return retVal.Body.ValidateClassifyAddressXMLResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLResponse> AddressManager.Data.UPSOnline.UPSOnlineSoap.ValidateClassifyAddressXMLAsync(AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLRequest request) {
            return base.Channel.ValidateClassifyAddressXMLAsync(request);
        }
        
        public System.Threading.Tasks.Task<AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLResponse> ValidateClassifyAddressXMLAsync(string addr1, string addr2, string city, string state, string zip5) {
            AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLRequest inValue = new AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLRequest();
            inValue.Body = new AddressManager.Data.UPSOnline.ValidateClassifyAddressXMLRequestBody();
            inValue.Body.addr1 = addr1;
            inValue.Body.addr2 = addr2;
            inValue.Body.city = city;
            inValue.Body.state = state;
            inValue.Body.zip5 = zip5;
            return ((AddressManager.Data.UPSOnline.UPSOnlineSoap)(this)).ValidateClassifyAddressXMLAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AddressManager.Data.UPSOnline.ValidateClassifyAddressResponse AddressManager.Data.UPSOnline.UPSOnlineSoap.ValidateClassifyAddress(AddressManager.Data.UPSOnline.ValidateClassifyAddressRequest request) {
            return base.Channel.ValidateClassifyAddress(request);
        }
        
        public int ValidateClassifyAddress(ref string addr1, ref string addr2, ref string city, ref string state, ref string zip5, ref string zip4, out int status, out int classification, out int count) {
            AddressManager.Data.UPSOnline.ValidateClassifyAddressRequest inValue = new AddressManager.Data.UPSOnline.ValidateClassifyAddressRequest();
            inValue.Body = new AddressManager.Data.UPSOnline.ValidateClassifyAddressRequestBody();
            inValue.Body.addr1 = addr1;
            inValue.Body.addr2 = addr2;
            inValue.Body.city = city;
            inValue.Body.state = state;
            inValue.Body.zip5 = zip5;
            inValue.Body.zip4 = zip4;
            AddressManager.Data.UPSOnline.ValidateClassifyAddressResponse retVal = ((AddressManager.Data.UPSOnline.UPSOnlineSoap)(this)).ValidateClassifyAddress(inValue);
            addr1 = retVal.Body.addr1;
            addr2 = retVal.Body.addr2;
            city = retVal.Body.city;
            state = retVal.Body.state;
            zip5 = retVal.Body.zip5;
            zip4 = retVal.Body.zip4;
            status = retVal.Body.status;
            classification = retVal.Body.classification;
            count = retVal.Body.count;
            return retVal.Body.ValidateClassifyAddressResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<AddressManager.Data.UPSOnline.ValidateClassifyAddressResponse> AddressManager.Data.UPSOnline.UPSOnlineSoap.ValidateClassifyAddressAsync(AddressManager.Data.UPSOnline.ValidateClassifyAddressRequest request) {
            return base.Channel.ValidateClassifyAddressAsync(request);
        }
        
        public System.Threading.Tasks.Task<AddressManager.Data.UPSOnline.ValidateClassifyAddressResponse> ValidateClassifyAddressAsync(string addr1, string addr2, string city, string state, string zip5, string zip4) {
            AddressManager.Data.UPSOnline.ValidateClassifyAddressRequest inValue = new AddressManager.Data.UPSOnline.ValidateClassifyAddressRequest();
            inValue.Body = new AddressManager.Data.UPSOnline.ValidateClassifyAddressRequestBody();
            inValue.Body.addr1 = addr1;
            inValue.Body.addr2 = addr2;
            inValue.Body.city = city;
            inValue.Body.state = state;
            inValue.Body.zip5 = zip5;
            inValue.Body.zip4 = zip4;
            return ((AddressManager.Data.UPSOnline.UPSOnlineSoap)(this)).ValidateClassifyAddressAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AddressManager.Data.UPSOnline.ClassifyAddressXMLResponse AddressManager.Data.UPSOnline.UPSOnlineSoap.ClassifyAddressXML(AddressManager.Data.UPSOnline.ClassifyAddressXMLRequest request) {
            return base.Channel.ClassifyAddressXML(request);
        }
        
        public AddressManager.Data.UPSOnline.Response ClassifyAddressXML(string addr1, string addr2, string city, string state, string zip5, string zip4) {
            AddressManager.Data.UPSOnline.ClassifyAddressXMLRequest inValue = new AddressManager.Data.UPSOnline.ClassifyAddressXMLRequest();
            inValue.Body = new AddressManager.Data.UPSOnline.ClassifyAddressXMLRequestBody();
            inValue.Body.addr1 = addr1;
            inValue.Body.addr2 = addr2;
            inValue.Body.city = city;
            inValue.Body.state = state;
            inValue.Body.zip5 = zip5;
            inValue.Body.zip4 = zip4;
            AddressManager.Data.UPSOnline.ClassifyAddressXMLResponse retVal = ((AddressManager.Data.UPSOnline.UPSOnlineSoap)(this)).ClassifyAddressXML(inValue);
            return retVal.Body.ClassifyAddressXMLResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<AddressManager.Data.UPSOnline.ClassifyAddressXMLResponse> AddressManager.Data.UPSOnline.UPSOnlineSoap.ClassifyAddressXMLAsync(AddressManager.Data.UPSOnline.ClassifyAddressXMLRequest request) {
            return base.Channel.ClassifyAddressXMLAsync(request);
        }
        
        public System.Threading.Tasks.Task<AddressManager.Data.UPSOnline.ClassifyAddressXMLResponse> ClassifyAddressXMLAsync(string addr1, string addr2, string city, string state, string zip5, string zip4) {
            AddressManager.Data.UPSOnline.ClassifyAddressXMLRequest inValue = new AddressManager.Data.UPSOnline.ClassifyAddressXMLRequest();
            inValue.Body = new AddressManager.Data.UPSOnline.ClassifyAddressXMLRequestBody();
            inValue.Body.addr1 = addr1;
            inValue.Body.addr2 = addr2;
            inValue.Body.city = city;
            inValue.Body.state = state;
            inValue.Body.zip5 = zip5;
            inValue.Body.zip4 = zip4;
            return ((AddressManager.Data.UPSOnline.UPSOnlineSoap)(this)).ClassifyAddressXMLAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AddressManager.Data.UPSOnline.ClassifyAddressResponse AddressManager.Data.UPSOnline.UPSOnlineSoap.ClassifyAddress(AddressManager.Data.UPSOnline.ClassifyAddressRequest request) {
            return base.Channel.ClassifyAddress(request);
        }
        
        public int ClassifyAddress(string addr1, string addr2, string city, string state, string zip5, string zip4, out int classification) {
            AddressManager.Data.UPSOnline.ClassifyAddressRequest inValue = new AddressManager.Data.UPSOnline.ClassifyAddressRequest();
            inValue.Body = new AddressManager.Data.UPSOnline.ClassifyAddressRequestBody();
            inValue.Body.addr1 = addr1;
            inValue.Body.addr2 = addr2;
            inValue.Body.city = city;
            inValue.Body.state = state;
            inValue.Body.zip5 = zip5;
            inValue.Body.zip4 = zip4;
            AddressManager.Data.UPSOnline.ClassifyAddressResponse retVal = ((AddressManager.Data.UPSOnline.UPSOnlineSoap)(this)).ClassifyAddress(inValue);
            classification = retVal.Body.classification;
            return retVal.Body.ClassifyAddressResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<AddressManager.Data.UPSOnline.ClassifyAddressResponse> AddressManager.Data.UPSOnline.UPSOnlineSoap.ClassifyAddressAsync(AddressManager.Data.UPSOnline.ClassifyAddressRequest request) {
            return base.Channel.ClassifyAddressAsync(request);
        }
        
        public System.Threading.Tasks.Task<AddressManager.Data.UPSOnline.ClassifyAddressResponse> ClassifyAddressAsync(string addr1, string addr2, string city, string state, string zip5, string zip4) {
            AddressManager.Data.UPSOnline.ClassifyAddressRequest inValue = new AddressManager.Data.UPSOnline.ClassifyAddressRequest();
            inValue.Body = new AddressManager.Data.UPSOnline.ClassifyAddressRequestBody();
            inValue.Body.addr1 = addr1;
            inValue.Body.addr2 = addr2;
            inValue.Body.city = city;
            inValue.Body.state = state;
            inValue.Body.zip5 = zip5;
            inValue.Body.zip4 = zip4;
            return ((AddressManager.Data.UPSOnline.UPSOnlineSoap)(this)).ClassifyAddressAsync(inValue);
        }
    }
}
