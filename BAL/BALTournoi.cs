using System;
using System;
using DAL;
using PROP;
using System.Collections.Generic;
namespace BAL
{
    public class BALTournoi
    {
        public int CreateTournoi(string TournoiName)
        {
            if (string.IsNullOrEmpty(TournoiName))
            {
                return -1;
            }
            else
            {
                DALTournoi dalTournoi = new DALTournoi();
                return dalTournoi.CreateTournoi(TournoiName);
            }
        }

        public List<PROPTournoi> getTournois()
        {
            DALTournoi dalTournoi = new DALTournoi();
            return dalTournoi.getTournoi(null);

        }


        public List<PROPTournoi> getTournoi(string searchTournoi)
        {
            DALTournoi dalTournoi = new DALTournoi();

            if (string.IsNullOrEmpty(searchTournoi))
            {
                return dalTournoi.getAllTournoi();
            }
            else
            {
                return dalTournoi.getTournoi(searchTournoi);
            }
        }

        public int deleteTournoi(string stringTournoiID)
        {
            int TournoiID;
            DALTournoi dalTournoi = new DALTournoi();
            int.TryParse(stringTournoiID, out TournoiID);

            if (TournoiID == 0)
            {
                return 0;
            }
            else
            {
                return dalTournoi.DeleteTournoi(TournoiID);
            }
        }

        public PROPTournoi getTournoiByID(string stringTournoiID)
        {
            int TournoiID;
            DALTournoi dalTournoi = new DALTournoi();
            int.TryParse(stringTournoiID, out TournoiID);
            if (TournoiID == 0)
            {
                return null;
            }
            else
            {
                return dalTournoi.GetTournoiById(TournoiID);
            }
        }

        public bool updateTournoi(PROPTournoi Tournoi)
        {
            if (string.IsNullOrEmpty(Tournoi.EquipeANom) || Tournoi.Id <= 0)
            {
                return false;
            }
            else
            {
                DALTournoi dalTournoi = new DALTournoi();
                dalTournoi.UpdateTournoi(Tournoi);
                return true;
            }
        }

        public List<PROPTournoi> getAllTournoi()
        {
            DALTournoi dalTournoi = new DALTournoi();
            return dalTournoi.getAllTournoi();
        }
    }
}
