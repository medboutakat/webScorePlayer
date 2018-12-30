using System;
using DAL;
using PROP;
using System.Collections.Generic;
namespace BAL
{
    public class BALBut
    {
        public int CreateBut(int id, int equipeId, int tournoiId, int joueurId, DateTime date)
        { 
            if (string.IsNullOrEmpty(equipeId.ToString()))
            {
                return -1;
            }
            else
            {
                DALBut dalBut = new DALBut(); 
                PROPBut joueur=new PROPBut (0,tournoiId,equipeId,joueurId,date);

                return dalBut.CreateBut(joueur);
            }
        }

        public List<PROPBut> getBut(string searchBut)
        {
            DALBut dalBut = new DALBut();

            if (string.IsNullOrEmpty(searchBut))
            {
                return dalBut.getAllBut();
            }
            else
            {
                return dalBut.getBut(searchBut);
            }
        }

        public int deleteBut(string stringButID)
        {
            int ButID;
            DALBut dalBut = new DALBut();
            int.TryParse(stringButID, out ButID);

            if (ButID == 0)
            {
                return 0;
            }
            else
            {
                return dalBut.DeleteBut(ButID);
            }
        }

        public string getButByID(string stringButID)
        {
            int ButID;
            DALBut dalBut = new DALBut();
            int.TryParse(stringButID, out ButID);
            if (ButID == 0)
            {
                return string.Empty;
            }
            else
            {
                return dalBut.GetButById(ButID);
            }
        }

        public bool updateBut(PROPBut But)
        {
            if (string.IsNullOrEmpty(But.Id.ToString()) || But.Id <= 0)
            {
                return false;
            }
            else
            {
                DALBut dalBut = new DALBut();
                dalBut.UpdateBut(But);
                return true;
            }
        }
    }
}
