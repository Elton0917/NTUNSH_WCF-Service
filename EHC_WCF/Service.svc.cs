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

        public EHC_Case[] getCase(string Case)
        {
            using (con = new SqlConnection(Constring))
            {
                cmd = new SqlCommand("SELECT HCaseName FROM HomeCaseData WHERE HCaseName LIKE '" + Case + "%'", con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable("Paging");
                sda.Fill(dt);

                int Rcount = dt.Rows.Count;
                EHC_Case[] arrCase = new EHC_Case[Rcount];
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    arrCase[i] = new EHC_Case();
                    arrCase[i].Name = dr["HCaseName"].ToString();

                    i++;
                }
                return arrCase;
            }

        }

        #endregion
    }
}