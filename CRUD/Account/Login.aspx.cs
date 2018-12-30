using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logging;

namespace WebPlayer.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Url.AbsoluteUri.Contains("Account/Login.aspx"))
            {
                if (Session["User"] != null)
                {
                    Response.Redirect("../");
                }
            }
            //else
            //    Response.Redirect(Request.Url.AbsoluteUri);
            //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            binding(null);
        }

        private void binding(string searchCountry)
        {
            try
            {
                var balCountry = new BAL.BALUser();
                List<PROP.PROPUser> Pl = balCountry.getUser(searchCountry);

                var us = Pl.FirstOrDefault(x => x.UserName == UserName.Text && x.Password == Password.Text);
                if (us != null)
                {
                    Session["User"] = UserName.Text;
                    Response.Redirect("../");
                }
                else
                {

                    FailureText.Text = "Les donnee ne son pas corect !";
                }
            }
            catch (Exception ex)
            {
                clsLogging logError = new clsLogging();
                logError.WriteLog(ex);
            }
        }

    }
}
