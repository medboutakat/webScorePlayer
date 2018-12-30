using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PROP;
using System.Data;
using System;

namespace DAL
{
    public class DALJoueur
    {
        public int CreateJoueur(PROPJoueur Joueur)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("_JoueurName", Joueur.Nom));
            parameters.Add(new MySqlParameter("_JoueurPrenom", Joueur.Prenom));
            parameters.Add(new MySqlParameter("_JoueurSexe", Joueur.Sexe ? 1 : 0));
            parameters.Add(new MySqlParameter("_JoueurEquipeId", Joueur.EquipeId)); 
            return sqlHelper.executeSP<int>(parameters, "InsertJoueur");
        }

        public List<PROPJoueur> getAllJoueur()
        {
            List<PROPJoueur> JoueurList = new List<PROPJoueur>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "getAllJoueur");


            PROPJoueur Joueur;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                Joueur = new PROPJoueur();

                   Joueur.Id= Convert.ToInt32(drow[0].ToString()); 
                   if(drow[1] !=null)  Joueur.Nom=  drow[1].ToString();
                   if(drow[2] !=null)   Joueur.Prenom= drow[2].ToString();
                   if(drow[3] !=null)   Joueur.Sexe= Convert.ToBoolean(drow[3]);
                if (drow[4] != null &&typeof(DBNull)!= drow[4].GetType()) Joueur.EquipeId = Convert.ToInt32(drow[4]);
                   JoueurList.Add(Joueur);
            }

            return JoueurList;
        }

        public List<PROPJoueur> getJoueur(string searchJoueur)
        {
            List<PROPJoueur> JoueurList = new List<PROPJoueur>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("_JoueurSearch", searchJoueur));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "SelectJoueur");

            PROPJoueur Joueur;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                Joueur = new PROPJoueur(

                      Convert.ToInt32(drow[0].ToString()),
                    drow[1].ToString(),
                    drow[2].ToString(),
                 Convert.ToBoolean(drow[3]),

                  Convert.ToInt32(drow[4])
     );
                JoueurList.Add(Joueur);
            }

            return JoueurList;
        }

        public int DeleteJoueur(PROPJoueur Joueur)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_JoueurID", Joueur.Id));
            return sqlHelper.executeSP<int>(lstParameter, "DeleteJoueur");
        }
        
        public int DeleteJoueur(int JoueurID)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_JoueurID", JoueurID));
            return sqlHelper.executeSP<int>(lstParameter, "DeleteJoueur");
        }

        public string GetJoueurById(int JoueurID)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_Id", JoueurID));
            return sqlHelper.executeScaler(lstParameter, "SelectJoueurByID");
        }

        public void UpdateJoueur(PROPJoueur Joueur)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_Id", Joueur.Id));
            lstParameter.Add(new MySqlParameter("_Nom", Joueur.Nom));
            lstParameter.Add(new MySqlParameter("_Prenom", Joueur.Prenom));
            lstParameter.Add(new MySqlParameter("_Sexe", Joueur.Sexe ? 1 : 0));
            lstParameter.Add(new MySqlParameter("_EquipeId", Joueur.EquipeId));
            sqlHelper.executenonquery(lstParameter, "UpdateJoueur");
        }
    }
}
