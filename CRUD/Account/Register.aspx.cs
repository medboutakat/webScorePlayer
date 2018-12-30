using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logging;
using BAL;

namespace WebPlayer.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("../");
            }
           
            //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }


        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            BALUser balJoueur = new BALUser();

            try
            {
                int returnValue = balJoueur.CreateUser(this.UserName.Text, this.Email.Text, this.Password.Text);
                if (returnValue > 0)
                {

                    Page.RegisterClientScriptBlock("message", "<script>alert('Joueur is created successfully')</script>");

                    Session["User"] = this.UserName.Text;
                    //binding(null);
                }
                else
                {
                    Page.RegisterClientScriptBlock("message", "<script>alert('Incorrect User Inputs.')</script>");
                }
            }
            catch (Exception ex)
            {
                clsLogging logError = new clsLogging();
                logError.WriteLog(ex);
            }
        }

        //protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        //{
        //    FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

        //    string continueUrl = RegisterUser.ContinueDestinationPageUrl;
        //    if (String.IsNullOrEmpty(continueUrl))
        //    {
        //        continueUrl = "~/";
        //    }
        //    Response.Redirect(continueUrl);
        //}

    }
}
