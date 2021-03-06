﻿using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

namespace EHC_WCF
{

    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "xml/{id}")]
        string XMLData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "json/{id}")]
        string JSONData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "getCase/{Case}")]
        EHC_CaseSelect[] getCase(string Case);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "getResult/{Result}")]
        EHC_CaseResult[] getResult(string Result);
    }



    [DataContract]
    public class EHC_CaseSelect
    {
        [DataMember]
        public string Name { get; set; }

    }
    public class EHC_CaseResult
    { 
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string BPsys { get; set; }
        [DataMember]
        public string BPDia { get; set; }
        [DataMember]
        public string BPPluse { get; set; }
    }
}