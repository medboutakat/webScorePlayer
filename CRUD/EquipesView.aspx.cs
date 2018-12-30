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
    public partial class EquipesView : System.Web.UI.Page
    {
        public List<PROP.PROPEquipe> LsEquipe = new List<PROP.PROPEquipe>();
        public List<PROP.PROPJoueur> LsJoueur = new List<PROP.PROPJoueur>();


        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                binding(null);
            } 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            IService1 i = new Service1(); 
        }

        private void binding(string searchJoueur)
        {
            try
            { 
                BALEquipe balEquipe = new BALEquipe();
                LsEquipe = balEquipe.getEquipe(null);

                BALJoueur balJoueure = new BALJoueur();
                LsJoueur = balJoueure.getJoueur(null);

                foreach (var eq in LsEquipe)
                {
                    var TwoJoueurs=LsJoueur.Where(x => x.EquipeId == eq.Id).Take(2);
                    if (TwoJoueurs.Count() > 0) eq.Joueur1 = TwoJoueurs.FirstOrDefault();  
                    if (TwoJoueurs.Count() == 2) eq.Joueur2 = TwoJoueurs.LastOrDefault(); 
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