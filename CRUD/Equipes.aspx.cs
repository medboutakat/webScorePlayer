using System;
using System.Web.UI;
using BAL;
using Logging;
using System.Web.UI.WebControls;

namespace WebPlayer
{
    public partial class _Equipes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Account/Login.aspx");
            }

            if (!IsPostBack)
            {
                binding(null);
            }

            gvJoueurList.RowCommand += new GridViewCommandEventHandler(gvJoueurList_RowCommand);
        }

        void gvJoueurList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            { 
                deletebyId((string)e.CommandArgument);
            }
            if (e.CommandName == "Sort")
            {
                if (e.CommandArgument == "Nom")
                { 
                    gvJoueurList.Sort(">", SortDirection.Ascending);
                }
            }

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            BALEquipe balJoueur = new BALEquipe();

            try
            {
                int returnValue = balJoueur.CreateEquipe(txtEquipeName.Text);
                if (returnValue > 0)
                {

                    gvJoueurList.DataBind();
                    Page.RegisterClientScriptBlock("message", "<script>alert('Joueur is created successfully')</script>");
                    txtEquipeName.Text = string.Empty;

                    binding(null);
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

        void deletebyId(string txtId)
        {
            BALEquipe balJoueur = new BALEquipe();
            try
            {
                int returnValue = balJoueur.deleteEquipe(txtId);
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
                    binding(null);
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //deletebyId(txtDeleteID.Text);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //binding(txtSearchName.Text);
        }

        protected void btnEditJoueurName_Click(object sender, EventArgs e)
        {
            try
            {
                PROP.PROPJoueur Joueur = new PROP.PROPJoueur();
                //Joueur.Id = Convert.ToInt16(ddlJoueur.SelectedValue);
                //Joueur.Nom = txtEditJoueurName.Text;

                BALJoueur balJoueur = new BALJoueur();
                bool result = balJoueur.updateJoueur(Joueur);

                if (!result)
                {
                    Page.RegisterClientScriptBlock("message", "<script>alert('Invalid Inputs for update.')</script>");
                }
                else
                {
                    Page.RegisterClientScriptBlock("message", "<script>alert('Joueur is updated successfully.')</script>");
                    binding(null);
                    //ddlJoueur.SelectedIndex = 0;
                    //txtEditJoueurName.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                clsLogging logError = new clsLogging();
                logError.WriteLog(ex);
            }
        }
        private void binding(string searchJoueur)
        {
            try
            {
                //BALJoueur balJoueur = new BALJoueur();
                //gvJoueurList.DataSource = balJoueur.getJoueur(searchJoueur);
                //gvJoueurList.DataBind();
                BALEquipe balEquipe = new BALEquipe();
                //ddlEquipe.DataSource = balEquipe.getEquipe(null);

                //ddlEquipe.DataValueField = "id";
                //ddlEquipe.DataTextField = "nom";
                //ddlEquipe.DataBind();
                //ddlEquipe.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selectionnée l'equipe", "-1"));
            }
            catch (Exception ex)
            {
                clsLogging logError = new clsLogging();
                logError.WriteLog(ex);
            }
        }

        protected void ddlJoueur_SelectedIndexChanged(object sender, EventArgs e)
        {
            string JoueurName = string.Empty;
            BALJoueur balJoueur = new BALJoueur();
            try
            {
                //JoueurName = balJoueur.getJoueurByID(ddlJoueur.SelectedValue);
                //if (string.IsNullOrEmpty(JoueurName))
                //{
                //    Page.RegisterClientScriptBlock("message", "<script>alert('Joueur Id is not found.')</script>");
                //}
                //else
                //{
                //    txtEditJoueurName.Text = JoueurName;
                //}
            }
            catch (Exception ex)
            {
                clsLogging logError = new clsLogging();
                logError.WriteLog(ex);
            }
        }

        protected void gvJoueurList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {

            //gvJoueurList.EditIndex = e.NewEditIndex;
            binding(null);


        }

        protected void gvJoueurList_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            //gvJoueurList.EditIndex = -1;
            binding(null);
        }

        protected void gvJoueurList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEquipeName.Text = gvJoueurList.SelectedRow.Cells[1].Text;
            //txtJoueurPrenom.Text = gvJoueurList.SelectedRow.Cells[2].Text;
        }

        protected void gvJoueurList_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var j = gvJoueurList.Rows[e.RowIndex].Cells[1].Text;
            deletebyId(j);
        }

        protected void gvJoueurList_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //DropDownList DropDownList1 = (e.Row.FindControl("ddequipeRow") as DropDownList);
                //BALEquipe balEquipe = new BALEquipe();
                //DropDownList1.DataSource = balEquipe.getEquipe("");
                //DropDownList1.DataValueField = "id";
                //DropDownList1.DataTextField = "nom"; 
                //DropDownList1.DataBind();


            }

        }

        protected void gvJoueurList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            try
            {
                PROP.PROPJoueur Joueur = new PROP.PROPJoueur();

                //int userid = Convert.ToInt32(gvJoueurList.DataKeys[e.RowIndex].Value.ToString());
                GridViewRow row = (GridViewRow)gvJoueurList.Rows[e.RowIndex];
                Label lblID = (Label)row.FindControl("lblID");
                //TextBox txtname=(TextBox)gr.cell[].control[];  
                TextBox txtId = (TextBox)row.Cells[2].Controls[0];
                TextBox txtName = (TextBox)row.Cells[3].Controls[0];
                TextBox txtPrenom = (TextBox)row.Cells[4].Controls[0];
                //TextBox textadd = (TextBox)row.FindControl("txtadd");  
                //TextBox textc = (TextBox)row.FindControl("txtc");  
                gvJoueurList.EditIndex = -1;

                Joueur.Id = int.Parse(txtId.Text);
                Joueur.Nom = txtName.Text;
                Joueur.Prenom = txtPrenom.Text;

                BALJoueur balJoueur = new BALJoueur();
                bool result = balJoueur.updateJoueur(Joueur);

                if (!result)
                {
                    Page.RegisterClientScriptBlock("message", "<script>alert('Invalid Inputs for update.')</script>");
                }
                else
                {
                    Page.RegisterClientScriptBlock("message", "<script>alert('Joueur is updated successfully.')</script>");
                    binding(null);
                    //ddlJoueur.SelectedIndex = 0;
                    //txtEditJoueurName.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                clsLogging logError = new clsLogging();
                logError.WriteLog(ex);
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvJoueurList_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}
