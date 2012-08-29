using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Data;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EHCareWcfService
{

    
    [ServiceContract]
    public interface IService1
    {


        [OperationContract, WebGet(UriTemplate = "/TestRestful/{value}", RequestFormat = WebMessageFormat.Json)]
        //EHCareData GetEHCareData();
        EHC_Case[] getdata();
        // TODO: 在此新增您的服務作業
    }


    //使用下列範例中所示的資料合約，新增複合型別至服務作業。
    [DataContract]

    //public class EHCareData
    //{
    //    [DataMember]
    //    public DataTable EHCareDataTable
    //    {
    //        get;
    //        set;
    //    }
    //}

    public class EHC_Case
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string No { get; set; }

    }

}
