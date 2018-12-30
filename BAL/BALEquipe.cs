using System;
using System;
using DAL;
using PROP;
using System.Collections.Generic;
namespace BAL
{
    public class BALEquipe
    {
        public int CreateEquipe(string EquipeName)
        {
            if (string.IsNullOrEmpty(EquipeName))
            {
                return -1;
            }
            else
            {
                DALEquipe dalEquipe = new DALEquipe();
                return dalEquipe.CreateEquipe(EquipeName);
            }
        }

        public List<PROPEquipe> getEquipes()
        {
            DALEquipe dalEquipe = new DALEquipe();
            return dalEquipe.getEquipe(null);

        }


        public List<PROPEquipe> getEquipe(string searchEquipe)
        {
            DALEquipe dalEquipe = new DALEquipe();

            if (string.IsNullOrEmpty(searchEquipe))
            {
                return dalEquipe.getAllEquipe();
            }
            else
            {
                return dalEquipe.getEquipe(searchEquipe);
            }
        }

        public int deleteEquipe(string stringEquipeID)
        {
            int EquipeID;
            DALEquipe dalEquipe = new DALEquipe();
            int.TryParse(stringEquipeID, out EquipeID);

            if (EquipeID == 0)
            {
                return 0;
            }
            else
            {
                return dalEquipe.DeleteEquipe(EquipeID);
            }
        }

        public PROPEquipe getEquipeByID(string stringEquipeID)
        {
            int EquipeID;
            DALEquipe dalEquipe = new DALEquipe();
            int.TryParse(stringEquipeID, out EquipeID);
            if (EquipeID == 0)
            {
                return null;
            }
            else
            {
                return dalEquipe.GetEquipeById(EquipeID);
            }
        }

        public bool updateEquipe(PROPEquipe Equipe)
        {
            if (string.IsNullOrEmpty(Equipe.Nom) || Equipe.Id <= 0)
            {
                return false;
            }
            else
            {
                DALEquipe dalEquipe = new DALEquipe();
                dalEquipe.UpdateEquipe(Equipe);
                return true;
            }
        }
    }
}
