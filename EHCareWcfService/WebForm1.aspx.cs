using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EHCareWcfService
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client Myservice =
                   new ServiceReference1.Service1Client();
            //ServiceReference1.EHCareData EHC =
               // new ServiceReference1.EHCareData();
            //EHC = Myservice.GetEHCareData();
           // DataTable dt = new DataTable();
            //dt = EHC.EHCareDataTable;
            //GridView1.DataSource = dt.DefaultView;

            GridView1.DataSource = Myservice.getdata();
            GridView1.DataBind();

            ;
        }
    }
}