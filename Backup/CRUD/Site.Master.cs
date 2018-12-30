using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPlayer
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string logOut = Request.QueryString["logout"];
            if (!string.IsNullOrWhiteSpace(logOut) && logOut.Equals("true"))
            {
                Session["User"] = null;

                Response.Redirect("/");
            }

        }
    }
}
