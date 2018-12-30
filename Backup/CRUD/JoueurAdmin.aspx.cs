using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using Logging;

namespace WebPlayer
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var j = GridView1.Rows[e.RowIndex].Cells[1].Text;
            deletebyId(j);
        }

        void deletebyId(string txtId)
        {
            BALJoueur balJoueur = new BALJoueur();
            try
            {
                int returnValue = balJoueur.deleteJoueur(txtId);
                if (returnValue == 0)
                {
                    Page.RegisterClientScriptBlock("message", "<script>alert('Incorrect Joueur Id')</script>");
                }
                else if (returnValue == -2)
                {
                    Page.RegisterClientScriptBlock("message", "<script>alert('Joueur ID could not found.')</script>");
                }
                else if (returnValue == 1)
                {
                    Page.RegisterClientScriptBlock("message", "<script>alert('Joueur is deleted successfully.')</script>");
                    //binding(null);
                    //txtDeleteID.Text = string.Empty;
                }
                else
                {
                    Page.RegisterClientScriptBlock("message", "<script>alert('Unspecified error.')</script>");
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