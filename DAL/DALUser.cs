using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PROP;
using System.Data;
using System;

namespace DAL
{
    public class DALUser
    {
        public int CreateEquipe(PROPUser Equipe)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("_UserName", Equipe.UserName));
            parameters.Add(new MySqlParameter("_Email", Equipe.Email));
            parameters.Add(new MySqlParameter("_Password", Equipe.Password));
            return sqlHelper.executeSP<int>(parameters, "InsertUser");
        }

        public List<PROPUser> getAllEquipe()
        {
            List<PROPUser> EquipeList = new List<PROPUser>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "getAllUser");
             
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            { 
                var user = new PROPUser(

                     Convert.ToInt32(drow[0].ToString()),
                   drow[1].ToString(),
                   drow[2].ToString(),
                   drow[3].ToString()

               ); 
                EquipeList.Add(user);
            }

            return EquipeList;
        }

        public List<PROPUser> getEquipe(string searchEquipe)
        {
            List<PROPUser> EquipeList = new List<PROPUser>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("_EquipeSearch", searchEquipe));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "SelectEquipe");

            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                var user = new PROPUser(

                      Convert.ToInt32(drow[0].ToString()),
                    drow[1].ToString(),
                    drow[2].ToString(),
                    drow[2].ToString()

                );
                EquipeList.Add(user);
            }

            return EquipeList;
        }

        public int DeleteEquipe(PROPUser Equipe)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_EquipeID", Equipe.Id));
            return sqlHelper.executeSP<int>(lstParameter, "DeleteEquipe");
        }

        public int DeleteEquipe(int EquipeID)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_EquipeID", EquipeID));
            return sqlHelper.executeSP<int>(lstParameter, "DeleteEquipe");
        }

        public string GetEquipeById(int EquipeID)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_Id", EquipeID));
            return sqlHelper.executeScaler(lstParameter, "SelectEquipeByID");
        }

        public void UpdateEquipe(PROPUser Equipe)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_Id", Equipe.Id));
            lstParameter.Add(new MySqlParameter("_UserName", Equipe.UserName));
            lstParameter.Add(new MySqlParameter("_Email", Equipe.Email));
            lstParameter.Add(new MySqlParameter("_Password", Equipe.Password)); 
            sqlHelper.executenonquery(lstParameter, "UpdateUser");
        }
    }
}
