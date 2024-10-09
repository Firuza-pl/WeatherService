﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WeatherResponse", Namespace="http://tempuri.org/")]
    public partial class WeatherResponse : object
    {
        
        private string CityField;
        
        private string DescriptionField;
        
        private System.Nullable<decimal> TemperatureField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string City
        {
            get
            {
                return this.CityField;
            }
            set
            {
                this.CityField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Nullable<decimal> Temperature
        {
            get
            {
                return this.TemperatureField;
            }
            set
            {
                this.TemperatureField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ForeCastResponse", Namespace="http://tempuri.org/")]
    public partial class ForeCastResponse : object
    {
        
        private string CityField;
        
        private ServiceReference1.DailyResponse[] DailyForecastField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string City
        {
            get
            {
                return this.CityField;
            }
            set
            {
                this.CityField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.DailyResponse[] DailyForecast
        {
            get
            {
                return this.DailyForecastField;
            }
            set
            {
                this.DailyForecastField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DailyResponse", Namespace="http://tempuri.org/")]
    public partial class DailyResponse : object
    {
        
        private string DescriptionField;
        
        private System.Nullable<decimal> TemperatureField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Nullable<decimal> Temperature
        {
            get
            {
                return this.TemperatureField;
            }
            set
            {
                this.TemperatureField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IWeatherSoapService")]
    public interface IWeatherSoapService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeatherSoapService/GetWeather", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference1.GetWeatherResponse> GetWeatherAsync(ServiceReference1.GetWeatherRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeatherSoapService/GetWeeklyForecast", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference1.GetWeeklyForecastResponse> GetWeeklyForecastAsync(ServiceReference1.GetWeeklyForecastRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetWeatherRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetWeather", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.GetWeatherRequestBody Body;
        
        public GetWeatherRequest()
        {
        }
        
        public GetWeatherRequest(ServiceReference1.GetWeatherRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetWeatherRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string cityName;
        
        public GetWeatherRequestBody()
        {
        }
        
        public GetWeatherRequestBody(string cityName)
        {
            this.cityName = cityName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetWeatherResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetWeatherResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.GetWeatherResponseBody Body;
        
        public GetWeatherResponse()
        {
        }
        
        public GetWeatherResponse(ServiceReference1.GetWeatherResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetWeatherResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ServiceReference1.WeatherResponse GetWeatherResult;
        
        public GetWeatherResponseBody()
        {
        }
        
        public GetWeatherResponseBody(ServiceReference1.WeatherResponse GetWeatherResult)
        {
            this.GetWeatherResult = GetWeatherResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetWeeklyForecastRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetWeeklyForecast", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.GetWeeklyForecastRequestBody Body;
        
        public GetWeeklyForecastRequest()
        {
        }
        
        public GetWeeklyForecastRequest(ServiceReference1.GetWeeklyForecastRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetWeeklyForecastRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string name;
        
        public GetWeeklyForecastRequestBody()
        {
        }
        
        public GetWeeklyForecastRequestBody(string name)
        {
            this.name = name;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetWeeklyForecastResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetWeeklyForecastResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.GetWeeklyForecastResponseBody Body;
        
        public GetWeeklyForecastResponse()
        {
        }
        
        public GetWeeklyForecastResponse(ServiceReference1.GetWeeklyForecastResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetWeeklyForecastResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ServiceReference1.ForeCastResponse GetWeeklyForecastResult;
        
        public GetWeeklyForecastResponseBody()
        {
        }
        
        public GetWeeklyForecastResponseBody(ServiceReference1.ForeCastResponse GetWeeklyForecastResult)
        {
            this.GetWeeklyForecastResult = GetWeeklyForecastResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IWeatherSoapServiceChannel : ServiceReference1.IWeatherSoapService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class WeatherSoapServiceClient : System.ServiceModel.ClientBase<ServiceReference1.IWeatherSoapService>, ServiceReference1.IWeatherSoapService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public WeatherSoapServiceClient() : 
                base(WeatherSoapServiceClient.GetDefaultBinding(), WeatherSoapServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IWeatherSoapService_soap.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WeatherSoapServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(WeatherSoapServiceClient.GetBindingForEndpoint(endpointConfiguration), WeatherSoapServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WeatherSoapServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(WeatherSoapServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WeatherSoapServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(WeatherSoapServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WeatherSoapServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetWeatherResponse> ServiceReference1.IWeatherSoapService.GetWeatherAsync(ServiceReference1.GetWeatherRequest request)
        {
            return base.Channel.GetWeatherAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.GetWeatherResponse> GetWeatherAsync(string cityName)
        {
            ServiceReference1.GetWeatherRequest inValue = new ServiceReference1.GetWeatherRequest();
            inValue.Body = new ServiceReference1.GetWeatherRequestBody();
            inValue.Body.cityName = cityName;
            return ((ServiceReference1.IWeatherSoapService)(this)).GetWeatherAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetWeeklyForecastResponse> ServiceReference1.IWeatherSoapService.GetWeeklyForecastAsync(ServiceReference1.GetWeeklyForecastRequest request)
        {
            return base.Channel.GetWeeklyForecastAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.GetWeeklyForecastResponse> GetWeeklyForecastAsync(string name)
        {
            ServiceReference1.GetWeeklyForecastRequest inValue = new ServiceReference1.GetWeeklyForecastRequest();
            inValue.Body = new ServiceReference1.GetWeeklyForecastRequestBody();
            inValue.Body.name = name;
            return ((ServiceReference1.IWeatherSoapService)(this)).GetWeeklyForecastAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IWeatherSoapService_soap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IWeatherSoapService_soap))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:7166/WeatherSoapService.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return WeatherSoapServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IWeatherSoapService_soap);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return WeatherSoapServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IWeatherSoapService_soap);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IWeatherSoapService_soap,
        }
    }
}
