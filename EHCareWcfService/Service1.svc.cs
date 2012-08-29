using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace EHCareWcfService
{
    // 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼、svc 和組態檔中的類別名稱 "Service1"。
    public class Service1 : IService1
    {
        string Constring =
            ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        //EHCareData EHC = new EHCareData();

        public EHC_Case[] getdata()
        {
            using (con = new SqlConnection(Constring))
            {
                cmd = new SqlCommand("SELECT TOP 20 HCaseName,HCaseNo FROM HomeCaseData ", con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable("Paging");
                sda.Fill(dt);

                //原為輸出datatable 
                //EHC.EHCareDataTable = dt;
                //return EHC;

                int Rcount = dt.Rows.Count;
                EHC_Case[] arrCase = new EHC_Case[Rcount];
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    arrCase[i] = new EHC_Case();
                    arrCase[i].UserName = dr["HCaseName"].ToString();
                    arrCase[i].No = dr["HCaseNo"].ToString();
                    i++;
                }
                return arrCase;
            }
            
        }

    }
}
