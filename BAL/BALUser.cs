using System;
using DAL;
using PROP;
using System.Collections.Generic;
namespace BAL
{
    public class BALUser
    {
        public int CreateUser(string UserName,string UserPrenom,string sexe)
        {
            if (string.IsNullOrEmpty(UserName))
            {
                return -1;
            }
            else
            {
                DALUser dalUser = new DALUser(); 
                PROPUser joueur=new PROPUser(0,UserName,UserPrenom,sexe);

                return dalUser.CreateEquipe(joueur);
            }
        }

        public List<PROPUser> getUser(string searchUser)
        {
            DALUser dalUser = new DALUser();

            if (string.IsNullOrEmpty(searchUser))
            {
                return dalUser.getAllEquipe();
            }
            else
            {
                return dalUser.getEquipe(searchUser);
            }
        }

        public int deleteUser(string stringUserID)
        {
            int UserID;
            DALUser dalUser = new DALUser();
            int.TryParse(stringUserID, out UserID);

            if (UserID == 0)
            {
                return 0;
            }
            else
            {
                return dalUser.DeleteEquipe(UserID);
            }
        }

        public string getUserByID(string stringUserID)
        {
            int UserID;
            DALUser dalUser = new DALUser();
            int.TryParse(stringUserID, out UserID);
            if (UserID == 0)
            {
                return string.Empty;
            }
            else
            {
                return dalUser.GetEquipeById(UserID);
            }
        }

        public bool updateUser(PROPUser User)
        {
            if (string.IsNullOrEmpty(User.UserName) || User.Id <= 0)
            {
                return false;
            }
            else
            {
                DALUser dalUser = new DALUser();
                dalUser.UpdateEquipe(User);
                return true;
            }
        }
    }
}
