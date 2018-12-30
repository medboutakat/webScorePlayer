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
    public partial class Equipe : System.Web.UI.Page
    {

        public PROP.PROPEquipe EquipeObj;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                enVisibleEditButton();
                string idString = Request.QueryString["id"];

                var balEquipe = new BALEquipe();
                try
                {
                    EquipeObj = balEquipe.getEquipeByID(idString);
                    if (EquipeObj == null)
                    {
                        Page.RegisterClientScriptBlock("message", "<script>alert('Country Id is not found.')</script>");

                        Response.Redirect(btnLink.PostBackUrl);

                    }
                    else
                    {
                        lblName.Text = EquipeObj.Nom;
                        BALJoueur balJoueure = new BALJoueur();
                        var LsJoueur = balJoueure.getJoueur(null);
                        var TwoJoueurs = LsJoueur.Where(x => x.EquipeId == EquipeObj.Id).Take(2);
                        if (TwoJoueurs.Count() > 0) EquipeObj.Joueur1 = TwoJoueurs.FirstOrDefault();
                        if (TwoJoueurs.Count() == 2) EquipeObj.Joueur2 = TwoJoueurs.LastOrDefault();

                        Label1.Text = EquipeObj.Joueur1.Nom;
                        Label2.Text = EquipeObj.Joueur2.Prenom;

                    }
                }
                catch (Exception ex)
                {
                    clsLogging logError = new clsLogging();
                    logError.WriteLog(ex);
                    Response.Redirect(btnLink.PostBackUrl);
                }
            }

        }
        void enVisibleEditButton()
        {
            UpdBtn.Visible = TextBox1.Visible = TextBox2.Visible = txtName.Visible = !(EdBtn.Visible = txtName.Visible);

            txtName.Text = lblName.Text;
            TextBox1.Text = Label1.Text;
            TextBox2.Text = Label2.Text;


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            enVisibleEditButton();
        }
    }
}