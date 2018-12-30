using System;
using System.Web.UI;
using BAL;
using Logging;
using System.Collections.Generic;
using PROP;

namespace WebPlayer
{
    public partial class _Default : System.Web.UI.Page
    {
        public List<PROPTournoi> ListRandEquipeGrade1 = new List<PROPTournoi>();
        public List<PROPTournoi> ListRandEquipeGrade2 = new List<PROPTournoi>();
        public List<PROPTournoi> ListRandEquipeGrade3 = new List<PROPTournoi>();
        public List<PROPTournoi> ListRandEquipeGrade4 = new List<PROPTournoi>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var balCountry = new BALTournoi();
                var esuips = balCountry.getTournoi(null);
                //var esuipse = balCountry.getEquipe(null); 
                List<PROPTournoi> eq = new List<PROPTournoi>();

                ListRandEquipeGrade1 = esuips.FindAll(x => x.Grade == 1);
                ListRandEquipeGrade2 = esuips.FindAll(x => x.Grade == 2);
                ListRandEquipeGrade3 = esuips.FindAll(x => x.Grade == 3);
                ListRandEquipeGrade4 = esuips.FindAll(x => x.Grade == 4);
               
                
                //binding(null);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            BALEquipe dalequipe = new BALEquipe();

            try
            {
                int returnValue = dalequipe.CreateEquipe("");
                if (returnValue > 0)
                {
                    Page.RegisterClientScriptBlock("message", "<script>alert('Country is created successfully')</script>");
                    //txtCountryName.Text = string.Empty;
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            BALEquipe dalequipe = new BALEquipe();
            try
            {
                int returnValue = 0;
                //int returnValue = dalequipe.deleteEquipe(txtDeleteID.Text);
                if (returnValue == 0)
                {
                    Page.RegisterClientScriptBlock("message", "<script>alert('Incorrect Country Id')</script>");
                }
                else if (returnValue == -2)
                {
                    Page.RegisterClientScriptBlock("message", "<script>alert('Country ID could not found.')</script>");
                }
                else if (returnValue == 1)
                {
                    Page.RegisterClientScriptBlock("message", "<script>alert('Country is deleted successfully.')</script>");
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //binding(txtSearchName.Text);
        }

        protected void btnEditCountryName_Click(object sender, EventArgs e)
        {
            try
            {
                PROP.PROPEquipe equipe = new PROP.PROPEquipe();
                //equipe.Id = Convert.ToInt16(ddlCountry.SelectedValue);
                //equipe.Nom = txtEditCountryName.Text;


                BALEquipe dalequipe = new BALEquipe();

                //DALEquipe balCountry = new BALCountry();


                bool result = dalequipe.updateEquipe(equipe);

                if (!result)
                {
                    Page.RegisterClientScriptBlock("message", "<script>alert('Invalid Inputs for update.')</script>");
                }
                else
                {
                    Page.RegisterClientScriptBlock("message", "<script>alert('Country is updated successfully.')</script>");
                    binding(null);
                    //ddlCountry.SelectedIndex = 0;
                    //txtEditCountryName.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                clsLogging logError = new clsLogging();
                logError.WriteLog(ex);
            }
        }

        private void binding(string searchCountry)
        {
            try
            {
                var balCountry = new BALEquipe();
                //gvCountryList.DataSource = balCountry.getEquipe(searchCountry);
                //gvCountryList.DataBind();

                //ddlCountry.DataSource = balCountry.getEquipe(null);
                //ddlCountry.DataValueField = "CountryID";
                //ddlCountry.DataTextField = "CountryName";
                //ddlCountry.DataBind();
                //ddlCountry.Items.Insert(0,new System.Web.UI.WebControls.ListItem("Select Country to Edit", "-1"));
            }
            catch (Exception ex)
            {
                clsLogging logError = new clsLogging();
                logError.WriteLog(ex);
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string countryName = string.Empty;
            var balEquipe = new BALEquipe();
            try
            {
                //countryName = balEquipe.getEquipeByID(ddlCountry.SelectedValue);
                countryName = "";
                if (string.IsNullOrEmpty(countryName))
                {
                    Page.RegisterClientScriptBlock("message", "<script>alert('Country Id is not found.')</script>");
                }
                else
                {
                    //txtEditCountryName.Text = countryName;
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
