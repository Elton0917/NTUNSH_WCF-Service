using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EHC_WCF
{
    public class Service : IService
    {
        string Constring =
        ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        #region IRestServiceImpl Members

        public string XMLData(string id)
        {
            return "You requested product " + id;
        }

        public string JSONData(string id)
        {
            return "You requested product " + id;
        }

        public EHC_CaseSelect[] getCase(string Case)
        {
            using (con = new SqlConnection(Constring))
            {
                cmd = new SqlCommand("SELECT HCaseName FROM HomeCaseData WHERE HCaseName LIKE '" + Case + "%'", con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable("Paging");
                sda.Fill(dt);

                int Rcount = dt.Rows.Count;
                EHC_CaseSelect[] arrCase = new EHC_CaseSelect[Rcount];
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    arrCase[i] = new EHC_CaseSelect();
                    arrCase[i].Name = dr["HCaseName"].ToString();

                    i++;
                }
                return arrCase;
            }

        }

        public EHC_CaseResult[] getResult(string Result)
        {
            using (con = new SqlConnection(Constring))
            {
                cmd = new SqlCommand("SELECT TOP 10 HomeCaseData.HCaseName, CaseResult.CResDate,CaseResult.CResType, CaseResult.CResBPSys, CaseResult.CResBPDia,CaseResult.CResBPPulse FROM CaseResult CROSS JOIN HomeCaseData WHERE (HomeCaseData.HCaseName = '" + Result + "') ORDER BY  CaseResult.CResDate DESC", con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable("Paging2");
                sda.Fill(dt);

                int Rcount = dt.Rows.Count;
                EHC_CaseResult[] arrResult = new EHC_CaseResult[Rcount];
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    arrResult[i] = new EHC_CaseResult();
                    arrResult[i].Name = dr["HCaseName"].ToString();
                    arrResult[i].Date = dr["CResDate"].ToString();
                    arrResult[i].Type = dr["CResType"].ToString();
                    arrResult[i].BPsys = dr["CResBPSys"].ToString();
                    arrResult[i].BPDia= dr["CResBPDia"].ToString();
                    arrResult[i].BPPluse= dr["CResBPPulse"].ToString();
                    i++;
                }
                return arrResult;
            }

        }

        #endregion
    }
}