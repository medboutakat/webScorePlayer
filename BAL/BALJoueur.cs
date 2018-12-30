using System;
using System;
using DAL;
using PROP;
using System.Collections.Generic;
namespace BAL
{
    public class BALJoueur
    {
        public int CreateJoueur(string JoueurName,string JoueurPrenom,bool sexe,int EquipeId)
        {
            if (string.IsNullOrEmpty(JoueurName))
            {
                return -1;
            }
            else
            {
                DALJoueur dalJoueur = new DALJoueur(); 
                PROPJoueur joueur=new PROPJoueur (0,JoueurName,JoueurPrenom,sexe,EquipeId);

                return dalJoueur.CreateJoueur(joueur);
            }
        }

        public List<PROPJoueur> getJoueur(string searchJoueur)
        {
            DALJoueur dalJoueur = new DALJoueur();

            if (string.IsNullOrEmpty(searchJoueur))
            {
                return dalJoueur.getAllJoueur();
            }
            else
            {
                return dalJoueur.getJoueur(searchJoueur);
            }
        }

        public int deleteJoueur(string stringJoueurID)
        {
            int JoueurID;
            DALJoueur dalJoueur = new DALJoueur();
            int.TryParse(stringJoueurID, out JoueurID);

            if (JoueurID == 0)
            {
                return 0;
            }
            else
            {
                return dalJoueur.DeleteJoueur(JoueurID);
            }
        }

        public string getJoueurByID(string stringJoueurID)
        {
            int JoueurID;
            DALJoueur dalJoueur = new DALJoueur();
            int.TryParse(stringJoueurID, out JoueurID);
            if (JoueurID == 0)
            {
                return string.Empty;
            }
            else
            {
                return dalJoueur.GetJoueurById(JoueurID);
            }
        }

        public bool updateJoueur(PROPJoueur Joueur)
        {
            if (string.IsNullOrEmpty(Joueur.Nom) || Joueur.Id <= 0)
            {
                return false;
            }
            else
            {
                DALJoueur dalJoueur = new DALJoueur();
                dalJoueur.UpdateJoueur(Joueur);
                return true;
            }
        }
    }
}
