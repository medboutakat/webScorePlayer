using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PROP;
using System.Data;
using System;

namespace DAL
{
    public class DALEquipe
    {
        public int CreateEquipe(string EquipeName)
        {            
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("_EquipeName", EquipeName));

            return sqlHelper.executeSP<int>(parameters, "InsertEquipe");
        }

        public List<PROPEquipe> getAllEquipe()
        {
            List<PROPEquipe> EquipeList = new List<PROPEquipe>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "getAllEquipe");


            PROPEquipe Equipe;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                Equipe = new PROPEquipe(Convert.ToInt32(drow[0].ToString()) , drow[1].ToString());
                EquipeList.Add(Equipe);
            }

            return EquipeList;
        }

        public List<PROPEquipe> getEquipe(string searchEquipe)
        {
            List<PROPEquipe> EquipeList = new List<PROPEquipe>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("_EquipeName", searchEquipe));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "SelectEquipeByName");

            PROPEquipe Equipe;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                Equipe = new PROPEquipe(Convert.ToInt32(drow[0].ToString()), drow[1].ToString());
                EquipeList.Add(Equipe);
            }

            return EquipeList;
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
            lstParameter.Add(new MySqlParameter("_EquipeID", EquipeID));
            return sqlHelper.executeScaler(lstParameter, "SelectEquipeByID");                
        }

        public void UpdateEquipe(PROPEquipe Equipe)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_EquipeID", Equipe.EquipeID));
            lstParameter.Add(new MySqlParameter("_EquipeName", Equipe.EquipeName));
            sqlHelper.executenonquery(lstParameter, "UpdateEquipeName");
        }
    }
}
